using System;

public class GameBit {
	public ICondition m_condition = null;
	public IAction m_action = null;

	public GameBit (ICondition condition, IAction action) {
		m_condition = condition;
		m_action = action;
	}

	public bool Valid() {
		return m_condition != null && m_action != null;
	}

	public void SetCondition(ICondition condition) {
		m_condition = condition;
	}

	public void SetAction(IAction action) {
		m_action = action;
	}

	public bool Execute(ICharacter character) {
		if (character == null) {
			return false;
		}

		if (m_condition == null) {
			return false;
		}

		ICharacter refCharacter = null;
		bool ret = m_condition.Execute(character, ref refCharacter);
		if (!ret) {
			return false;
		}

		if (m_action == null) {
			return false;
		}

		ret = m_action.Execute(character, refCharacter);
		if (!ret) {
			return false;
		}

		return true;
	}
}


