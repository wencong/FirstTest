// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager> {
	private bool _A;
	private bool _B;
	private bool _C;
	private bool _D;

	private bool _Up;
	private bool _Down;

	public void Update() {
#if UNITY_EDITOR
		_A = Input.GetKeyDown(KeyCode.C) | Input.GetKeyDown(KeyCode.Space);
		_B = Input.GetKeyDown(KeyCode.V) | Input.GetKeyDown(KeyCode.Escape);
		_C = Input.GetKeyDown(KeyCode.Z);

		_Up = Input.GetKeyDown(KeyCode.UpArrow);
		_Down = Input.GetKeyDown(KeyCode.DownArrow);
#endif
	}

	public bool A {
		get {
			return _A;
		}
	}

	public bool B {
		get {
			return _B;
		}
	}

	public bool C {
		get {
			return _C;
		}
	}

	public bool Up {
		get {
			return _Up;
		}
	}

	public bool Down {
		get {
			return _Down;
		}
	}
}

