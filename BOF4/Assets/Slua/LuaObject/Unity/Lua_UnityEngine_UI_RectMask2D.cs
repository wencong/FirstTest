﻿using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_RectMask2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Camera a2;
			checkType(l,3,out a2);
			var ret=self.IsRaycastLocationValid(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PerformClipping(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			self.PerformClipping();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddClippable(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.UI.IClippable a1;
			checkType(l,2,out a1);
			self.AddClippable(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RemoveClippable(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.UI.IClippable a1;
			checkType(l,2,out a1);
			self.RemoveClippable(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_canvasRect(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.canvasRect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_rectTransform(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rectTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.RectMask2D");
		addMember(l,IsRaycastLocationValid);
		addMember(l,PerformClipping);
		addMember(l,AddClippable);
		addMember(l,RemoveClippable);
		addMember(l,"canvasRect",get_canvasRect,null,true);
		addMember(l,"rectTransform",get_rectTransform,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.RectMask2D),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
