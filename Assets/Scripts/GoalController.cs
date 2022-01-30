using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    
    public GameObject ball;
    public GameObject ballSpawner;

    public Rigidbody player1, player2;
    public Transform player1Respawner, player2Respawner;

    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("Player2Goal"))
            Player1Scores(other);
        else
            Player2Scores(other);
    }


    private void Player1Scores(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.player1Score += 1;
            Debug.Log("Player 1 score: " + ScoreManager.player1Score);

            ball.transform.position = ballSpawner.transform.position; // Move the ball to the ball spawner position
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero; // zero out any velocity and angular velocity.
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            player1.transform.position = player1Respawner.position;
            player1.transform.rotation = player1Respawner.rotation;

            player2.transform.position = player2Respawner.position;
            player2.transform.rotation = player2Respawner.rotation;


        }
    }

    private void Player2Scores(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.player2Score += 1;
            Debug.Log("Player 2 score: " + ScoreManager.player2Score);
            
            ball.transform.position = ballSpawner.transform.position; // Move the ball to the ball spawner position
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero; // zero out any velocity and angular velocity.
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            player1.transform.position = player1Respawner.position;
            player1.transform.rotation = player1Respawner.rotation;

            player2.transform.position = player2Respawner.position;
            player2.transform.rotation = player2Respawner.rotation;
        }
    }
}
