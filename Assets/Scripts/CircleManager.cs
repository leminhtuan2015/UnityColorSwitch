using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {

	public float distance = 10f;

	// Use this for initialization
	void Start () {
		CreateCircle ();
	}

	// Update is called once per frame
	void Update () {

	}

	void CreateCircle() {

		GameObject smallCircle = Resources.Load ("Prefabs/SmallCircle") as GameObject;
//		GameObject bigCircle = Resources.Load ("Prefabs/BigCircle") as GameObject;

		for (int y = 0; y < 5; y++) {
			Instantiate(smallCircle, new Vector3(0f, distance + y * distance, 0f), Quaternion.identity);
//			Instantiate(bigCircle, new Vector3(0f, distance + y * distance, 0f), Quaternion.identity);
		}
	}
}