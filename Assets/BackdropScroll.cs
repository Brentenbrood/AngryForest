using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScroll : MonoBehaviour {

    public GameObject backdrop1;
    public GameObject backdrop2;

    private float bz;

	// Use this for initialization
	void Start () {
        bz = -94f;
    }
	
	// Update is called once per frame
	void Update () {
        bz += Time.deltaTime * 5.2f;
        backdrop1.transform.position = new Vector3(backdrop1.transform.position.x, backdrop1.transform.position.y, bz);
        backdrop2.transform.position = new Vector3(backdrop2.transform.position.x, backdrop2.transform.position.y, bz);

    }
}
