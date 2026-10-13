using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

internal class PZIrFQmTYjOFmeiRPrMzBSOSvuwD
{
	private int mqKZASCmLYHTgCYhpxoRolHiouyVA;

	private int qeTkqMNiKHcsedrKixPLojvKDeBTA;

	private Player hCcjkFzOWNdzFzmMlYTGgzXchuJB;

	private Player[] OHWTBEOBrsoJGVRHOMtkKmTVFmMA;

	private Player[] yFTUjuHvFeIBWQfRnfRYGkAzuGir;

	private IList<Player> zjvZBNUDvVfjVJOfBIsVUKGGIgdV;

	private IList<Player> bXyIiGollZPVvAUXKZiNfIxEBmSF;

	private ConfigVars zilYUvdjkpwVtPFwmOogonVEoRxO;

	private bool yopfTOezFNYVbNnVjTxREHrrTPsU;

	public int dwhMuTSsRyjOUBXDExcFmbUBznhV => hUvGgieeUHPERTuNwsrVwxUSzbGsA();

	public int BJXGVYBVcrBWgUaxKFeLhSHkyfstb => EDgVOlSZldfZdLwENGKrPAFdrHXk();

	public Player[] oTSmxUcXofdhujcVYjRZeevvdykp => qamCCihAizQaxMAZMYFcKDIMVPfwA();

	public Player[] dFzKRrTLbhMfWphgtcMPzSKnAkwP => hbLpqlVcmtGUecdXnmNXWJxICZtSA();

	public IList<Player> mGpWEDqsLMjOSoUEMybwRJoxNiv => YFfklZQPcnbKRfkKpicSsOCMtOngA();

	public IList<Player> XOLgIDaYwNZfSmOAMVDPShzljSyjA => rUjFidcPCnnbRlfRlnVMNbJHbHAK();

	public PZIrFQmTYjOFmeiRPrMzBSOSvuwD(ConfigVars P_0)
	{
		zilYUvdjkpwVtPFwmOogonVEoRxO = P_0;
	}

	public int hUvGgieeUHPERTuNwsrVwxUSzbGsA()
	{
		return mqKZASCmLYHTgCYhpxoRolHiouyVA;
	}

	public int EDgVOlSZldfZdLwENGKrPAFdrHXk()
	{
		return qeTkqMNiKHcsedrKixPLojvKDeBTA;
	}

	public Player[] qamCCihAizQaxMAZMYFcKDIMVPfwA()
	{
		return OHWTBEOBrsoJGVRHOMtkKmTVFmMA;
	}

	public Player[] hbLpqlVcmtGUecdXnmNXWJxICZtSA()
	{
		return yFTUjuHvFeIBWQfRnfRYGkAzuGir;
	}

	public IList<Player> YFfklZQPcnbKRfkKpicSsOCMtOngA()
	{
		return bXyIiGollZPVvAUXKZiNfIxEBmSF;
	}

	public IList<Player> rUjFidcPCnnbRlfRlnVMNbJHbHAK()
	{
		return zjvZBNUDvVfjVJOfBIsVUKGGIgdV;
	}

