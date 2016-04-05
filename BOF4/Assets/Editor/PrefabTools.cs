using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;

public class PrefabTools : Editor {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	[MenuItem("Tools/修改所有模型材质为Diffuse")]
	public static void ModifyPrefabMatToDiffuse() {
		string[] szFileArray = Directory.GetFiles("Assets/Resources/Character", "*.mat", SearchOption.AllDirectories);

		Shader shader = Shader.Find("Mobile/Diffuse");
		for (int i = 0; i < szFileArray.Length; ++i) {
			string szMatPath = szFileArray[i];
			Material mat = AssetDatabase.LoadAssetAtPath<Material>(szMatPath);
			mat.shader = shader;
		}
	}


	[MenuItem("Tools/WWW Test")]
	public static void WWWTest() {
		WWW w = new WWW("http://127.0.0.1:8888/jxsj_profiler");
	    
		Debug.Log(w.text);
	}
}

