using System;
using Language.Lua.Library;
using UnityEngine;

namespace Language.Lua;

public class LuaInterpreter
{
	private static Parser parser = new Parser();

	public static LuaValue RunFile(string luaFile)
	{
		Debug.LogWarning("LuaInterpreter.RunFile() is disabled in this version of LuaInterpreter.");
		return LuaNil.Nil;
	}

	public static LuaValue RunFile(string luaFile, LuaTable enviroment)
	{
		Debug.LogWarning("LuaInterpreter.RunFile() is disabled in this version of LuaInterpreter.");
		return LuaNil.Nil;
	}

	public static LuaValue Interpreter(string luaCode)
	{
		return Interpreter(luaCode, CreateGlobalEnviroment());
	}

	public static LuaValue Interpreter(string luaCode, LuaTable enviroment)
	{
		Chunk chunk = Parse(luaCode);
		chunk.Enviroment = enviroment;
		return chunk.Execute();
	}

	public static Chunk Parse(string luaCode)
	{
		Chunk result = parser.ParseChunk(new TextInput(luaCode), out var success);
		if (success)
		{
			return result;
		}
		throw new ArgumentException("Code has syntax errors:\r\n" + parser.GetEorrorMessages());
	}

	public static LuaTable CreateGlobalEnviroment()
	{
		LuaTable luaTable = new LuaTable();
		BaseLib.RegisterFunctions(luaTable);
		StringLib.RegisterModule(luaTable);
		TableLib.RegisterModule(luaTable);
		IOLib.RegisterModule(luaTable);
		FileLib.RegisterModule(luaTable);
		MathLib.RegisterModule(luaTable);
		OSLib.RegisterModule(luaTable);
		luaTable.SetNameValue("_G", luaTable);
		return luaTable;
	}
}
