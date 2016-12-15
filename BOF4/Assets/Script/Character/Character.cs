using UnityEngine;
using System.Collections;

public interface ICharacter {
	string GetName();

	int GetLevel();

	int GetMaxHP();

	int GetMaxMP();

	int GetCurHP();

	int GetCurMP();

	AnimatorController GetController();

	// to do list
}
