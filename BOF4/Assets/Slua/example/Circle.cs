using UnityEngine;
using System.Collections;
using SLua;
using LuaInterface;
using System;

public class Circle : MonoBehaviour {
	LuaSvr svr;
	LuaTable self;
	LuaFunction update;
	void Start () {
		svr = new LuaSvr();
		svr.init(null, () =>
		{
			self = (LuaTable)svr.start("circle/circle");
			update = (LuaFunction)self["update"];
		});
        
	}
	
	void Update () {
		if(update!=null) update.call(self);
	}

    void stackDump(IntPtr L) {
        int count = LuaDLL.lua_gettop(L);
        for (int i = 0; i <= count; ++i) {
            LuaTypes type = LuaDLL.lua_type(L, i);
            Debug.Log(type.ToString());
        }
    }
}
