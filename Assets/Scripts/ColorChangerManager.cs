using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerManager : MonoBehaviour {

	public float distance = 5f;
	private int lastColorIndex = -1;

	// Use this for initialization
	void Start () {
		CreateColorChanger ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateColorChanger() {
		GameObject colorChanger = Resources.Load ("Prefabs/ColorChanger") as GameObject;
			
		for (int y = 0; y < 100; y++) {
			Color randomColor = GetRandomColor (MyUtils.Utils.colors);
//			colorChanger.GetComponent<SpriteRenderer> ().color = randomColor;
			colorChanger.GetComponent<SpriteRenderer> ().color = Color.white;
			colorChanger.name = MyUtils.Utils.ColorToHex(randomColor);

			Instantiate(colorChanger, new Vector3(0f, distance + y * distance, 0f), Quaternion.identity);
		}
	}

	Color GetRandomColor (Color[] colors) {
		int index = Random.Range (0, colors.Length);
			
		if (index != lastColorIndex) {
			lastColorIndex = index;
			return colors [index];
		}

		return GetRandomColor (MyUtils.Utils.colors);
	}
}