	public void BSSPjRyqmFavLeqkoUtSBapkXNLiA()
	{
		if (yopfTOezFNYVbNnVjTxREHrrTPsU)
		{
			return;
		}
		qeTkqMNiKHcsedrKixPLojvKDeBTA = ReInput.UserData.playerCount;
		mqKZASCmLYHTgCYhpxoRolHiouyVA = qeTkqMNiKHcsedrKixPLojvKDeBTA - 1;
		yFTUjuHvFeIBWQfRnfRYGkAzuGir = new Player[mqKZASCmLYHTgCYhpxoRolHiouyVA];
		OHWTBEOBrsoJGVRHOMtkKmTVFmMA = new Player[qeTkqMNiKHcsedrKixPLojvKDeBTA];
		IList<Player_Editor> list = ReInput.UserData.XSrhHLLZWmMFQNHbTwQlcvQyDugK();
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			spMACGdyRGKOkwMouVwTkXeYbAaQ spMACGdyRGKOkwMouVwTkXeYbAaQ2 = player_Editor.AOuGSeJEKrlWyeimpKzslUCqHYVG();
			ControllerMapLayoutManager.cUhsarZCgVkkiQMvHfbBJdlcDTAR cUhsarZCgVkkiQMvHfbBJdlcDTAR = player_Editor.controllerMapLayoutManagerSettings.wRXVWUyNdsuYAOsQLlRIGEeSBLqt();
			ControllerMapEnabler.myTUEzsWwrinEGyZklokhnLFhKWB myTUEzsWwrinEGyZklokhnLFhKWB = player_Editor.controllerMapEnablerSettings.qcwdGlBNrcsHItZlcZoJphNzLKAEb();
			Player player;
			if (i == 0)
			{
				player = (hCcjkFzOWNdzFzmMlYTGgzXchuJB = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, spMACGdyRGKOkwMouVwTkXeYbAaQ2, cUhsarZCgVkkiQMvHfbBJdlcDTAR, myTUEzsWwrinEGyZklokhnLFhKWB));
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, spMACGdyRGKOkwMouVwTkXeYbAaQ2, cUhsarZCgVkkiQMvHfbBJdlcDTAR, myTUEzsWwrinEGyZklokhnLFhKWB);
				yFTUjuHvFeIBWQfRnfRYGkAzuGir[i - 1] = player;
			}
			OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.ybHgWDGIxfNGDffxKizpDlIevpcOB(true);
			player.controllers.maps.cSsoauzNPjyjndRwzBMgLOhWNjzH(true);
		}
		zjvZBNUDvVfjVJOfBIsVUKGGIgdV = new ReadOnlyCollection<Player>(yFTUjuHvFeIBWQfRnfRYGkAzuGir);
		bXyIiGollZPVvAUXKZiNfIxEBmSF = new ReadOnlyCollection<Player>(OHWTBEOBrsoJGVRHOMtkKmTVFmMA);
		yopfTOezFNYVbNnVjTxREHrrTPsU = true;
	}

	public void AtVdNRhtoEgwPJjBhRmQCdoRWoEO(Joystick P_0)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, P_0))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, P_0);
		}
		else if (!zilYUvdjkpwVtPFwmOogonVEoRxO.reassignJoystickToPreviousOwnerOnReconnect || !okeUmLNeWwEDzGCryiSHuaIbLrF(P_0))
		{
			ceIAkvhRRNDvcNeqyOyViiQWIYyeb(P_0);
		}
	}

	public void zTbhIKwTVlMdnUXsULQkGtdSqilm(Joystick P_0)
	{
		if (zilYUvdjkpwVtPFwmOogonVEoRxO.autoAssignJoysticks)
		{
			AtVdNRhtoEgwPJjBhRmQCdoRWoEO(P_0);
		}
	}

	public void vhodcUKgFIymUSlKmnRMUseXKWDfA(ControllerType P_0, int P_1)
	{
		for (int i = 0; i < qeTkqMNiKHcsedrKixPLojvKDeBTA; i++)
		{
			OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i].controllers.RemoveController(P_0, P_1);
		}
	}

	public Player fucJiwJzRsWBBQakvQMUMarJaFob(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= mqKZASCmLYHTgCYhpxoRolHiouyVA))
		{
			Logger.LogError("Player id " + P_0 + " does not exist!");
			return null;
		}
		if (P_0 == 9999999)
		{
			return hCcjkFzOWNdzFzmMlYTGgzXchuJB;
		}
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			if (yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].id == P_0)
			{
				return yFTUjuHvFeIBWQfRnfRYGkAzuGir[P_0];
			}
		}
		return null;
	}

	public Player ZfwWgflvHlqQxkMonGglAIcEnDUNA(string P_0)
	{
		if (P_0 != null && !(P_0 == string.Empty))
		{
			if (hCcjkFzOWNdzFzmMlYTGgzXchuJB.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return hCcjkFzOWNdzFzmMlYTGgzXchuJB;
			}
			for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
			{
				if (yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return yFTUjuHvFeIBWQfRnfRYGkAzuGir[i];
				}
			}
		}
		Logger.LogError("Player \"" + P_0 + "\" does not exist!");
		return null;
	}

	public Player aIWEWBhJOdPKbObSWugNVHKhlmbjA()
	{
		return hCcjkFzOWNdzFzmMlYTGgzXchuJB;
	}

	public int yxksTnTkZhPFcRqEkjAtQanVpBwV(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return -1;
		}
		if (hCcjkFzOWNdzFzmMlYTGgzXchuJB.name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			if (yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].name.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].id;
			}
		}
		return -1;
	}

	public bool jpUdRWBxFHbifDILmpuwKTgxgTJg(int P_0)
	{
		if (P_0 != 9999999 && (P_0 < 0 || P_0 >= mqKZASCmLYHTgCYhpxoRolHiouyVA))
		{
			return false;
		}
		return true;
	}

	public Player[] jfxIIXFTMUunkPCXesCQQpQhSjGR(bool P_0)
	{
		int num = mqKZASCmLYHTgCYhpxoRolHiouyVA;
		if (P_0)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = hCcjkFzOWNdzFzmMlYTGgzXchuJB;
			num2 = 1;
		}
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			array[num2 + i] = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i];
		}
		return array;
	}

	public string[] chaHKoSSzwMskPDTTZuXolmSjfty(bool P_0)
	{
		int num = mqKZASCmLYHTgCYhpxoRolHiouyVA;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = hCcjkFzOWNdzFzmMlYTGgzXchuJB.name;
			num2 = 1;
		}
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			array[num2 + i] = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].name;
		}
		return array;
	}

	public string[] RcqbCVhBYKhDQlrSluIHkKPcznxUA(bool P_0)
	{
		int num = mqKZASCmLYHTgCYhpxoRolHiouyVA;
		if (P_0)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = hCcjkFzOWNdzFzmMlYTGgzXchuJB.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			array[num2 + i] = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].descriptiveName;
		}
		return array;
	}

	public int[] xANjQlcwifYpKrbzIRmXAjgXBGKHA(bool P_0)
	{
		int num = mqKZASCmLYHTgCYhpxoRolHiouyVA;
		if (P_0)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (P_0)
		{
			array[0] = hCcjkFzOWNdzFzmMlYTGgzXchuJB.id;
			num2 = 1;
		}
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			array[num2 + i] = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].id;
		}
		return array;
	}

	public bool StjEBPCacMFyqIDOIMMrjOvJYopN(Controller P_0)
	{
		if (P_0 == null || OHWTBEOBrsoJGVRHOMtkKmTVFmMA == null)
		{
			return false;
		}
		return pbpkDFWLyvVGxBSpJgfiarllLpZf(P_0.type, P_0.id);
	}

	public bool pbpkDFWLyvVGxBSpJgfiarllLpZf(ControllerType P_0, int P_1)
	{
		if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA == null)
		{
			return false;
		}
		for (int i = 0; i < OHWTBEOBrsoJGVRHOMtkKmTVFmMA.Length; i++)
		{
			if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i].controllers.ContainsController(P_0, P_1))
			{
				return true;
			}
		}
		return false;
	}

	public bool etAFAgAOCdfGKYXkTSPaTZlOfjRIA(ControllerType P_0, int P_1, int P_2)
	{
		return fucJiwJzRsWBBQakvQMUMarJaFob(P_2)?.controllers.ContainsController(P_0, P_1) ?? false;
	}

	public void jvdadKUxrlQrFtJOhuSsautDzGic(Controller P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				hCcjkFzOWNdzFzmMlYTGgzXchuJB.controllers.RemoveController(P_0);
			}
			for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
			{
				yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].controllers.RemoveController(P_0);
			}
		}
	}

	public void pqvnYGsqSatGbOJKvCHsigtlKZxEA(ControllerType P_0, int P_1, bool P_2)
	{
		Controller controller = ReInput.controllers.GetController(P_0, P_1);
		if (controller != null)
		{
			jvdadKUxrlQrFtJOhuSsautDzGic(controller, P_2);
		}
	}

	public bool QszGNdnMKMKxoVvTxiabqKnjEGpm(Joystick P_0)
	{
		if (P_0 == null || OHWTBEOBrsoJGVRHOMtkKmTVFmMA == null)
		{
			return false;
		}
		for (int i = 0; i < OHWTBEOBrsoJGVRHOMtkKmTVFmMA.Length; i++)
		{
			if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool oeXSyRVFNaeoWcVwHVyLzZdCtBGb(int P_0)
	{
		if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA == null)
		{
			return false;
		}
		for (int i = 0; i < OHWTBEOBrsoJGVRHOMtkKmTVFmMA.Length; i++)
		{
			if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i].controllers.ContainsController(ControllerType.Joystick, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool tNyThZVHDAzqtdlZebWBIRxfvdK(int P_0, int P_1)
	{
		return fucJiwJzRsWBBQakvQMUMarJaFob(P_1)?.controllers.ContainsController(ControllerType.Joystick, P_0) ?? false;
	}

	public void akAcLwgLARvzAtSRDJgOImodCwHt(Joystick P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				hCcjkFzOWNdzFzmMlYTGgzXchuJB.controllers.cyVGrkRfGgSHMlENCMQojMfWVtZj(P_0);
			}
			for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
			{
				yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].controllers.cyVGrkRfGgSHMlENCMQojMfWVtZj(P_0);
			}
		}
	}

	public void oKNSYFYMkfdYASVbfCRuJsEtRUvT(int P_0, bool P_1)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(P_0);
		if (joystick != null)
		{
			akAcLwgLARvzAtSRDJgOImodCwHt(joystick, P_1);
		}
	}

	public bool WUDloiZNdxvQbNtGJfIVecKWjLhEA(CustomController P_0)
	{
		if (P_0 == null || OHWTBEOBrsoJGVRHOMtkKmTVFmMA == null)
		{
			return false;
		}
		for (int i = 0; i < OHWTBEOBrsoJGVRHOMtkKmTVFmMA.Length; i++)
		{
			if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i].controllers.ContainsController(P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool MMMvSOKmncavygzMEJgShKKjfqSGA(int P_0)
	{
		if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA == null)
		{
			return false;
		}
		for (int i = 0; i < OHWTBEOBrsoJGVRHOMtkKmTVFmMA.Length; i++)
		{
			if (OHWTBEOBrsoJGVRHOMtkKmTVFmMA[i].controllers.ContainsController(ControllerType.Custom, P_0))
			{
				return true;
			}
		}
		return false;
	}

	public bool UGXkGtHtCqHVtDcoxtHZlZuGVXwk(int P_0, int P_1)
	{
		return fucJiwJzRsWBBQakvQMUMarJaFob(P_1)?.controllers.ContainsController(ControllerType.Custom, P_0) ?? false;
	}

	public void FrIbSVOSopiPWmgCSjakhuZezLrM(CustomController P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1)
			{
				hCcjkFzOWNdzFzmMlYTGgzXchuJB.controllers.YhsbofBlHeceHtebbDOGxILgZimjA(P_0);
			}
			for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
			{
				yFTUjuHvFeIBWQfRnfRYGkAzuGir[i].controllers.YhsbofBlHeceHtebbDOGxILgZimjA(P_0);
			}
		}
	}

	public void ZJUYtApoxbyjDmgasUdBiDPrIOIY(int P_0, bool P_1)
	{
		CustomController customController = ReInput.controllers.GetCustomController(P_0);
		if (customController != null)
		{
			FrIbSVOSopiPWmgCSjakhuZezLrM(customController, P_1);
		}
	}

	private bool okeUmLNeWwEDzGCryiSHuaIbLrF(Joystick P_0)
	{
		if (zilYUvdjkpwVtPFwmOogonVEoRxO.distributeJoysticksEvenly)
		{
			int num = RcsCgRRYHBnnQALaEMRqsYwWXIob();
			if (num < 0)
			{
				return false;
			}
			int num2 = yeGIBITsiWSmwiLZPACwPbhdrbbO(P_0.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = yFTUjuHvFeIBWQfRnfRYGkAzuGir[num];
			Player player2 = yFTUjuHvFeIBWQfRnfRYGkAzuGir[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				yFTUjuHvFeIBWQfRnfRYGkAzuGir[num2].controllers.VuyGldiugjtXAeHaagwQSjnHJLwfA(P_0, true);
				return true;
			}
			return false;
		}
		int num3 = yeGIBITsiWSmwiLZPACwPbhdrbbO(P_0.id);
		if (num3 < 0)
		{
			return false;
		}
		yFTUjuHvFeIBWQfRnfRYGkAzuGir[num3].controllers.VuyGldiugjtXAeHaagwQSjnHJLwfA(P_0, true);
		return true;
	}

	private bool ceIAkvhRRNDvcNeqyOyViiQWIYyeb(Joystick P_0)
	{
		if (zilYUvdjkpwVtPFwmOogonVEoRxO.distributeJoysticksEvenly)
		{
			int num = RcsCgRRYHBnnQALaEMRqsYwWXIob();
			if (num >= 0)
			{
				yFTUjuHvFeIBWQfRnfRYGkAzuGir[num].controllers.VuyGldiugjtXAeHaagwQSjnHJLwfA(P_0, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
			{
				Player player = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!zilYUvdjkpwVtPFwmOogonVEoRxO.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < zilYUvdjkpwVtPFwmOogonVEoRxO.maxJoysticksPerPlayer)
				{
					player.controllers.VuyGldiugjtXAeHaagwQSjnHJLwfA(P_0, true);
					return true;
				}
			}
		}
		return false;
	}

	private int RcsCgRRYHBnnQALaEMRqsYwWXIob()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			Player player = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!zilYUvdjkpwVtPFwmOogonVEoRxO.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < zilYUvdjkpwVtPFwmOogonVEoRxO.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	public int yeGIBITsiWSmwiLZPACwPbhdrbbO(int P_0)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < mqKZASCmLYHTgCYhpxoRolHiouyVA; i++)
		{
			Player player = yFTUjuHvFeIBWQfRnfRYGkAzuGir[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!zilYUvdjkpwVtPFwmOogonVEoRxO.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < zilYUvdjkpwVtPFwmOogonVEoRxO.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.YucZUrFwzwzUOLylRVLfAjQlnuCC(P_0);
				if (!(num3 < 0.0) && (num < 0 || num3 > num2))
				{
					num2 = num3;
					num = i;
				}
			}
		}
		return num;
	}
}
