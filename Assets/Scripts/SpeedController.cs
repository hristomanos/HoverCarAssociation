using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {

    public Rigidbody m_body;
    public float maxSpeed = 200f;

    // Use this for initialization
    void Start()
    {
        m_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_body.velocity.magnitude > maxSpeed)
        {
            m_body.velocity = m_body.velocity.normalized * maxSpeed;
        }
    }
}
