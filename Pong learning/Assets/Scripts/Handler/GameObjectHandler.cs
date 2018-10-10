using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectHandler : MonoBehaviour {
    private List<GameObject> objects;
    private List<string> objectName;

    void Start()
    {
        objects = new List<GameObject>();
        objectName = new List<string>();
    }

    public GameObject ReceiveObject(string name)
    {
        return objects[objectName.IndexOf(name)];
    }
	
    public void InsertObject(GameObject obj, string name)
    {
        objects.Add(obj);
        objectName.Add(name);
    }

    public void RemoveObject(string name)
    {
        objects.RemoveAt(objectName.IndexOf(name));
        objectName.RemoveAt(objectName.IndexOf(name));
    }
	
    public int ReceiveIndex(string name)
    {
        return objectName.IndexOf(name);
    }
}
