using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class UIWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract bool OnOpen();

	public abstract bool OnClose();

	protected void SetFirstSelectButton(string btnName) {
		Transform btn = transform.FindChild(btnName);
		if (btn == null) {
			return;
		}

		GameObject eventMgr = EventSystemMgr.Instance.gameObject;
		if (eventMgr == null) {
			Debug.Log("eventMgr is not found");
		}
		else {
			EventSystem es = eventMgr.GetComponent<EventSystem>();
			es.firstSelectedGameObject = btn.gameObject;
			es.SetSelectedGameObject(btn.gameObject);
		}
	}

	protected void InitButton(string btnName, UnityAction onClick) {
		Transform btn = transform.FindChild(btnName);
		if (btn == null) {
			Log.Warning("Button {0} not found!!!", btnName);
			return;
		}

		GameObject btnObj = btn.gameObject;
		btnObj.GetComponent<Button>().onClick.AddListener(onClick);

	}

	protected void InitButton(string btnName, UnityAction<GameObject> onClick) {
		// todo
	}
}
