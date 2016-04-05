using System;

public interface IAction {
	bool Execute(ICharacter s, ICharacter e);
	string GetActionName();
}

public class AttackAction : IAction {
	public bool Execute(ICharacter s, ICharacter e) {
		Log.Info("Attack...");
		return true;
	}

	public string GetActionName() {
		return "Attack";
	}
}