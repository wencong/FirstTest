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

public class FishStatusIdel : IStatus {

	public void Update() {
		if (InputManager.Instance().A) {

		}

		if (InputManager.Instance().B) {
			UIMgr.Instance().CloseWindow(UIWinID.UI_FishGame);
		}

		if (InputManager.Instance().C) {
			UIMgr.Instance().OpenWindow(UIWinID.UI_FishGame);
		}
	}
}

public class FishStatusMove : IStatus {
	public void Update() {

	}
}

