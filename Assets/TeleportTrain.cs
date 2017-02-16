using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrain : MonoBehaviour {

    public GameObject colbox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "GearVR")
        {
            Debug.Log("teleport!");
            col.transform.position = new Vector3(col.transform.position.x, 8, col.transform.position.z);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "GearVR")
        {
            Destroy(colbox);
        }
    }
}
