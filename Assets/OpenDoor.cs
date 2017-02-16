using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    Animator anim;
    AudioSource doorsound;
	// Use this for initialization
	void Start () {
        anim = gameObject.transform.parent.GetComponent<Animator>();
        doorsound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "GearVR")
        {
            Debug.Log("bla");
            anim.SetTrigger("moveOpen");
            doorsound.Play();
        }
    }
    void OnTriggerLeave(Collider col)
    {
        if (col.gameObject.name == "GearVR")
        {
            anim.SetTrigger("idle");
        }
    }
}
