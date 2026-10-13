using System.Collections.Generic;

namespace Rewired;

public struct InputActionEventData
{
	private QZWOxJToNpPZTYJKdjKDNrZDcbAQ hljsVZgahUvkUbCkUEHzEgotsofTA;

	private InputActionEventType ZBBDcqTYgHKDSvVTYNdRjulJWLcC;

	public readonly int playerId;

	public readonly int actionId;

	public readonly UpdateLoopType updateLoop;

	public InputActionEventType eventType
	{
		get
		{
			return ZBBDcqTYgHKDSvVTYNdRjulJWLcC;
		}
		internal set
		{
			cnnYhqAFgxVadbCvXhXyJprOBmHI(inputActionEventType);
		}
	}

	public Player player
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.players.GetPlayer(playerId);
		}
	}

	public string actionName
	{
		get
		{
			if (!ReInput.isReady)
			{
				return string.Empty;
			}
			return ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.NRviRUJlZrnMmqLUAtHMJPcPfEOn(actionId).name;
		}
	}

	public string actionDescriptiveName
	{
		get
		{
			if (!ReInput.isReady)
			{
				return string.Empty;
			}
			return ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.NRviRUJlZrnMmqLUAtHMJPcPfEOn(actionId).descriptiveName;
		}
	}

	internal void cnnYhqAFgxVadbCvXhXyJprOBmHI(InputActionEventType P_0)
	{
		ZBBDcqTYgHKDSvVTYNdRjulJWLcC = P_0;
	}

	public float GetAxis()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb();
	}

	public float GetAxisPrev()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.FomBExaZtEkQRHdfJkkbIXNFXhfm();
	}

	public float GetAxisDelta()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.fmKaxGzgbrFSVtTFySstiqkHgFgh();
	}

	public double GetAxisTimeActive()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.aevYRIdbCXgvMgEWIqWRDeBRDmZF();
	}

	public double GetAxisTimeInactive()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.evtBaUVlRoumvztXgKcRKDkqnGTy();
	}

	public float GetAxisRaw()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.cWteTyHrjPGhfmxcPfIvYekmLaOoA();
	}

	public float GetAxisRawDelta()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.qODMnhSIKHrRltjVNxJRRmvepmmy();
	}

	public float GetAxisRawPrev()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.xfRmaCvfMrhVhcNUFLrbYbmFBqcw();
	}

	public double GetAxisRawTimeActive()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.rSERnkLcjopHjuOEBmkUeqkLPyrr();
	}

	public double GetAxisRawTimeInactive()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.GyiGXqqOUBoQsvvmdSaKIrdHxtKE();
	}

	public AxisCoordinateMode GetAxisCoordinateMode()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.iANlwdzjObBoJzvXimKIrCGgjzLF();
	}

	public AxisCoordinateMode GetAxisCoordinateModePrev()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.wvnBxsmdfKqoYJNWKMRppFIrzIGs();
	}

	public AxisCoordinateMode GetAxisRawCoordinateMode()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.WNDgfdAArCnnYBTcsfqIMxWGtKuP();
	}

	public AxisCoordinateMode GetAxisRawCoordinateModePrev()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.MjAGUJfQgKreoThKBlsUSxKLWLMO();
	}

	public bool GetButton()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.xKqYQOpLsGFmaoEFKYQRCnKaaWcQ();
	}

	public bool GetButtonPrev()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.EnSiNuXtEgmFXWEsIzPJTGnkSqBU();
	}

	public bool GetButtonDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.SlBphyvwWgvIxeNaguzhFBDTfHoJ();
	}

	public bool GetButtonUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.AfBRHgbDIxDSwAMNQBOuTkhxmJQqA();
	}

	public bool GetButtonSinglePressHold()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.taSMMuYrnbSumUxwpcrTCCyAtuSX();
	}

	public bool GetButtonSinglePressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.tTJcOxzNCiiLiMUKpxjdpmtCQKSJ();
	}

	public bool GetButtonSinglePressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.poPBIMJHlRUiMXmwfxMlaldXdztT();
	}

	public bool GetButtonDoublePressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.rXBauPjnbSQkRxoXFkdhpWZMjfZF();
	}

	public bool GetButtonDoublePressDown(float speed)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.TxpFIpCXbAUGsbVTpDsFxkyYzcW(speed);
	}

	public bool GetButtonDoublePressHold()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.YmlFhYDayvfntSBKhUcMYpuxGYKp();
	}

	public bool GetButtonDoublePressHold(float speed)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.QsNvsLyEjKJflAGPVqYdaUgqbBtP(speed);
	}

	public bool GetButtonDoublePressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.zSwwlHVrsFQPzKdaLfBPdUMxcrWLA();
	}

	public bool GetButtonDoublePressUp(float speed)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.dwHlpMtarpWlenpesLjlxnUTFMUs(speed);
	}

	public bool GetButtonTimedPress(float time)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.FdRbXuPyMOBrWhPPtLbONRCWRNDF(time, 0f);
	}

	public bool GetButtonTimedPress(float time, float expireIn)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.FdRbXuPyMOBrWhPPtLbONRCWRNDF(time, expireIn);
	}

	public bool GetButtonTimedPressDown(float time)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.OiNKbcEeqwSpZVHNmRVnqogRDLbe(time);
	}

	public bool GetButtonTimedPressUp(float time)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.xHYWeZwAVSdqPEUcyxvqXirtXpaF(time, 0f);
	}

	public bool GetButtonTimedPressUp(float time, float expireIn)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.xHYWeZwAVSdqPEUcyxvqXirtXpaF(time, expireIn);
	}

	public bool GetButtonShortPress()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.hSsQhormxBPLsPmcTUQqJowtLVbv();
	}

	public bool GetButtonShortPressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.beWJzLeKilWrFrbfQEhsbIPicKVTA();
	}

	public bool GetButtonShortPressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.TSceslrzwUjYnpGunBFAMFHVIyNT();
	}

	public bool GetButtonLongPress()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.aSXXpPPIRQYKEURuUelgSsXLZrbF();
	}

	public bool GetButtonLongPressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.YhuZEIfeXBBkEwXAHNwLlIliaSbB();
	}

	public bool GetButtonLongPressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.HVQjefdnnZPmDpLqjeASIlsubdmnA();
	}

	public bool GetButtonRepeating()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.BrDddvTgykgmePaGTLJtXINQIFtK();
	}

	public double GetButtonTimePressed()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.KDOaClPYRQtUROFmmEQqHnNzmOFdA();
	}

	public double GetButtonTimeUnpressed()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.jOizjZLpppGnIDmOFHgQCWzakrlC();
	}

	public bool GetNegativeButton()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.xTmTABHXjJsoVMuVRKriyrGRgzRH();
	}

	public bool GetNegativeButtonPrev()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.BiXjczSVhafaeneuyfuougxOQCYu();
	}

	public bool GetNegativeButtonDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.jkWaFrQGPlyFMdhMpGwpqkrDEFHI();
	}

	public bool GetNegativeButtonUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.sgYTmFGalnrYFfIBPOUYeCxEwbSH();
	}

	public bool GetNegativeButtonSinglePressHold()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.OLBrnTxTzSPFYiaIRhtvoTtlUkku();
	}

	public bool GetNegativeButtonSinglePressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.yeRGNIvOuNmOdrntRledlybJAbWR();
	}

	public bool GetNegativeButtonSinglePressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.ivrolhhvFjVTtpjOzHpLymGcfxTw();
	}

	public bool GetNegativeButtonDoublePressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.paIFIFHtskmGzhCsehMYAzWVMxnK();
	}

	public bool GetNegativeButtonDoublePressDown(float speed)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.tmopxnyFMesBLwfGALpxzHifBmgJA(speed);
	}

	public bool GetNegativeButtonDoublePressHold()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.OftIFebzsfHoZgwodOHAWNWGQpdpA();
	}

	public bool GetNegativeButtonDoublePressHold(float speed)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.hbektbuDvlfxTouCRZgDkkmxTxeL(speed);
	}

	public bool GetNegativeButtonDoublePressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.OEoRooraWrGgjynCCTBbVMDLDAsG();
	}

	public bool GetNegativeButtonDoublePressUp(float speed)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.BwfldKcyKYMrqJeNqAnbJCnEQlno(speed);
	}

	public bool GetNegativeButtonTimedPress(float time)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.ziADzwgaBUtBwGHVrdTTRHuRRjVv(time, 0f);
	}

	public bool GetNegativeButtonTimedPress(float time, float expireIn)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.ziADzwgaBUtBwGHVrdTTRHuRRjVv(time, expireIn);
	}

	public bool GetNegativeButtonTimedPressDown(float time)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.MXpiuUDTKdbHFrOefQLevbJtSLAn(time);
	}

	public bool GetNegativeButtonTimedPressUp(float time)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.thuqLozprJgAEhQQpMrdgxdFaLXHb(time, 0f);
	}

	public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.thuqLozprJgAEhQQpMrdgxdFaLXHb(time, expireIn);
	}

	public bool GetNegativeButtonShortPress()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.QlWFjPVnWqModMBeBYnxLikAKDpK();
	}

	public bool GetNegativeButtonShortPressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.AfxupzobmupXNHrRGlGIelaZDFwJ();
	}

	public bool GetNegativeButtonShortPressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.vIAohwnKWdpbfnavFyHTrtDrBpsH();
	}

	public bool GetNegativeButtonLongPress()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.qYurVkNFOBRmWJkExbIOmfDSrXlB();
	}

	public bool GetNegativeButtonLongPressDown()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.UdkkgdfwCMgOXaDSEbjwMaueXKry();
	}

	public bool GetNegativeButtonLongPressUp()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.dOHvDRsAISqcocjczVGkDIoPpjIO();
	}

	public bool GetNegativeButtonRepeating()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.UTcPrzFZoDBChEyJmzoNpyZmvAqk();
	}

	public double GetNegativeButtonTimePressed()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.WGFuhoUGGnsDVUmOuiJBlOfzhxGgA();
	}

	public double GetNegativeButtonTimeUnpressed()
	{
		return hljsVZgahUvkUbCkUEHzEgotsofTA.qjSstIdrUpxTgURnIqiyHOeurdte();
	}

	public IList<InputActionSourceData> GetCurrentInputSources()
	{
		return ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.tfgFiWTAWZlOVgeKFIvByhHrMtkg(playerId, actionId, true)?.FkvQUzWkpTMYvnzWaUlppZhTtfNd();
	}

	public bool IsCurrentInputSource(ControllerType controllerType)
	{
		return ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.tfgFiWTAWZlOVgeKFIvByhHrMtkg(playerId, actionId, true)?.WUrYmiQJbKUthJEWccecckCIxCvV(controllerType) ?? false;
	}

	public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
	{
		return ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.tfgFiWTAWZlOVgeKFIvByhHrMtkg(playerId, actionId, true)?.WivOHtUlNraTJAxthhKGJRgzkWKt(controllerType, controllerId) ?? false;
	}

	public bool IsCurrentInputSource(Controller controller)
	{
		return ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.tfgFiWTAWZlOVgeKFIvByhHrMtkg(playerId, actionId, true)?.XrIYiQKvgIGwnqhZEKXESXIusUoL(controller) ?? false;
	}

	internal InputActionEventData(QZWOxJToNpPZTYJKdjKDNrZDcbAQ P_0, int P_1, int P_2, UpdateLoopType P_3)
	{
		ZBBDcqTYgHKDSvVTYNdRjulJWLcC = InputActionEventType.Update;
		hljsVZgahUvkUbCkUEHzEgotsofTA = P_0;
		playerId = P_1;
		actionId = P_2;
		updateLoop = P_3;
	}
}
