using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ResourceMgr : Singleton<ResourceMgr> {

    public T Load<T>(string path) where T : UnityEngine.Object {
        return Resources.Load<T>(path);
    }

    public void UnLoad<T>(T obj) where T : UnityEngine.Object {
        Resources.UnLoadAsset(obj);
    }
}

