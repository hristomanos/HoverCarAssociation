using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject cam;
    public GameObject car;
    public GameObject cameraRig;
    public GameObject ballCameraRig;
    public GameObject target;
    public GameObject ball;
    public int player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SwitchTarget();
    }

    private void LateUpdate()
    {
        BallCam();
        CarCam();
    }

    void CarCam()
    {
        if (target == car)
        {
            cam.transform.position = cameraRig.transform.position;
        }
    }


    void BallCam()
    {
        if (target == ball)
        {
            cam.transform.position = ballCameraRig.transform.position;
            cam.transform.LookAt(ball.transform.position);
        }
    }

    void SwitchTarget()
    {
        if (player == 1)
        {

            if ((Input.GetKeyDown(KeyCode.C)))
            {
                if (target == car)
                {
                    target = ball;
                }
                else
                {
                    target = car;
                }
            }
        }
        else if (player == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                if (target == car)
                {
                    target = ball;
                }
                else
                {
                    target = car;
                }
            }
        }
    }
}
