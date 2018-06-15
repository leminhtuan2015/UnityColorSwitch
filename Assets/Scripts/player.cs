using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using MyUtils;

public class player : MonoBehaviour {

	public float jumpForce = 8f; 
	public Color currentColor;

	public Rigidbody2D myRigidbody2D;
	public SpriteRenderer spriteRenderer;  
	public Score score;
	public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
		GetGameObjectComponents ();
		SetRandomColor (Utils.colors);
	}
	
	// Update is called once per frame
	void Update () { 
		if(gameObject && (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) 
			&& !EventSystem.current.IsPointerOverGameObject()){

			myRigidbody2D.velocity = Vector2.up * jumpForce;
		}
	}

	void GetGameObjectComponents (){
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
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
			myRigidbody2D.velocity = Vector2.up * jumpForce / 2;
			return;
		}

        if(collider.tag == "BackGroundBar"){
            return;
        }

		if(collider.tag != Utils.ColorToHex(currentColor)){
			StopGame ();
		}
	}

	void OnBecameInvisible() {
//		GameOver ();
	}

	void SetRandomColor (Color[] colors) {
		int index = Random.Range (0, colors.Length);
		currentColor = colors [index];

//		Debug.Log ("currentColor: " + Utils.ColorToHex(currentColor));
		spriteRenderer.color = currentColor;
	}

	void StopGame(){
//		Time.timeScale = 0;
		Instantiate(playerExplosion, transform.position, transform.rotation);
		DestroyGameObject ();
	}

	void DestroyGameObject(){
		Destroy (gameObject);
	}

	void GameOver() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

}
