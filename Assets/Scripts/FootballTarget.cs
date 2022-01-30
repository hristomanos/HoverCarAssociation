using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballTarget : MonoBehaviour {

    public GameObject targetPrefab;
    public GameObject ball;
   
    GameObject target;
    int floorMask;

    bool hasDeployed = false;


	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //IgnorePlayerCollider();

        if (!hasDeployed)
            FindTarget();
        else
            MoveTarget();

    }

    void FindTarget()
    {
       
        RaycastHit floorHit;
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        if (Physics.Raycast (ball.transform.position, ball.transform.TransformDirection(Vector3.down), out floorHit, Mathf.Infinity, layerMask))
        {
            target = Instantiate(targetPrefab, floorHit.point, targetPrefab.transform.rotation);
            hasDeployed = true;
        }
    }

    void MoveTarget()
    {
        RaycastHit floorHit;
        int layerMask = 1 << 9;

        layerMask = ~layerMask;
        if (Physics.Raycast(ball.transform.position, Vector3.down, out floorHit, Mathf.Infinity, layerMask))
        {
            target.transform.position = new Vector3(floorHit.point.x, floorHit.point.y, floorHit.point.z);
            
        }
    }


    void IgnorePlayerCollider()
    {
        // Bit shift the index of the layer (9) to get a bit mask
        int layerMask = 1 << 9;

        // This would cast rays only against colliders in layer 9.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ball.transform.position, ball.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
