using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour {

    public GameObject ball, player1,player2;
    public GameObject ballSpawner,player1Spawner,player2Spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
           RespawnBall();
        else if(other.CompareTag("Player1"))
           RespawnPlayer1();
        else if(other.CompareTag("Player2"))
            RespawnPlayer2();
    }


    void RespawnBall()
    {
        ball.transform.position = ballSpawner.transform.position; 
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

    void RespawnPlayer1()
    {
        player1.transform.position = player1Spawner.transform.position;
        player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

    void RespawnPlayer2()
    {
        player2.transform.position = player2Spawner.transform.position; 
        player2.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        player2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
