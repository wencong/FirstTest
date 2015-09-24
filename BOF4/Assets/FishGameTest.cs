using UnityEngine;
using System.Collections;

public class FishGameTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FishGame.Instance().Load();
        FishGame.Instance().Init();
        FishGame.Instance().Start();

	}
	
	// Update is called once per frame
	void Update () {
        FishGame.Instance().Update();
	}
}
