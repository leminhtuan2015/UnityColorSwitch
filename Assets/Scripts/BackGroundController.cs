using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {
    
    public GameObject myCamera;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "CameraTop"){
            GameObject backGround = Resources.Load("Prefabs/BackGround") as GameObject;

            Instantiate(backGround, new Vector3(other.transform.position.x, other.transform.position.y + 10, 0f), Quaternion.identity);
        }

        if (other.tag == "CameraBottom")
        {
            Debug.Log("CameraBottom: " + other.tag);

            Destroy(this);
        }
    }
}
