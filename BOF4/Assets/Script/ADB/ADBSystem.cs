using UnityEngine;
using System.Collections;

public class ADBSystem : MonoBehaviour {
	// Update is called once per frame
	void Awake() {
		Application.targetFrameRate = 60;

		Player[] players = GameObject.FindObjectsOfType<Player>();

		for(int i = 0; i < players.Length; ++i) {
			ADB.Instance().AddUserData(players[i]);
		}
	}

	void Update () {
		ADB.Instance().Update();
	}
}
