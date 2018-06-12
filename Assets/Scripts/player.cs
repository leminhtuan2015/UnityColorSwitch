using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyUtils;

public class player : MonoBehaviour {

	public float jumpForce = 10f; 
	public Color currentColor;

	public Rigidbody2D myRigidbody2D;
	public SpriteRenderer spriteRenderer;
	public Score score;

	// Use this for initialization
	void Start () {
		GetGameObjectComponents ();
		SetRandomColor (Utils.colors);
	}
	
	// Update is called once per frame
	void Update () { 
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
			myRigidbody2D.velocity = Vector2.up * jumpForce;
		}
	}

	void GetGameObjectComponents (){
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
//		Debug.Log ("collider" + collider.tag );

		if(collider.tag == "ColorChanger"){
			currentColor = Utils.HexToColor(collider.gameObject.name);
			spriteRenderer.color = currentColor;
			score.UpdateScore (1);
			Destroy (collider.gameObject);
			return;
		}

		if(collider.tag != Utils.ColorToHex(currentColor)){
			Debug.Log ("Game Over");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	void SetRandomColor (Color[] colors) {
		int index = Random.Range (0, colors.Length);
		currentColor = colors [index];

		Debug.Log ("currentColor: " + Utils.ColorToHex(currentColor));
		spriteRenderer.color = currentColor;
	}
}
