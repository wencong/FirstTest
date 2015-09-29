using UnityEngine;
using System.Collections;

public class UI_FishGame : UIWin {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool OnOpen() {
		Log.Info("OnOpen");
		InitButton("Button_ziliao", OnZiliaoButtonClick);
		InitButton("Button_zhuangbei", OnZhuangbeiButtonClick);
		InitButton("Button_shezhi", OnShezhiButtonClick);
		
		SetFirstSelectButton("Button_ziliao");
		return true;
	}

	public override bool OnClose() {
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
