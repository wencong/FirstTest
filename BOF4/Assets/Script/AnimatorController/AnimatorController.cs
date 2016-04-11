using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {
	private Animator m_animator;
	// Use this for initialization
	void Start () {
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Attack() {
		m_animator.SetTrigger("attack");
	}
}
