using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarJumpManager : MonoBehaviour {

    public float upForce = 5000.0f;

    Rigidbody carRigidbody;

	// Use this for initialization
	void Start () {
        carRigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            carRigidbody.AddForce(0, upForce, 0, ForceMode.Impulse);
        }
	}
}
