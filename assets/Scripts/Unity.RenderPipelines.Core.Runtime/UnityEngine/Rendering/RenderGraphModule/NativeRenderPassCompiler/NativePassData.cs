using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal struct NativePassData
{
	public FixedAttachmentArray<LoadAudit> loadAudit;

	public FixedAttachmentArray<StoreAudit> storeAudit;

	public PassBreakAudit breakAudit;

	public FixedAttachmentArray<PassFragmentData> fragments;

	public FixedAttachmentArray<NativePassAttachment> attachments;

	public int firstGraphPass;

	public int lastGraphPass;

	public int numGraphPasses;

	public int firstNativeSubPass;

	public int numNativeSubPasses;

	public int width;

	public int height;

	public int volumeDepth;

	public int samples;

	public bool hasDepth;

	public bool hasFoveatedRasterization;

	public NativePassData(ref PassData pass, CompilerContextData ctx)
	{
		firstGraphPass = pass.passId;
		lastGraphPass = pass.passId;
		numGraphPasses = 1;
		firstNativeSubPass = -1;
		numNativeSubPasses = 0;
		fragments = default;
		attachments = default;
		width = pass.fragmentInfoWidth;
		height = pass.fragmentInfoHeight;
		volumeDepth = pass.fragmentInfoVolumeDepth;
		samples = pass.fragmentInfoSamples;
		hasDepth = pass.fragmentInfoHasDepth;
		hasFoveatedRasterization = pass.hasFoveatedRasterization;
		loadAudit = default;
		storeAudit = default;
		breakAudit = new PassBreakAudit(PassBreakReason.NotOptimized, -1);
		ReadOnlySpan<PassFragmentData> readOnlySpan = pass.Fragments(ctx);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ref readonly PassFragmentData data = ref readOnlySpan[i];
			fragments.Add(in data);
		}
		readOnlySpan = pass.FragmentInputs(ctx);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ref readonly PassFragmentData data2 = ref readOnlySpan[i];
			fragments.Add(in data2);
		}
		TryMergeNativeSubPass(ctx, ref this, ref pass);
	}

	public SubPassFlags GetSubPassFlagForMerging()
	{
		if (!hasDepth)
		{
			throw new Exception("SubPassFlag for merging can not be determined if native pass doesn't have a depth attachment");
		}
		return SubPassFlags.ReadOnlyDepth;
	}

	public void Clear()
	{
		firstGraphPass = 0;
		numGraphPasses = 0;
		attachments.Clear();
		fragments.Clear();
		loadAudit.Clear();
		storeAudit.Clear();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool IsValid()
	{
		return numGraphPasses > 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly ReadOnlySpan<PassData> GraphPasses(CompilerContextData ctx)
	{
		if (lastGraphPass - firstGraphPass + 1 == numGraphPasses)
		{
			return NativeListExtensions.MakeReadOnlySpan(ref ctx.passData, firstGraphPass, numGraphPasses);
		}
		NativeArray<PassData> source = new NativeArray<PassData>(numGraphPasses, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
		int i = firstGraphPass;
		int num = 0;
		for (; i < lastGraphPass + 1; i++)
		{
			PassData value = ctx.passData[i];
			if (!value.culled)
			{
				source[num++] = value;
			}
		}
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly void GetGraphPassNames(CompilerContextData ctx, DynamicArray<Name> dest)
	{
		ReadOnlySpan<PassData> readOnlySpan = GraphPasses(ctx);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			dest.Add(readOnlySpan[i].GetName(ctx));
		}
	}

	public static PassBreakAudit CanMerge(CompilerContextData contextData, int activeNativePassId, int passIdToMerge)
	{
		ref PassData reference = ref contextData.passData.ElementAt(passIdToMerge);
		if (reference.type != RenderGraphPassType.Raster)
		{
			return new PassBreakAudit(PassBreakReason.NonRasterPass, passIdToMerge);
		}
		ref NativePassData reference2 = ref contextData.nativePassData.ElementAt(activeNativePassId);
		FixedAttachmentArray<PassFragmentData> fixedAttachmentArray;
		if (reference.numFragments > 0 || reference.numFragmentInputs > 0)
		{
			if (reference2.width != reference.fragmentInfoWidth || reference2.height != reference.fragmentInfoHeight || reference2.volumeDepth != reference.fragmentInfoVolumeDepth || reference2.samples != reference.fragmentInfoSamples)
			{
				return new PassBreakAudit(PassBreakReason.TargetSizeMismatch, passIdToMerge);
			}
			if (reference2.hasDepth && reference.fragmentInfoHasDepth)
			{
				ref PassFragmentData reference3 = ref contextData.fragmentData.ElementAt(reference.firstFragment);
				fixedAttachmentArray = reference2.fragments;
				int index = fixedAttachmentArray[0].resource.index;
				ResourceHandle resource = reference3.resource;
				if (index != resource.index)
				{
					return new PassBreakAudit(PassBreakReason.DifferentDepthTextures, passIdToMerge);
				}
			}
			if (reference2.hasFoveatedRasterization != reference.hasFoveatedRasterization)
			{
				return new PassBreakAudit(PassBreakReason.FRStateMismatch, passIdToMerge);
			}
		}
		ReadOnlySpan<PassInputData> readOnlySpan = reference.Inputs(contextData);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ResourceHandle resource2 = readOnlySpan[i].resource;
			int writePassId = contextData.resources[resource2].writePassId;
			if (writePassId >= reference2.firstGraphPass && writePassId < reference2.lastGraphPass + 1 && !reference.IsUsedAsFragment(resource2, contextData))
			{
				return new PassBreakAudit(PassBreakReason.NextPassReadsTexture, passIdToMerge);
			}
		}
		FixedAttachmentArray<PassFragmentData> fixedAttachmentArray2 = default;
		fixedAttachmentArray = reference2.fragments;
		int num = 8 - fixedAttachmentArray.size;
		ReadOnlySpan<PassFragmentData> readOnlySpan2 = reference.Fragments(contextData);
		for (int i = 0; i < readOnlySpan2.Length; i++)
		{
			ref readonly PassFragmentData reference4 = ref readOnlySpan2[i];
			bool flag = false;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				fixedAttachmentArray = reference2.fragments;
				if (num3 >= fixedAttachmentArray.size)
				{
					break;
				}
				fixedAttachmentArray = reference2.fragments;
				if (PassFragmentData.SameSubResource(in fixedAttachmentArray[num2], in reference4))
				{
					flag = true;
					break;
				}
				num2++;
			}
			if (!flag)
			{
				if (num == 0)
				{
					return new PassBreakAudit(PassBreakReason.AttachmentLimitReached, passIdToMerge);
				}
				fixedAttachmentArray2.Add(in reference4);
				num--;
			}
			for (int j = reference2.firstGraphPass; j <= reference2.lastGraphPass; j++)
			{
				ref PassData reference5 = ref contextData.passData.ElementAt(j);
				readOnlySpan = reference5.Inputs(contextData);
				for (int k = 0; k < readOnlySpan.Length; k++)
				{
					ref readonly PassInputData reference6 = ref readOnlySpan[k];
					if (reference6.resource.index == reference4.resource.index && !reference5.IsUsedAsFragment(reference6.resource, contextData))
					{
						return new PassBreakAudit(PassBreakReason.NextPassTargetsTexture, passIdToMerge);
					}
				}
			}
		}
		readOnlySpan2 = reference.FragmentInputs(contextData);
		for (int i = 0; i < readOnlySpan2.Length; i++)
		{
			ref readonly PassFragmentData reference7 = ref readOnlySpan2[i];
			bool flag2 = false;
			int num4 = 0;
			while (true)
			{
				int num5 = num4;
				fixedAttachmentArray = reference2.fragments;
				if (num5 >= fixedAttachmentArray.size)
				{
					break;
				}
				fixedAttachmentArray = reference2.fragments;
				if (PassFragmentData.SameSubResource(in fixedAttachmentArray[num4], in reference7))
				{
					flag2 = true;
					break;
				}
				num4++;
			}
			if (!flag2)
			{
				if (num == 0)
				{
					return new PassBreakAudit(PassBreakReason.AttachmentLimitReached, passIdToMerge);
				}
				fixedAttachmentArray2.Add(in reference7);
				num--;
			}
		}
		if (!CanMergeNativeSubPass(contextData, reference2, reference) && reference2.numGraphPasses + 1 > 8)
		{
			return new PassBreakAudit(PassBreakReason.SubPassLimitReached, passIdToMerge);
		}
		return new PassBreakAudit(PassBreakReason.Merged, passIdToMerge);
	}

	private static bool CanMergeNativeSubPass(CompilerContextData contextData, NativePassData nativePass, PassData passToMerge)
	{
		if (passToMerge.numFragments == 0 && passToMerge.numFragmentInputs == 0)
		{
			return true;
		}
		if (nativePass.numNativeSubPasses == 0)
		{
			return false;
		}
		ref FixedAttachmentArray<PassFragmentData> reference = ref nativePass.fragments;
		ref SubPassDescriptor reference2 = ref contextData.nativeSubPassData.ElementAt(nativePass.firstNativeSubPass + nativePass.numNativeSubPasses - 1);
		SubPassFlags subPassFlags = SubPassFlags.None;
		if (!passToMerge.fragmentInfoHasDepth && nativePass.hasDepth)
		{
			subPassFlags = nativePass.GetSubPassFlagForMerging();
		}
		int i = 0;
		int num = (passToMerge.fragmentInfoHasDepth ? (-1) : 0);
		int num2 = passToMerge.numFragments + num;
		AttachmentIndexArray colorOutputs = reference2.colorOutputs;
		if (num2 != colorOutputs.Length)
		{
			return false;
		}
		ReadOnlySpan<PassFragmentData> readOnlySpan = passToMerge.Fragments(contextData);
		int j;
		for (j = 0; j < readOnlySpan.Length; i++, j++)
		{
			ref readonly PassFragmentData reference3 = ref readOnlySpan[j];
			if (passToMerge.fragmentInfoHasDepth && i == 0)
			{
				subPassFlags = ((!reference3.accessFlags.HasFlag(AccessFlags.Write)) ? SubPassFlags.ReadOnlyDepth : SubPassFlags.None);
				continue;
			}
			int num3 = -1;
			int num4 = 0;
			while (true)
			{
				int num5 = num4;
				FixedAttachmentArray<PassFragmentData> fixedAttachmentArray = reference;
				if (num5 >= fixedAttachmentArray.size)
				{
					break;
				}
				fixedAttachmentArray = reference;
				if (PassFragmentData.SameSubResource(in fixedAttachmentArray[num4], in reference3))
				{
					num3 = num4;
					break;
				}
				num4++;
			}
			if (num3 >= 0)
			{
				int num6 = num3;
				colorOutputs = reference2.colorOutputs;
				if (num6 == colorOutputs[i + num])
				{
					continue;
				}
			}
			return false;
		}
		int num7 = 0;
		int numFragmentInputs = passToMerge.numFragmentInputs;
		colorOutputs = reference2.inputs;
		if (numFragmentInputs != colorOutputs.Length)
		{
			return false;
		}
		readOnlySpan = passToMerge.FragmentInputs(contextData);
		j = 0;
		while (j < readOnlySpan.Length)
		{
			ref readonly PassFragmentData y = ref readOnlySpan[j];
			int num8 = -1;
			int num9 = 0;
			while (true)
			{
				int num10 = num9;
				FixedAttachmentArray<PassFragmentData> fixedAttachmentArray = reference;
				if (num10 >= fixedAttachmentArray.size)
				{
					break;
				}
				fixedAttachmentArray = reference;
				if (PassFragmentData.SameSubResource(in fixedAttachmentArray[num9], in y))
				{
					num8 = num9;
					break;
				}
				num9++;
			}
			if (num8 >= 0)
			{
				int num11 = num8;
				colorOutputs = reference2.inputs;
				if (num11 == colorOutputs[num7])
				{
					num7++;
					j++;
					continue;
				}
			}
			return false;
		}
		return subPassFlags == reference2.flags;
	}

	public static void TryMergeNativeSubPass(CompilerContextData contextData, ref NativePassData nativePass, ref PassData passToMerge)
	{
		ref FixedAttachmentArray<PassFragmentData> reference = ref nativePass.fragments;
		NativePassData nativePassData = nativePass;
		if (nativePassData.numNativeSubPasses == 0)
		{
			FixedAttachmentArray<PassFragmentData> fixedAttachmentArray = nativePassData.fragments;
			if (fixedAttachmentArray.size > 0)
			{
				nativePass.firstNativeSubPass = contextData.nativeSubPassData.Length;
			}
		}
		SubPassDescriptor value = default;
		if (passToMerge.numFragments == 0 && passToMerge.numFragmentInputs == 0)
		{
			passToMerge.nativeSubPassIndex = nativePass.numNativeSubPasses - 1;
			passToMerge.beginNativeSubpass = false;
			return;
		}
		if (!passToMerge.fragmentInfoHasDepth && nativePass.hasDepth)
		{
			value.flags = nativePass.GetSubPassFlagForMerging();
		}
		int num = 0;
		int num2 = (passToMerge.fragmentInfoHasDepth ? (-1) : 0);
		value.colorOutputs = new AttachmentIndexArray(passToMerge.numFragments + num2);
		ReadOnlySpan<PassFragmentData> readOnlySpan = passToMerge.Fragments(contextData);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ref readonly PassFragmentData reference2 = ref readOnlySpan[i];
			if (passToMerge.fragmentInfoHasDepth && num == 0)
			{
				value.flags = ((!reference2.accessFlags.HasFlag(AccessFlags.Write)) ? SubPassFlags.ReadOnlyDepth : SubPassFlags.None);
			}
			else
			{
				int value2 = -1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					FixedAttachmentArray<PassFragmentData> fixedAttachmentArray = reference;
					if (num4 >= fixedAttachmentArray.size)
					{
						break;
					}
					fixedAttachmentArray = reference;
					if (PassFragmentData.SameSubResource(in fixedAttachmentArray[num3], in reference2))
					{
						value2 = num3;
						break;
					}
					num3++;
				}
				value.colorOutputs[num + num2] = value2;
			}
			num++;
		}
		int num5 = 0;
		value.inputs = new AttachmentIndexArray(passToMerge.numFragmentInputs);
		readOnlySpan = passToMerge.FragmentInputs(contextData);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ref readonly PassFragmentData y = ref readOnlySpan[i];
			int value3 = -1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				FixedAttachmentArray<PassFragmentData> fixedAttachmentArray = reference;
				if (num7 >= fixedAttachmentArray.size)
				{
					break;
				}
				fixedAttachmentArray = reference;
				if (PassFragmentData.SameSubResource(in fixedAttachmentArray[num6], in y))
				{
					value3 = num6;
					break;
				}
				num6++;
			}
			value.inputs[num5] = value3;
			num5++;
		}
		if (nativePass.numNativeSubPasses == 0 || !NativePassCompiler.IsSameNativeSubPass(ref value, ref contextData.nativeSubPassData.ElementAt(nativePass.firstNativeSubPass + nativePass.numNativeSubPasses - 1)))
		{
			contextData.nativeSubPassData.Add(in value);
			NativeListExtensions.LastIndex(ref contextData.nativeSubPassData);
			nativePass.numNativeSubPasses++;
			passToMerge.beginNativeSubpass = true;
		}
		else
		{
			passToMerge.beginNativeSubpass = false;
		}
		passToMerge.nativeSubPassIndex = nativePass.numNativeSubPasses - 1;
	}

	private void AddDepthAttachmentFirstDuringMerge(CompilerContextData contextData, in PassFragmentData depthAttachment)
	{
		fragments.Add(in depthAttachment);
		hasDepth = true;
		int size = fragments.size;
		if (size == 1)
		{
			return;
		}
		int num = size - 1;
		ref PassFragmentData reference = ref fragments[0];
		ref PassFragmentData reference2 = ref fragments[num];
		PassFragmentData passFragmentData = fragments[num];
		PassFragmentData passFragmentData2 = fragments[0];
		reference = passFragmentData;
		reference2 = passFragmentData2;
		SubPassFlags subPassFlagForMerging = GetSubPassFlagForMerging();
		for (int i = firstNativeSubPass; i < firstNativeSubPass + numNativeSubPasses; i++)
		{
			ref SubPassDescriptor reference3 = ref contextData.nativeSubPassData.ElementAt(i);
			reference3.flags = subPassFlagForMerging;
			for (int j = 0; j < reference3.colorOutputs.Length; j++)
			{
				if (reference3.colorOutputs[j] == 0)
				{
					reference3.colorOutputs[j] = num;
				}
			}
			for (int k = 0; k < reference3.inputs.Length; k++)
			{
				if (reference3.inputs[k] == 0)
				{
					reference3.inputs[k] = num;
				}
			}
		}
	}

	public static PassBreakAudit TryMerge(CompilerContextData contextData, int activeNativePassId, int passIdToMerge)
	{
		PassBreakAudit result = CanMerge(contextData, activeNativePassId, passIdToMerge);
		if (result.reason != PassBreakReason.Merged)
		{
			return result;
		}
		ref PassData reference = ref contextData.passData.ElementAt(passIdToMerge);
		ref NativePassData reference2 = ref contextData.nativePassData.ElementAt(activeNativePassId);
		reference.mergeState = PassMergeState.SubPass;
		if (reference.nativePassIndex >= 0)
		{
			contextData.nativePassData.ElementAt(reference.nativePassIndex).Clear();
		}
		reference.nativePassIndex = activeNativePassId;
		reference2.numGraphPasses++;
		reference2.lastGraphPass = passIdToMerge;
		if (!reference2.hasDepth && reference.fragmentInfoHasDepth)
		{
			reference2.AddDepthAttachmentFirstDuringMerge(contextData, contextData.fragmentData[reference.firstFragment]);
		}
		ReadOnlySpan<PassFragmentData> readOnlySpan = reference.Fragments(contextData);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ref readonly PassFragmentData reference3 = ref readOnlySpan[i];
			bool flag = false;
			for (int j = 0; j < reference2.fragments.size; j++)
			{
				ref PassFragmentData reference4 = ref reference2.fragments[j];
				if (PassFragmentData.SameSubResource(in reference4, in reference3))
				{
					reference4.accessFlags |= reference3.accessFlags;
					reference4.resource.version = reference3.resource.version;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				reference2.fragments.Add(in reference3);
			}
		}
		readOnlySpan = reference.FragmentInputs(contextData);
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ref readonly PassFragmentData reference5 = ref readOnlySpan[i];
			bool flag2 = false;
			for (int k = 0; k < reference2.fragments.size; k++)
			{
				ref PassFragmentData reference6 = ref reference2.fragments[k];
				if (PassFragmentData.SameSubResource(in reference6, in reference5))
				{
					reference6.accessFlags |= reference5.accessFlags;
					reference6.resource.version = reference5.resource.version;
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				reference2.fragments.Add(in reference5);
			}
		}
		TryMergeNativeSubPass(contextData, ref reference2, ref reference);
		SetPassStatesForNativePass(contextData, activeNativePassId);
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void SetPassStatesForNativePass(CompilerContextData contextData, int nativePassId)
	{
		ref NativePassData reference = ref contextData.nativePassData.ElementAt(nativePassId);
		if (reference.numGraphPasses > 1)
		{
			contextData.passData.ElementAt(reference.firstGraphPass).mergeState = PassMergeState.Begin;
			int num = reference.lastGraphPass - reference.firstGraphPass + 1;
			for (int i = 1; i < num; i++)
			{
				int index = reference.firstGraphPass + i;
				if (contextData.passData.ElementAt(index).culled)
				{
					contextData.passData.ElementAt(index).mergeState = PassMergeState.None;
				}
				else
				{
					contextData.passData.ElementAt(reference.firstGraphPass + i).mergeState = PassMergeState.SubPass;
				}
			}
			contextData.passData.ElementAt(reference.lastGraphPass).mergeState = PassMergeState.End;
		}
		else
		{
			contextData.passData.ElementAt(reference.firstGraphPass).mergeState = PassMergeState.None;
		}
	}
}
