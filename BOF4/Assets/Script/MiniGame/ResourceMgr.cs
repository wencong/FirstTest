using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ResourceMgr : Singleton<ResourceMgr> {

    public T Load<T>(string path) where T : UnityEngine.Object {
        return Resources.Load<T>(path);
    }

    public void UnLoad<T>(T obj) where T : UnityEngine.Object {
        Resources.UnloadAsset(obj);
    }

	public UnityEngine.Object Spawn<T>(string path) where T : UnityEngine.Object {
		T asset = Load<T>(path);
		UnityEngine.Object inst = null;

		if (asset != null) {
			inst = UnityEngine.Object.Instantiate(asset);
		}

		return inst;
	}
}

