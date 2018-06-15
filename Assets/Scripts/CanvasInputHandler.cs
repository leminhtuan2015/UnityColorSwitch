using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasInputHandler : MonoBehaviour {

	private bool isPauseGame = false;
	public Button playButton;
	public Button pauseButton;
    public Button rePlayButton;

	// Use this for initialization
	void Start () {
        rePlayButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPauseTapped(){
		isPauseGame = !isPauseGame;

		Debug.Log ("OnPauseTapped: " + isPauseGame);

		if (isPauseGame) {
			Time.timeScale = 0;
			playButton.gameObject.SetActive (true);
			pauseButton.gameObject.SetActive (false);
		} else {
			Time.timeScale = 1;
			playButton.gameObject.SetActive (false);
			pauseButton.gameObject.SetActive (true);
		}

	}

    public void ShowReplay()
    {
        rePlayButton.gameObject.SetActive(true);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
