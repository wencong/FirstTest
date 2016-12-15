using System;

public enum ActionType {
	AttackActionType,
	ItemActionType,
	SkillActionType
}

public interface IAction {
	bool Execute(ICharacter s, ICharacter e);
	string GetActionName();
	ActionType GetActionType();
}

public class AttackAction : IAction {
	public bool Execute(ICharacter s, ICharacter e) {
		AnimatorController controller = s.GetController();
		controller.Attack();
		return true;
	}

	public ActionType GetActionType() {
		return ActionType.AttackActionType;
	}

	public string GetActionName() {
		return "Attack";
	}
}


public class ItemAction : IAction {
	private string m_szItemName;

	public ItemAction() {
	}

	public bool Execute(ICharacter s, ICharacter e) {
		AnimatorController controller = s.GetController();
		//controller.Attack();
		return true;
	}

	public ActionType GetActionType() {
		return ActionType.ItemActionType;
	}

	public string GetActionName() {
		return "Use Item";
	}
}