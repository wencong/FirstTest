using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum ADBSTATUS {
	STATUS_IDEL    = 0,
	STATUS_PROCESS = 1,
	STATUS_ACTION  = 2,
}

public class ADBConfig {
	public static int nMaxSpeed     = 255;
	public static int nMaxActionBar = 300;
	public static int nMaxFps       = 60;
	public static int nStepPreFrame = 1;
}

public interface IADBUserData {
	int GetSpeed();

	bool IsActive();

	bool IsActionDone();

	// event call back
	void OnStart();

	void OnProcess(float process);

	void OnAction();

	void OnEnd();
}

public class ADBMetaData {
	
	public IADBUserData m_userData;

	private int m_nCurrentStep = 0;

	public ADBSTATUS m_eStatus = ADBSTATUS.STATUS_IDEL;

	public ADBMetaData(IADBUserData userData) {
		this.m_userData = userData;
	}

	public void SetStatus(ADBSTATUS eStatus) {
		m_eStatus = eStatus;
	}

	public void Update() {
		
		if (!m_userData.IsActive()) {
			return;
		}

		switch (m_eStatus) {
			case ADBSTATUS.STATUS_IDEL: {
				m_userData.OnStart();
				_SetStatus(ADBSTATUS.STATUS_PROCESS);
				break;
			}

			case ADBSTATUS.STATUS_PROCESS: {
				_UpdateSteps();

				if (_CheckSteps()) {
					m_userData.OnAction();
					_SetStatus(ADBSTATUS.STATUS_ACTION);
				}
				else {
					m_userData.OnProcess(CurrentSteps);
				}

				break;
			}

			case ADBSTATUS.STATUS_ACTION: {
				if (m_userData.IsActionDone()) {
					_ResetStep();
					_SetStatus(ADBSTATUS.STATUS_PROCESS);
					m_userData.OnProcess(CurrentSteps);
				}
				break;
			}
		}
	}

	public float CurrentSteps {
		get {
			int nSteps = ADBConfig.nMaxActionBar - m_userData.GetSpeed();
			return (float)m_nCurrentStep / nSteps;
		}
		set {
			int steps = ADBConfig.nMaxActionBar - m_userData.GetSpeed();
			m_nCurrentStep = (int)(steps * value);
		}
	}

	private void _UpdateSteps() {
		m_nCurrentStep += ADBConfig.nStepPreFrame;
	}

	private bool _CheckSteps() {
		return CurrentSteps >= 1.0f;
	}

	public void _ResetStep() {
		m_nCurrentStep = 0;
	}

	public void _SetStatus(ADBSTATUS status) {
		m_eStatus = status;
	}
}

/*
* ADB（动态次元战斗系统）
*/

public class ADB : Singleton<ADB> {
	private const int m_nMaxCount = 3;

	private List<ADBMetaData> m_listMetaData = new List<ADBMetaData>(m_nMaxCount);

	private bool bPause = false;

	public void SetPause(bool bPause) {
		this.bPause = bPause;
	}
	// Update is called once per frame
	public void Update () {
		if (bPause) {
			return;
		}

		for (int i = 0; i < m_listMetaData.Count; ++i) {
			ADBMetaData metaData = m_listMetaData[i];
			metaData.Update();
		}
	}

	public void AddUserData(IADBUserData userData) {
		if (m_listMetaData.Count >= 3) {
			return;
		}

		ADBMetaData metaData = new ADBMetaData(userData);
		m_listMetaData.Add(metaData);
	}
}

