using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    static public int player1Score,player2Score;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        player1Score = 0;
        player2Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = player1Score + " - " + player2Score;
	}
}
