using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private int currentScore = 0;

	// Use this for initialization
	void Start () {
		UpdateScore (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore (int scoreNumber) {
		currentScore = currentScore + scoreNumber;
		GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text> ().text = "Best Score: " + currentScore;
	}
}
