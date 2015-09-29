using UnityEngine;
using System.Collections;

public class UI_FishGame : UIWin {

	// Use this for initialization
	void Start () {
		InitButton("Button_ziliao", OnZiliaoButtonClick);
		InitButton("Button_zhuangbei", OnZhuangbeiButtonClick);
		InitButton("Button_shezhi", OnShezhiButtonClick);

		SetFirstSelectButton("Button_ziliao");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override bool OnOpen() { 
		return true;
	}

	protected override bool OnClose() {
		return true;
	}


	public void OnZiliaoButtonClick() {
		Log.Info("Ziliao Button click");
	}

	public void OnZhuangbeiButtonClick() {
		Log.Info("Zhuangbei Button Click");
	}

	public void OnShezhiButtonClick() {
		Log.Info("Shezhi Button Click");
	}
}
