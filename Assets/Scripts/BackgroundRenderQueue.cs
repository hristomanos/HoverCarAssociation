using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRenderQueue : MonoBehaviour {

    public GameObject bg;

	// Use this for initialization
	void Start () {
        Material material = bg.GetComponent<MeshRenderer>().material;
        material.renderQueue = 2000;
	}
	
	
}
