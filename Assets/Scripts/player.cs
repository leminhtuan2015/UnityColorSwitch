using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using MyUtils;

public class player : MonoBehaviour {

	public float jumpForce = 10f; 
	public Color currentColor;

	public Rigidbody2D myRigidbody2D;
	public SpriteRenderer spriteRenderer;
	public Score score;

	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		GetGameObjectComponents ();
		SetRandomColor (Utils.colors);
	}
	
	// Update is called once per frame
	void Update () { 
		if((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && !EventSystem.current.IsPointerOverGameObject()){
			Debug.Log ("Tapped");

			if (isGameOver) {
				ReStartGame ();
			} else {
				myRigidbody2D.velocity = Vector2.up * jumpForce;
			}
		}
	}

	void GetGameObjectComponents (){
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
//		Debug.Log ("collider tag: " + collider.tag );

		if(collider.tag == "ColorChanger"){
			currentColor = Utils.HexToColor(collider.gameObject.name);
			spriteRenderer.color = currentColor;
			score.UpdateScore (1);
			Destroy (collider.gameObject);
			return;
		}

		if(collider.tag == "Ground"){
			Debug.Log ("Hit Ground");
			myRigidbody2D.velocity = Vector2.up * jumpForce / 2;
			return;
		}

		if(collider.tag != Utils.ColorToHex(currentColor)){
			StopGame ();
		}
	}

	void OnBecameInvisible() {
		Debug.Log ("Player OnBecameInvisible");

		GameOver ();
	}

	void SetRandomColor (Color[] colors) {
		int index = Random.Range (0, colors.Length);
		currentColor = colors [index];

//		Debug.Log ("currentColor: " + Utils.ColorToHex(currentColor));
		spriteRenderer.color = currentColor;
	}

	void StopGame(){
		Time.timeScale = 0;
		isGameOver = true;
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	void ReStartGame(){
		isGameOver = false;
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	void GameOver() {
		Debug.Log ("Game Over");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

}
