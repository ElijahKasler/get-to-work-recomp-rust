using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace System.Windows.Forms;

internal class Win32DnD
{
	internal delegate uint QueryInterfaceDelegate(IntPtr @this, ref Guid riid, IntPtr ppvObject);

	internal delegate uint AddRefDelegate(IntPtr @this);

	internal delegate uint ReleaseDelegate(IntPtr @this);

	internal delegate uint GetDataDelegate(IntPtr @this, ref FORMATETC pformatetcIn, IntPtr pmedium);

	internal delegate uint GetDataHereDelegate(IntPtr @this, ref FORMATETC pformatetc, ref STGMEDIUM pmedium);

	internal delegate uint QueryGetDataDelegate(IntPtr @this, ref FORMATETC pformatetc);

	internal delegate uint GetCanonicalFormatEtcDelegate(IntPtr @this, ref FORMATETC pformatetcIn, IntPtr pformatetcOut);

	internal delegate uint SetDataDelegate(IntPtr @this, ref FORMATETC pformatetc, ref STGMEDIUM pmedium, bool release);

	internal delegate uint EnumFormatEtcDelegate(IntPtr @this, uint direction, IntPtr ppenumFormatEtc);

	internal delegate uint DAdviseDelegate(IntPtr @this, ref FORMATETC pformatetc, uint advf, IntPtr pAdvSink, ref uint pdwConnection);

	internal delegate uint DUnadviseDelegate(IntPtr @this, uint pdwConnection);

	internal delegate uint EnumDAdviseDelegate(IntPtr @this, IntPtr ppenumAdvise);

	internal delegate uint QueryContinueDragDelegate(IntPtr @this, bool fEscapePressed, uint grfkeyState);

	internal delegate uint GiveFeedbackDelegate(IntPtr @this, uint pdwEffect);

	internal delegate uint DragEnterDelegate(IntPtr @this, IntPtr pDataObj, uint grfkeyState, IntPtr pt_x, IntPtr pt_y, IntPtr pdwEffect);

	internal delegate uint DragOverDelegate(IntPtr @this, uint grfkeyState, IntPtr pt_x, IntPtr pt_y, IntPtr pdwEffect);

	internal delegate uint DragLeaveDelegate(IntPtr @this);

	internal delegate uint DropDelegate(IntPtr @this, IntPtr pDataObj, uint grfkeyState, IntPtr pt_x, IntPtr pt_y, IntPtr pdwEffect);

	internal struct FORMATETC
	{
		[MarshalAs(UnmanagedType.U2)]
		internal ClipboardFormats cfFormat;

		internal IntPtr ptd;

		internal DVASPECT dwAspect;

		internal int lindex;

		internal TYMED tymed;
	}

	internal struct STGMEDIUM
	{
		internal TYMED tymed;

		internal IntPtr hHandle;

		internal IntPtr pUnkForRelease;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct DROPFILES
	{
		internal uint pFiles;

		internal uint pt_x;

		internal uint pt_y;

		internal bool fNC;

		internal bool fWide;

		internal string pText;
	}

	internal enum DVASPECT
	{
		DVASPECT_CONTENT = 1,
		DVASPECT_THUMBNAIL = 2,
		DVASPECT_ICON = 4,
		DVASPECT_DOCPRINT = 8
	}

	internal enum TYMED
	{
		TYMED_HGLOBAL = 1,
		TYMED_FILE = 2,
		TYMED_ISTREAM = 4,
		TYMED_ISTORAGE = 8,
		TYMED_GDI = 16,
		TYMED_MFPICT = 32,
		TYMED_ENHMF = 64,
		TYMED_NULL = 0
	}

	internal class ComIDataObject
	{
		internal struct DataObjectStruct
		{
			internal IntPtr vtbl;

			internal QueryInterfaceDelegate QueryInterface;

			internal AddRefDelegate AddRef;

			internal ReleaseDelegate Release;

			internal GetDataDelegate GetData;

			internal GetDataHereDelegate GetDataHere;

			internal QueryGetDataDelegate QueryGetData;

			internal GetCanonicalFormatEtcDelegate GetCanonicalFormatEtc;

			internal SetDataDelegate SetData;

			internal EnumFormatEtcDelegate EnumFormatEtc;

			internal DAdviseDelegate DAdvise;

			internal DUnadviseDelegate DUnadvise;

			internal EnumDAdviseDelegate EnumDAdvise;
		}

		internal static STGMEDIUM medium;

