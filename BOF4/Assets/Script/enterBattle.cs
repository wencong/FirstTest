using UnityEngine;
using System.Collections;

public class enterBattle : MonoBehaviour {

    private GameObject m_MainCamera = null;
    public GameObject prefab;
    //private GameObject m_directLight = null;
	// Use this for initialization
	void Start () {
        m_MainCamera = GameObject.Find("Main Camera");
        if (!m_MainCamera)
        {
            print("main camera not exit");
        }

        GameObject monster1 = GameObject.Instantiate(prefab) as GameObject;
        GameObject monster2 = GameObject.Instantiate(prefab) as GameObject;
        GameObject monster3 = GameObject.Instantiate(prefab) as GameObject;

        GameObject[] monsters = { monster1, monster2, monster3 };

        GameObject role = GameObject.Find("sphere");

        monster1.transform.position = role.transform.position + new Vector3(0, 100, 0);
        monster2.transform.position = role.transform.position + new Vector3(30, 110, 0);
        monster3.transform.position = role.transform.position + new Vector3(-30, 100, 0);

	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
