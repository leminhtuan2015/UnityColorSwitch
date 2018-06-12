using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform playerTransform;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		// playerTransform : transform component of player
		// transform: transform component of this camera GameObject

		if(playerTransform.position.y > transform.position.y){
			transform.position = new Vector3 (transform.position.x, playerTransform.position.y, transform.position.z);
		}
	}
}
