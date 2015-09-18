using UnityEngine;
using System.Collections;
using System;

public class cameraTrace : MonoBehaviour {
	private GameObject m_MainCamera = null;
    private GameObject m_directLight = null;
	private Vector3 m_defaultDir = new Vector3(-1, 1, -1);
	private Quaternion m_RotateTo;
	private float m_distance = 5;
    
	private float slerp = 0;

	private bool m_bMoveFront = false;
	private bool m_bMoveBack = false;
	private bool m_bMoveLeft = false;
	private bool m_bMoveRight = false;
    private float m_nMoveSpeed = 0.05f;

    public GameObject prefab;
	// Use this for initialization
    //private Quaternion[] m_arrRotate;
    private bool m_bTobeRotate = false;

    void Awake() {
        MonsterCreator.getInstance().loadSettings();    
    }

	void Start () {
		m_MainCamera = GameObject.Find ("Main Camera");
		if (!m_MainCamera) {
			print("main camera not exit");
		}

        m_directLight = GameObject.Find("Directional light");
        if (!m_directLight)
        {
            print("light is not exit");
        }
		m_defaultDir.Normalize ();
		m_MainCamera.transform.position = gameObject.transform.position + m_defaultDir * m_distance;
		m_MainCamera.transform.LookAt (gameObject.transform.position);

        m_RotateTo = m_MainCamera.transform.localRotation;
	}
	
	// Update is called once per frame
	void traceCamera() {
        Quaternion q = new Quaternion();

		if (Input.GetKeyDown (KeyCode.A)) 
		{
			q.eulerAngles = new Vector3(0, 90, 0);
            gameObject.transform.Rotate(q.eulerAngles);
            m_RotateTo = q * m_MainCamera.transform.localRotation;
            m_bTobeRotate = true;
		} 
		else if (Input.GetKeyDown (KeyCode.D)) 
		{
			q.eulerAngles =new Vector3(0, -90, 0);
            gameObject.transform.Rotate(q.eulerAngles);
            m_RotateTo = q * m_MainCamera.transform.localRotation;
            m_bTobeRotate = true;
		}
		else if (Input.GetKeyDown (KeyCode.W)) 
		{
			q.eulerAngles =new Vector3(30, 0, 0);
            m_RotateTo = m_MainCamera.transform.localRotation * q;
            m_bTobeRotate = true;
		}
		else if (Input.GetKeyDown (KeyCode.S)) 
		{
			q.eulerAngles =new Vector3(-30, 0, 0);
            m_RotateTo = m_MainCamera.transform.localRotation * q;
            m_bTobeRotate = true;
		}

        if (m_bTobeRotate)
        {
            Quaternion pQ = Quaternion.Slerp(m_MainCamera.transform.localRotation, m_RotateTo, slerp);
			m_defaultDir = pQ * new Vector3(0, 0, -1);
            m_MainCamera.transform.localRotation = pQ;
			slerp += 0.025f;
            if (slerp > 1.0f)
            {
                m_bTobeRotate = false;
                slerp = 0.0f;
            }
        }

        else
        {
            gameObject.transform.position +=
                    gameObject.transform.forward * Convert.ToInt32(m_bMoveFront) * m_nMoveSpeed +
                    gameObject.transform.forward * Convert.ToInt32(m_bMoveBack) * -m_nMoveSpeed +
                    gameObject.transform.right * Convert.ToInt32(m_bMoveRight) * m_nMoveSpeed +
                    gameObject.transform.right * Convert.ToInt32(m_bMoveLeft) * -m_nMoveSpeed;

        }
		m_MainCamera.transform.position = gameObject.transform.position + m_defaultDir * m_distance;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			m_bMoveFront = true;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			m_bMoveFront = false;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			m_bMoveBack = true;
		}
		
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			m_bMoveBack = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			m_bMoveLeft = true;
		}
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			m_bMoveLeft = false;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			m_bMoveRight = true;
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			m_bMoveRight = false;
		}
		traceCamera ();
	}

    void OnCollisionEnter(Collision obj)
    {
//         Enemy enemy = obj.gameObject.AddComponent<Enemy>();
//         enemy.Init();
        if (obj.gameObject.name == "Cube")
        {
            m_bMoveFront = m_bMoveBack = m_bMoveLeft = m_bMoveRight = false;
            DontDestroyOnLoad(m_MainCamera);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(m_directLight);
            Application.LoadLevel(1);
        }
        
    }
	
}
