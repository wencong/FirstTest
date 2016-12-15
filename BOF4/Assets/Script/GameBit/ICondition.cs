using UnityEngine;
using System.Collections;

public interface ICondition {
	bool Execute(ICharacter s, ref ICharacter character);
	string GetConditionName();
}
	
public enum ConditionType {
	SelfConditionType,
	TeamMemConditionType,
	EnemyConditionType
}

public class SelfHPGreaterThan : ICondition {
	public float m_fPercent = 0.0f;
	public string m_szActionName = string.Empty;

	public SelfHPGreaterThan(float fPercent, string szActionName) {
		m_fPercent = fPercent;
		m_szActionName = szActionName;
	}

	public string GetConditionName() {
		return m_szActionName;
	}

	public bool Execute(ICharacter s, ref ICharacter character) {
		bool bResult  = false;

		if (s == null) {
			goto Exit0;
		}

		int nMaxHP = s.GetMaxHP();
		int nCurHP = s.GetCurHP();

		float fPercent = (float)nCurHP / (float)nMaxHP;
		if (fPercent < m_fPercent) {
			goto Exit0;
		}

		character = s;
		bResult = true;
	Exit0:
		return bResult;
	}
}

public class SelfHPLessThan : ICondition {
	public float m_fPercent = 0.0f;
	public string m_szConditionName = string.Empty;

	public SelfHPLessThan(float fPercent, string szActionName) {
		m_fPercent = fPercent;
		m_szConditionName = szActionName;
	}

	public string GetConditionName() {
		return m_szConditionName;
	}

	public bool Execute(ICharacter s, ref ICharacter character) {
		bool bResult  = false;

		if (s == null) {
			goto Exit0;
		}

		int nMaxHP = s.GetMaxHP();
		int nCurHP = s.GetCurHP();

		float fPercent = (float)nCurHP / (float)nMaxHP;
		if (fPercent < m_fPercent) {
			goto Exit0;
		}

		character = s;
		bResult = true;
		Exit0:
		return bResult;
	}
}