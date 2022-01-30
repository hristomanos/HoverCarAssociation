using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCarController : MonoBehaviour {

	Rigidbody m_body;
    float m_deadZone = 0.1f;

    public float m_forwardAcceleration = 100.0f;
    public float m_backwardAcceleration = 50.0f;
    float m_currThrust = 0.0f;

    public float m_turnStrength = 20f;
    float m_currTurn = 0.0f;


    int m_layerMask;
    public float m_hoverForce = 9.0f;
    public float m_hoverHeight = 2.0f;
    public GameObject[] m_hoverPoints;





	void Start () {
        m_body = GetComponent<Rigidbody>();

        m_layerMask = 9 << LayerMask.NameToLayer("Player");
        m_layerMask = ~m_layerMask;
	}
	
	
	void Update () {

        HoverForce();

        //Main thrust
        m_currThrust = 0.0f;
        float accelerationAxis = Input.GetAxis("Verctical");
        if (accelerationAxis > m_deadZone)
        {
            m_currThrust = accelerationAxis * m_forwardAcceleration;
        }
        else if (accelerationAxis < -m_deadZone)
        {
            m_currThrust = accelerationAxis * m_backwardAcceleration;
        }

        //Turning
        m_currTurn = 0.0f;
        float turnAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(turnAxis) > m_deadZone)
        {
            m_currTurn = turnAxis;
        }
	}


    private void FixedUpdate()
    {
        //Forward
        if (Mathf.Abs(m_currThrust) > 0)
        {
            m_body.AddForce(transform.forward * m_currThrust);
        }

        //Turn
        if (m_currTurn > 0)
        {
            m_body.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength);
        }
        else if (m_currTurn < 0)
        {
            m_body.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength);
        }
    }


    private void OnDrawGizmos()
    {
       
    }

    private void HoverForce()
    {
        RaycastHit hit;
        for (int i = 0; i < m_hoverPoints.Length; i++)
        {
            var hoverPoint = m_hoverPoints[i];

            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, m_hoverHeight, m_layerMask))
            {
                m_body.AddForceAtPosition(Vector3.up * m_hoverForce * (1.0f - (hit.distance / m_hoverHeight)),hoverPoint.transform.position);
            }
            else
            {
                if (transform.position.y > hoverPoint.transform.position.y)
                {
                    m_body.AddForceAtPosition(hoverPoint.transform.up * m_hoverForce, hoverPoint.transform.position);
                }
                else
                    m_body.AddForceAtPosition(hoverPoint.transform.up * -m_hoverForce, hoverPoint.transform.position);
            }
        }
    }
}