		internal static IntPtr GetUnmanaged()
		{
			DataObjectStruct structure = new DataObjectStruct
			{
				QueryInterface = DOQueryInterface,
				AddRef = DOAddRef,
				Release = DORelease,
				GetData = Win32DnD.GetData,
				GetDataHere = Win32DnD.GetDataHere,
				QueryGetData = Win32DnD.QueryGetData,
				GetCanonicalFormatEtc = Win32DnD.GetCanonicalFormatEtc,
				SetData = Win32DnD.SetData,
				EnumFormatEtc = Win32DnD.EnumFormatEtc,
				DAdvise = Win32DnD.DAdvise,
				DUnadvise = Win32DnD.DUnadvise,
				EnumDAdvise = Win32DnD.EnumDAdvise
			};
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DataObjectStruct)));
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
			long num = intPtr.ToInt64();
			num += Marshal.SizeOf(typeof(IntPtr));
			Marshal.WriteIntPtr(intPtr, new IntPtr(num));
			return intPtr;
		}

		internal static void ReleaseUnmanaged(IntPtr data_object_ptr)
		{
			Marshal.FreeHGlobal(data_object_ptr);
		}

		internal static uint QueryInterface(IntPtr @this, ref Guid riid, IntPtr ppvObject)
		{
			try
			{
				if (IID_IUnknown.Equals(riid) || IID_IDataObject.Equals(riid))
				{
					Marshal.WriteIntPtr(ppvObject, @this);
					return 0u;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Got exception {0}", ex.Message);
			}
			Marshal.WriteIntPtr(ppvObject, IntPtr.Zero);
			return 2147500034u;
		}

		internal static uint AddRef(IntPtr @this)
		{
			return 1u;
		}

		internal static uint Release(IntPtr @this)
		{
			return 0u;
		}

		internal static uint GetData(IntPtr this_, ref FORMATETC pformatetcIn, IntPtr pmedium)
		{
			int num = FindFormat(pformatetcIn);
			if (num != -1)
			{
				medium.tymed = TYMED.TYMED_HGLOBAL;
				medium.hHandle = XplatUIWin32.DupGlobalMem(((STGMEDIUM)DragMediums[num]).hHandle);
				medium.pUnkForRelease = IntPtr.Zero;
				try
				{
					Marshal.StructureToPtr(medium, pmedium, fDeleteOld: false);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error: {0}", ex.Message);
				}
				return 0u;
			}
			return 2147745892u;
		}

		internal static uint GetDataHere(IntPtr @this, ref FORMATETC pformatetc, ref STGMEDIUM pmedium)
		{
			return 2147745892u;
		}

		internal static uint QueryGetData(IntPtr @this, ref FORMATETC pformatetc)
		{
			if (FindFormat(pformatetc) != -1)
			{
				return 0u;
			}
			return 2147745892u;
		}

		internal static uint GetCanonicalFormatEtc(IntPtr @this, ref FORMATETC pformatetcIn, IntPtr pformatetcOut)
		{
			Marshal.WriteIntPtr(pformatetcOut, Marshal.SizeOf(typeof(IntPtr)), IntPtr.Zero);
			return 2147500033u;
		}

		internal static uint SetData(IntPtr this_, ref FORMATETC pformatetc, ref STGMEDIUM pmedium, bool release)
		{
			return 2147500033u;
		}

		internal static uint EnumFormatEtc(IntPtr this_, uint direction, IntPtr ppenumFormatEtc)
		{
			if (direction == 1)
			{
				IntPtr ppenumFormatEtc2 = IntPtr.Zero;
				DragFormatArray = new FORMATETC[DragFormats.Count];
				for (int i = 0; i < DragFormats.Count; i++)
				{
					DragFormatArray[i] = (FORMATETC)DragFormats[i];
				}
				Win32SHCreateStdEnumFmtEtc((uint)DragFormatArray.Length, DragFormatArray, ref ppenumFormatEtc2);
				Marshal.WriteIntPtr(ppenumFormatEtc, ppenumFormatEtc2);
				return 0u;
			}
			return 2147500033u;
		}

		internal static uint DAdvise(IntPtr this_, ref FORMATETC pformatetc, uint advf, IntPtr pAdvSink, ref uint pdwConnection)
		{
			return 2147745795u;
		}

		internal static uint DUnadvise(IntPtr this_, uint pdwConnection)
		{
			return 2147745795u;
		}

		internal static uint EnumDAdvise(IntPtr this_, IntPtr ppenumAdvise)
		{
			return 2147745795u;
		}
	}

	internal class ComIDataObjectUnmanaged
	{
		internal struct IDataObjectUnmanaged
		{
			internal IntPtr QueryInterface;

			internal IntPtr AddRef;

			internal IntPtr Release;

			internal IntPtr GetData;

			internal IntPtr GetDataHere;

			internal IntPtr QueryGetData;

			internal IntPtr GetCanonicalFormatEtc;

			internal IntPtr SetData;

			internal IntPtr EnumFormatEtc;

			internal IntPtr DAdvise;

			internal IntPtr DUnadvise;

			internal IntPtr EnumDAdvise;
		}

		private static bool Initialized;

		private static MethodInfo GetDataMethod;

		private static MethodInfo QueryGetDataMethod;

		private static object[] MethodArguments;

		private IDataObjectUnmanaged vtbl;

		private IntPtr @this;

		internal ComIDataObjectUnmanaged(IntPtr data_object_ptr)
		{
			if (!Initialized)
			{
				Initialize();
			}
			vtbl = default;
			this.@this = data_object_ptr;
			try
			{
				vtbl = (IDataObjectUnmanaged)Marshal.PtrToStructure(Marshal.ReadIntPtr(data_object_ptr), typeof(IDataObjectUnmanaged));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception {0}", ex.Message);
			}
		}

		private static void Initialize()
		{
			if (!Initialized)
			{
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = "XplatUIWin32.FuncPtrInterface";
				AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
				MethodArguments = new object[6];
				GetDataMethod = CreateFuncPtrInterface(assembly, "GetData", typeof(uint), 3);
				QueryGetDataMethod = CreateFuncPtrInterface(assembly, "QueryGetData", typeof(uint), 2);
				Initialized = true;
			}
		}

		internal uint QueryInterface(Guid riid, IntPtr ppvObject)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid)));
			Marshal.StructureToPtr(riid, intPtr, fDeleteOld: false);
			MethodArguments[0] = vtbl.QueryInterface;
			MethodArguments[1] = this.@this;
			MethodArguments[2] = intPtr;
			MethodArguments[3] = ppvObject;
			uint result;
			try
			{
				result = (uint)GetDataMethod.Invoke(null, MethodArguments);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Caught exception {0}", ex.Message);
				result = 2147500037u;
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal uint AddRef()
		{
			return 1u;
		}

		internal uint Release()
		{
			return 0u;
		}

		internal uint GetData(FORMATETC pformatetcIn, ref STGMEDIUM pmedium)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FORMATETC)));
			Marshal.StructureToPtr(pformatetcIn, intPtr, fDeleteOld: false);
			IntPtr intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(STGMEDIUM)));
			MethodArguments[0] = vtbl.GetData;
			MethodArguments[1] = this.@this;
			MethodArguments[2] = intPtr;
			MethodArguments[3] = intPtr2;
			uint result;
			try
			{
				result = (uint)GetDataMethod.Invoke(null, MethodArguments);
				Marshal.PtrToStructure(intPtr2, pmedium);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Caught exception {0}", ex.Message);
				result = 2147500037u;
			}
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			return result;
		}

		internal uint GetDataHere(FORMATETC pformatetc, ref STGMEDIUM pmedium)
		{
			return 2147500033u;
		}

		internal uint QueryGetData(FORMATETC pformatetc)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FORMATETC)));
			Marshal.StructureToPtr(pformatetc, intPtr, fDeleteOld: false);
			MethodArguments[0] = vtbl.GetData;
			MethodArguments[1] = this.@this;
			MethodArguments[2] = intPtr;
			uint result;
			try
			{
				result = (uint)QueryGetDataMethod.Invoke(null, MethodArguments);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Caught exception {0}", ex.Message);
				result = 2147500037u;
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal uint GetCanonicalFormatEtc(FORMATETC pformatetcIn, ref FORMATETC pformatetcOut)
		{
			return 2147500033u;
		}

		internal uint SetData(FORMATETC pformatetc, STGMEDIUM pmedium, bool release)
		{
			return 2147500033u;
		}

		internal uint EnumFormatEtc(uint direction, IntPtr ppenumFormatEtc)
		{
			return 2147500033u;
		}

		internal uint DAdvise(FORMATETC pformatetc, uint advf, IntPtr pAdvSink, ref uint pdwConnection)
		{
			return 2147745795u;
		}

		internal uint DUnadvise(uint pdwConnection)
		{
			return 2147745795u;
		}

		internal uint EnumDAdvise(IntPtr ppenumAdvise)
		{
			return 2147745795u;
		}
	}

	internal class ComIDropSource
	{
		internal struct IDropSource
		{
			internal IntPtr vtbl;

			internal IntPtr Window;

			internal QueryInterfaceDelegate QueryInterface;

			internal AddRefDelegate AddRef;

			internal ReleaseDelegate Release;

			internal QueryContinueDragDelegate QueryContinueDrag;

			internal GiveFeedbackDelegate GiveFeedback;
		}

		internal static IntPtr GetUnmanaged(IntPtr Window)
		{
			IDropSource structure = new IDropSource
			{
				QueryInterface = DSQueryInterface,
				AddRef = DSAddRef,
				Release = DSRelease,
				QueryContinueDrag = Win32DnD.QueryContinueDrag,
				GiveFeedback = Win32DnD.GiveFeedback,
				Window = Window
			};
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
			long num = intPtr.ToInt64();
			num += 2 * Marshal.SizeOf(typeof(IntPtr));
			Marshal.WriteIntPtr(intPtr, new IntPtr(num));
			return intPtr;
		}

		internal static void ReleaseUnmanaged(IntPtr drop_source_ptr)
		{
			Marshal.FreeHGlobal(drop_source_ptr);
		}

		internal static uint QueryInterface(IntPtr @this, ref Guid riid, IntPtr ppvObject)
		{
			try
			{
				if (IID_IUnknown.Equals(riid) || IID_IDropSource.Equals(riid))
				{
					Marshal.WriteIntPtr(ppvObject, @this);
					return 0u;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Got exception {0}", ex.Message);
			}
			Marshal.WriteIntPtr(ppvObject, IntPtr.Zero);
			return 2147500034u;
		}

		internal static uint AddRef(IntPtr @this)
		{
			return 1u;
		}

		internal static uint Release(IntPtr @this)
		{
			return 0u;
		}

		internal static uint QueryContinueDrag(IntPtr @this, bool fEscapePressed, uint grfkeyState)
		{
			IntPtr handle = Marshal.ReadIntPtr(@this, Marshal.SizeOf(typeof(IntPtr)));
			if (fEscapePressed)
			{
				DragContinueEventArgs.drag_action = DragAction.Cancel;
			}
			else if ((grfkeyState & 0x13) == 0)
			{
				DragContinueEventArgs.drag_action = DragAction.Drop;
			}
			else
			{
				DragContinueEventArgs.drag_action = DragAction.Continue;
			}
			DragContinueEventArgs.escape_pressed = fEscapePressed;
			DragContinueEventArgs.key_state = (int)grfkeyState;
			Control.FromHandle(handle).DndContinueDrag(DragContinueEventArgs);
			if (DragContinueEventArgs.drag_action == DragAction.Cancel)
			{
				return 262401u;
			}
			if (DragContinueEventArgs.drag_action == DragAction.Drop)
			{
				return 262400u;
			}
			return 0u;
		}

		internal static uint GiveFeedback(IntPtr @this, uint pdwEffect)
		{
			IntPtr handle = Marshal.ReadIntPtr(@this, Marshal.SizeOf(typeof(IntPtr)));
			DragFeedbackEventArgs.effect = (DragDropEffects)pdwEffect;
			DragFeedbackEventArgs.use_default_cursors = true;
			Control.FromHandle(handle).DndFeedback(DragFeedbackEventArgs);
			if (DragFeedbackEventArgs.use_default_cursors)
			{
				return 262402u;
			}
			return 0u;
		}
	}

	internal class ComIDropTarget
	{
		internal struct IDropTarget
		{
			internal IntPtr vtbl;

			internal IntPtr Window;

			internal uint ref_count;

			internal QueryInterfaceDelegate QueryInterface;

			internal AddRefDelegate AddRef;

			internal ReleaseDelegate Release;

			internal DragEnterDelegate DragEnter;

			internal DragOverDelegate DragOver;

			internal DragLeaveDelegate DragLeave;

			internal DropDelegate Drop;
		}

		internal static IntPtr GetUnmanaged(IntPtr Window)
		{
			IDropTarget structure = new IDropTarget
			{
				QueryInterface = DTQueryInterface,
				AddRef = DTAddRef,
				Release = DTRelease,
				DragEnter = Win32DnD.DragEnter,
				DragOver = Win32DnD.DragOver,
				DragLeave = Win32DnD.DragLeave,
				Drop = Win32DnD.Drop,
				Window = Window
			};
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
			long num = intPtr.ToInt64();
			num += 2 * Marshal.SizeOf(typeof(IntPtr)) + Marshal.SizeOf(typeof(uint));
			Marshal.WriteIntPtr(intPtr, new IntPtr(num));
			return intPtr;
		}

		internal static void ReleaseUnmanaged(IntPtr drop_target_ptr)
		{
			Marshal.FreeHGlobal(drop_target_ptr);
		}

		internal static uint QueryInterface(IntPtr @this, ref Guid riid, IntPtr ppvObject)
		{
			try
			{
				if (IID_IUnknown.Equals(riid) || IID_IDropTarget.Equals(riid))
				{
					Marshal.WriteIntPtr(ppvObject, @this);
					return 0u;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Got exception {0}", ex.Message);
			}
			Marshal.WriteIntPtr(ppvObject, IntPtr.Zero);
			return 2147500034u;
		}

		internal static uint AddRef(IntPtr @this)
		{
			uint num = (uint)Marshal.ReadInt32(@this, Marshal.SizeOf(typeof(IntPtr)) * 2);
			Marshal.WriteInt32(@this, Marshal.SizeOf(typeof(IntPtr)) * 2, (int)(num + 1));
			return num + 1;
		}

		internal static uint Release(IntPtr @this)
		{
			uint num = (uint)Marshal.ReadInt32(@this, Marshal.SizeOf(typeof(IntPtr)) * 2);
			Marshal.WriteInt32(@this, Marshal.SizeOf(typeof(IntPtr)) * 2, (int)(num - 1));
			if (num == 1)
			{
				ReleaseUnmanaged(@this);
			}
			return num - 1;
		}

		internal static uint DragEnter(IntPtr @this, IntPtr pDataObj, uint grfkeyState, IntPtr pt_x, IntPtr pt_y, IntPtr pdwEffect)
		{
			IntPtr handle = Marshal.ReadIntPtr(@this, Marshal.SizeOf(typeof(IntPtr)));
			DragDropEventArgs.x = pt_x.ToInt32();
			DragDropEventArgs.y = pt_y.ToInt32();
			DragDropEventArgs.allowed_effect = (DragDropEffects)Marshal.ReadIntPtr(pdwEffect).ToInt32();
			DragDropEventArgs.current_effect = DragDropEventArgs.AllowedEffect;
			DragDropEventArgs.keystate = (int)grfkeyState;
			Control.FromHandle(handle).DndEnter(DragDropEventArgs);
			Marshal.WriteInt32(pdwEffect, (int)DragDropEventArgs.Effect);
			return 0u;
		}

		internal static uint DragOver(IntPtr @this, uint grfkeyState, IntPtr pt_x, IntPtr pt_y, IntPtr pdwEffect)
		{
			IntPtr handle = Marshal.ReadIntPtr(@this, Marshal.SizeOf(typeof(IntPtr)));
			DragDropEventArgs.x = pt_x.ToInt32();
			DragDropEventArgs.y = pt_y.ToInt32();
			DragDropEventArgs.allowed_effect = (DragDropEffects)Marshal.ReadIntPtr(pdwEffect).ToInt32();
			DragDropEventArgs.current_effect = DragDropEventArgs.AllowedEffect;
			DragDropEventArgs.keystate = (int)grfkeyState;
			Control.FromHandle(handle).DndOver(DragDropEventArgs);
			Marshal.WriteInt32(pdwEffect, (int)DragDropEventArgs.Effect);
			return 0u;
		}

		internal static uint DragLeave(IntPtr @this)
		{
			Control.FromHandle(Marshal.ReadIntPtr(@this, Marshal.SizeOf(typeof(IntPtr)))).DndLeave(EventArgs.Empty);
			return 0u;
		}

		internal static uint Drop(IntPtr @this, IntPtr pDataObj, uint grfkeyState, IntPtr pt_x, IntPtr pt_y, IntPtr pdwEffect)
		{
			IntPtr handle = Marshal.ReadIntPtr(@this, Marshal.SizeOf(typeof(IntPtr)));
			DragDropEventArgs.x = pt_x.ToInt32();
			DragDropEventArgs.y = pt_y.ToInt32();
			DragDropEventArgs.allowed_effect = (DragDropEffects)Marshal.ReadIntPtr(pdwEffect).ToInt32();
			DragDropEventArgs.current_effect = DragDropEventArgs.AllowedEffect;
			DragDropEventArgs.keystate = (int)grfkeyState;
			Control control = Control.FromHandle(handle);
			if (control != null)
			{
				control.DndDrop(DragDropEventArgs);
				return 1u;
			}
			Marshal.WriteInt32(pdwEffect, (int)DragDropEventArgs.Effect);
			return 0u;
		}
	}

	private const uint DATADIR_GET = 1u;

	private const uint S_OK = 0u;

	private const uint S_FALSE = 1u;

	private const uint DRAGDROP_S_DROP = 262400u;

	private const uint DRAGDROP_S_CANCEL = 262401u;

	private const uint DRAGDROP_S_USEDEFAULTCURSORS = 262402u;

	private const uint E_NOTIMPL = 2147500033u;

	private const uint E_NOINTERFACE = 2147500034u;

	private const uint E_FAIL = 2147500037u;

	private const uint OLE_E_ADVISENOTSUPPORTED = 2147745795u;

	private const uint DV_E_FORMATETC = 2147745892u;

	private static QueryInterfaceDelegate DOQueryInterface;

	private static AddRefDelegate DOAddRef;

	private static ReleaseDelegate DORelease;

	private static GetDataDelegate GetData;

	private static GetDataHereDelegate GetDataHere;

	private static QueryGetDataDelegate QueryGetData;

	private static GetCanonicalFormatEtcDelegate GetCanonicalFormatEtc;

	private static SetDataDelegate SetData;

	private static EnumFormatEtcDelegate EnumFormatEtc;

	private static DAdviseDelegate DAdvise;

	private static DUnadviseDelegate DUnadvise;

	private static EnumDAdviseDelegate EnumDAdvise;

	private static QueryInterfaceDelegate DSQueryInterface;

	private static AddRefDelegate DSAddRef;

	private static ReleaseDelegate DSRelease;

	private static QueryContinueDragDelegate QueryContinueDrag;

	private static GiveFeedbackDelegate GiveFeedback;

	private static QueryInterfaceDelegate DTQueryInterface;

	private static AddRefDelegate DTAddRef;

	private static ReleaseDelegate DTRelease;

	private static DragEnterDelegate DragEnter;

	private static DragOverDelegate DragOver;

	private static DragLeaveDelegate DragLeave;

	private static DropDelegate Drop;

	private static DragEventArgs DragDropEventArgs;

	private static GiveFeedbackEventArgs DragFeedbackEventArgs;

	private static QueryContinueDragEventArgs DragContinueEventArgs;

	private static ArrayList DragFormats;

	private static FORMATETC[] DragFormatArray;

	private static ArrayList DragMediums;

	private static readonly Guid IID_IUnknown;

	private static readonly Guid IID_IDataObject;

	private static readonly Guid IID_IDropSource;

	private static readonly Guid IID_IDropTarget;

	static Win32DnD()
	{
		IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
		IID_IDataObject = new Guid("0000010e-0000-0000-C000-000000000046");
		IID_IDropSource = new Guid("00000121-0000-0000-C000-000000000046");
		IID_IDropTarget = new Guid("00000122-0000-0000-C000-000000000046");
		Win32OleInitialize(IntPtr.Zero);
		DragDropEventArgs = new DragEventArgs(new DataObject(DataFormats.FileDrop, new string[0]), 0, 0, 0, DragDropEffects.None, DragDropEffects.None);
		DragFeedbackEventArgs = new GiveFeedbackEventArgs(DragDropEffects.None, useDefaultCursors: true);
		DragContinueEventArgs = new QueryContinueDragEventArgs(0, escapePressed: false, DragAction.Continue);
		DragFormats = new ArrayList();
		DragFormatArray = new FORMATETC[0];
		DragMediums = new ArrayList();
		DOQueryInterface = ComIDataObject.QueryInterface;
		DOAddRef = ComIDataObject.AddRef;
		DORelease = ComIDataObject.Release;
		GetData = ComIDataObject.GetData;
		GetDataHere = ComIDataObject.GetDataHere;
		QueryGetData = ComIDataObject.QueryGetData;
		GetCanonicalFormatEtc = ComIDataObject.GetCanonicalFormatEtc;
		SetData = ComIDataObject.SetData;
		EnumFormatEtc = ComIDataObject.EnumFormatEtc;
		DAdvise = ComIDataObject.DAdvise;
		DUnadvise = ComIDataObject.DUnadvise;
		EnumDAdvise = ComIDataObject.EnumDAdvise;
		DSQueryInterface = ComIDropSource.QueryInterface;
		DSAddRef = ComIDropSource.AddRef;
		DSRelease = ComIDropSource.Release;
		QueryContinueDrag = ComIDropSource.QueryContinueDrag;
		GiveFeedback = ComIDropSource.GiveFeedback;
		DTQueryInterface = ComIDropTarget.QueryInterface;
		DTAddRef = ComIDropTarget.AddRef;
		DTRelease = ComIDropTarget.Release;
		DragEnter = ComIDropTarget.DragEnter;
		DragOver = ComIDropTarget.DragOver;
		DragLeave = ComIDropTarget.DragLeave;
		Drop = ComIDropTarget.Drop;
	}

	internal static bool HandleWMDropFiles(ref MSG msg)
	{
		IntPtr wParam = msg.wParam;
		int num = Win32DragQueryFile(wParam, -1, IntPtr.Zero, 0);
		string[] array = new string[num];
		StringBuilder stringBuilder = new StringBuilder(256);
		for (int i = 0; i < num; i++)
		{
			Win32DragQueryFile(wParam, i, stringBuilder, stringBuilder.Capacity);
			array[i] = stringBuilder.ToString();
		}
		DragDropEventArgs.Data.SetData(DataFormats.FileDrop, array);
		Control.FromHandle(msg.hwnd).DndDrop(DragDropEventArgs);
		return true;
	}

	private static bool AddFormatAndMedium(ClipboardFormats cfFormat, object data)
	{
		IntPtr intPtr;
		switch (cfFormat)
		{
		case ClipboardFormats.CF_TEXT:
			intPtr = XplatUIWin32.CopyToMoveableMemory(XplatUIWin32.StringToAnsi((string)data));
			break;
		case ClipboardFormats.CF_UNICODETEXT:
			intPtr = XplatUIWin32.CopyToMoveableMemory(XplatUIWin32.StringToUnicode((string)data));
			break;
		case ClipboardFormats.CF_HDROP:
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (data is string || !(data is IEnumerable))
			{
				stringBuilder.Append(data.ToString());
				stringBuilder.Append('\0');
				stringBuilder.Append('\0');
			}
			else
			{
				IEnumerator enumerator = ((IEnumerable)data).GetEnumerator();
				while (enumerator.MoveNext())
				{
					stringBuilder.Append(enumerator.Current.ToString());
					stringBuilder.Append('\0');
				}
				stringBuilder.Append('\0');
			}
			IntPtr intPtr2 = Marshal.StringToHGlobalUni(stringBuilder.ToString());
			int num = (int)XplatUIWin32.Win32GlobalSize(intPtr2);
			intPtr = XplatUIWin32.Win32GlobalAlloc(XplatUIWin32.GAllocFlags.GMEM_MOVEABLE | XplatUIWin32.GAllocFlags.GMEM_SHARE, 20 + num);
			IntPtr intPtr3 = XplatUIWin32.Win32GlobalLock(intPtr);
			Marshal.WriteInt32(intPtr3, 20);
			Marshal.WriteInt32(intPtr3, Marshal.SizeOf(typeof(uint)), 0);
			Marshal.WriteInt32(intPtr3, 2 * Marshal.SizeOf(typeof(uint)), 0);
			Marshal.WriteInt32(intPtr3, 3 * Marshal.SizeOf(typeof(uint)), 0);
			Marshal.WriteInt32(intPtr3, 4 * Marshal.SizeOf(typeof(uint)), 1);
			XplatUIWin32.Win32CopyMemory(new IntPtr((long)intPtr3 + 20), intPtr2, num);
			Marshal.FreeHGlobal(intPtr2);
			XplatUIWin32.Win32GlobalUnlock(intPtr3);
			break;
		}
		case ClipboardFormats.CF_DIB:
			intPtr = XplatUIWin32.CopyToMoveableMemory(XplatUIWin32.ImageToDIB((Image)data));
			break;
		default:
			intPtr = IntPtr.Zero;
			break;
		}
		if (intPtr != IntPtr.Zero)
		{
			STGMEDIUM sTGMEDIUM = new STGMEDIUM
			{
				tymed = TYMED.TYMED_HGLOBAL,
				hHandle = intPtr,
				pUnkForRelease = IntPtr.Zero
			};
			DragMediums.Add(sTGMEDIUM);
			FORMATETC fORMATETC = new FORMATETC
			{
				ptd = IntPtr.Zero,
				dwAspect = DVASPECT.DVASPECT_CONTENT,
				lindex = -1,
				tymed = TYMED.TYMED_HGLOBAL,
				cfFormat = cfFormat
			};
			DragFormats.Add(fORMATETC);
			return true;
		}
		return false;
	}

	private static int FindFormat(FORMATETC pformatetc)
	{
		for (int i = 0; i < DragFormats.Count; i++)
		{
			if (((FORMATETC)DragFormats[i]).cfFormat == pformatetc.cfFormat && ((FORMATETC)DragFormats[i]).dwAspect == pformatetc.dwAspect && (((FORMATETC)DragFormats[i]).tymed & pformatetc.tymed) != TYMED.TYMED_NULL)
			{
				return i;
			}
		}
		return -1;
	}

	private static void BuildFormats(object data)
	{
		DragFormats.Clear();
		DragMediums.Clear();
		if (data is string)
		{
			AddFormatAndMedium(ClipboardFormats.CF_TEXT, data);
			AddFormatAndMedium(ClipboardFormats.CF_UNICODETEXT, data);
			AddFormatAndMedium(ClipboardFormats.CF_HDROP, data);
		}
		else if (data is Bitmap)
		{
			AddFormatAndMedium(ClipboardFormats.CF_DIB, data);
		}
		else if (data is ICollection)
		{
			AddFormatAndMedium(ClipboardFormats.CF_HDROP, data);
		}
		else
		{
			_ = data is ISerializable;
		}
	}

	internal static DragDropEffects StartDrag(IntPtr Window, object data, DragDropEffects allowed)
	{
		BuildFormats(data);
		IntPtr unmanaged = ComIDataObject.GetUnmanaged();
		IntPtr unmanaged2 = ComIDropSource.GetUnmanaged(Window);
		IntPtr pdwEffect = (IntPtr)0;
		Win32DoDragDrop(unmanaged, unmanaged2, (IntPtr)(int)allowed, ref pdwEffect);
		ComIDataObject.ReleaseUnmanaged(unmanaged);
		ComIDropSource.ReleaseUnmanaged(unmanaged2);
		DragFormats.Clear();
		DragFormatArray = null;
		DragMediums.Clear();
		return (DragDropEffects)pdwEffect.ToInt32();
	}

	internal static bool UnregisterDropTarget(IntPtr Window)
	{
		Win32RevokeDragDrop(Window);
		return true;
	}

	internal static bool RegisterDropTarget(IntPtr Window)
	{
		IntPtr unmanaged = ComIDropTarget.GetUnmanaged(Window);
		if (Win32RegisterDragDrop(Window, unmanaged) != 0)
		{
			return false;
		}
		return true;
	}

	private static MethodInfo CreateFuncPtrInterface(AssemblyBuilder assembly, string MethodName, Type ret_type, int param_count)
	{
		TypeBuilder typeBuilder = assembly.DefineDynamicModule("XplatUIWin32.FuncInterface" + MethodName).DefineType("XplatUIWin32.FuncInterface" + MethodName, TypeAttributes.Public);
		Type[] array = new Type[param_count];
		Type[] array2 = new Type[param_count + 1];
		array2[param_count] = typeof(IntPtr);
		for (int i = 0; i < param_count; i++)
		{
			array[i] = typeof(IntPtr);
			array2[i] = typeof(IntPtr);
		}
		ILGenerator iLGenerator = typeBuilder.DefineMethod(MethodName, MethodAttributes.Public | MethodAttributes.Static, ret_type, array2).GetILGenerator();
		if (param_count > 5)
		{
			iLGenerator.Emit(OpCodes.Ldarg_S, 6);
		}
		if (param_count > 4)
		{
			iLGenerator.Emit(OpCodes.Ldarg_S, 5);
		}
		if (param_count > 3)
		{
			iLGenerator.Emit(OpCodes.Ldarg_S, 4);
		}
		if (param_count > 2)
		{
			iLGenerator.Emit(OpCodes.Ldarg_3);
		}
		if (param_count > 1)
		{
			iLGenerator.Emit(OpCodes.Ldarg_2);
		}
		if (param_count > 0)
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
		}
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, ret_type, array);
		iLGenerator.Emit(OpCodes.Ret);
		return typeBuilder.CreateType().GetMethod(MethodName);
	}

	[DllImport("ole32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterDragDrop")]
	private static extern uint Win32RegisterDragDrop(IntPtr Window, IntPtr pDropTarget);

	[DllImport("ole32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RevokeDragDrop")]
	private static extern int Win32RevokeDragDrop(IntPtr Window);

	[DllImport("ole32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "DoDragDrop")]
	private static extern uint Win32DoDragDrop(IntPtr pDataObject, IntPtr pDropSource, IntPtr dwOKEffect, ref IntPtr pdwEffect);

	[DllImport("ole32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OleInitialize")]
	private static extern int Win32OleInitialize(IntPtr pvReserved);

	[DllImport("shell32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "DragQueryFileW")]
	private static extern int Win32DragQueryFile(IntPtr hDrop, int iFile, IntPtr lpszFile, int cch);

	[DllImport("shell32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "DragQueryFileW")]
	private static extern int Win32DragQueryFile(IntPtr hDrop, int iFile, StringBuilder lpszFile, int cch);

	[DllImport("shell32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SHCreateStdEnumFmtEtc")]
	private static extern uint Win32SHCreateStdEnumFmtEtc(uint cfmt, FORMATETC[] afmt, ref IntPtr ppenumFormatEtc);
}
