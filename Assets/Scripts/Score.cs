using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static string BestScoreKey = "BestScore";

	private int currentScore = 0;
	private int bestScore = 0;

	private Text scoreText;
	private Text bestScoreText;

	// Use this for initialization
	void Start () {
		GetMyComponents ();
		GetBestScore ();
		UpdateScore (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore (int scoreNumber) {
		currentScore = currentScore + scoreNumber;

		if(currentScore > bestScore){
			bestScore = currentScore;
			StoreBestScore (bestScore);
		}

		scoreText.text = "" + currentScore;
		bestScoreText.text = "Best Score:" + bestScore;
	}

	void GetBestScore(){
		bestScore = PlayerPrefs.GetInt(BestScoreKey);
		Debug.Log ("Best Score: " + bestScore);
	}

	void StoreBestScore(int bestScore){
		PlayerPrefs.SetInt (BestScoreKey, bestScore);
	}

	void GetMyComponents(){
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent<Text> ();
		bestScoreText = GameObject.FindGameObjectWithTag ("BestScoreText").GetComponent<Text> ();
	}
}
