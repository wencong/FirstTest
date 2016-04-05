using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IADBUserData, ICharacter{
	//
	// base property
	//
	public int m_nSpeed = 100;
	public int m_nMaxHP = 100;
	public int m_nCurHP = 60;
	private GameBit gb;

	//
	// inherited UnityEngine.Monobehaviour
	//
	void Start () {
		gb = new GameBit(new SelfHPGreaterThan(0.5f, "hp greater than 50%"), new AttackAction());
	}

	void Update () {
	
	}

	void OnGUI() {
		GUILayout.HorizontalSlider(fProcess, 0.0f, 1.0f, GUILayout.Width(100));
	}

	//
	// inherited IADBUserData
	//
	public int GetSpeed() {
		return m_nSpeed;
	}

	public bool IsActive() {
		return true;
	}

	public bool IsActionDone() {
		return true;
	}
		
	public void OnStart() {
		Debug.LogFormat("{0} Start", name);
	}

	float fProcess = 0.0f;
	public void OnProcess(float process) {
		fProcess = process;
	}

	public void OnAction() {
		//Debug.LogFormat("{0} Action", name);
		if (gb != null) {
			gb.Execute(this);
		}
	}

	public void OnEnd() {

	}


	//
	// inherited ICharacter
	//
	public string GetName() {
		return this.gameObject.name;
	}

	public int GetLevel() {
		return 0;
	}

	public int GetMaxHP() {
		return m_nMaxHP;
	}

	public int GetMaxMP() {
		return 0;
	}

	public int GetCurHP() {
		return m_nCurHP;
	}

	public int GetCurMP() {
		return 0;
	}
}
