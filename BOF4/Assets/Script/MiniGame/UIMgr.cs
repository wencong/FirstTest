using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum UIWinID {
	UI_FishGame,
	UI_FishGameData,
	UI_FishGameSetting,
	UI_FishGameEquip,
	UI_None
}

public class UIMgr : Singleton<UIMgr> {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private Dictionary<UIWinID, UIWin> m_cacheUIs = new Dictionary<UIWinID, UIWin>();

	public bool OpenWindow(UIWinID winID) {
		if (winID >= UIWinID.UI_None) {
			return false;
		}

		UIWin win = null;
		m_cacheUIs.TryGetValue(winID, out win);
		if (win == null) {
			UnityEngine.GameObject ui = _LoadUIPrefab(winID);
			if (ui != null) {
				m_cacheUIs.Add(winID, ui.GetComponent<UIWin>());
				Log.Info("cache ui:{0}", winID);
			}
		}
		else {
			win.gameObject.SetActive(true);
		}

		return true;
	}

	public void CloseWindow(UIWinID winID, bool destory = false) {
		UIWin win = null;
		m_cacheUIs.TryGetValue(winID, out win);
		if (win == null) {
			return;
		}

		win.gameObject.SetActive(false);

		if (destory == true) {
			m_cacheUIs.Remove(winID);
			GameObject.Destroy(win.gameObject);
		}
	}

	private UnityEngine.GameObject _LoadUIPrefab(UIWinID winID) {
		string UIpath = string.Format("{0}/{1}/{2}", "ArtWorks", "UI", winID.ToString());
		UnityEngine.Object prefab = Resources.Load(UIpath);
		GameObject inst = GameObject.Instantiate(prefab) as GameObject;
		if (inst == null) {
			Log.Info("Load UIPrefab failed: {0}", UIpath);
		}
		return inst;
	}
}
