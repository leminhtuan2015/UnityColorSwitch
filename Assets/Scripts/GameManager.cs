using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("R")){
			GameOver ();
		}
	}

	void GameOver() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

    public void ShowReplay(){
        Debug.Log("Show Replayeee");

        canvas.gameObject.GetComponent<CanvasInputHandler>().ShowReplay();
    }
}
