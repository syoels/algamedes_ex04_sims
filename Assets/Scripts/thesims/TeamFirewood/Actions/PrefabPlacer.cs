using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPlacer : MonoBehaviour {

	public GameObject generatedPrefab; 
	public Transform dropParent = null;
	public float secondsBetweenPLacements = 15f;
	public Rect screenSize;
	private int amountGenerated = 0;
	public int maxAmount = 5;

	// Use this for initialization
	void Start () {
		float mapX = 25f;
		float mapY = 25f;
		float minX;
		float maxX;
		float minY;
		float maxY;
		float vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		minX = horzExtent - mapX / 2f;
		maxX = mapX / 2f - horzExtent;
		minY = vertExtent - mapY / 2f;
		maxY = mapY / 2f - vertExtent;
		screenSize = new Rect (new Vector2(minX, minY), new Vector2(maxX, maxY));
	
		Invoke ("generatePrefInRandomPosition", secondsBetweenPLacements);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generatePrefInRandomPosition(){
		float x = Random.Range (screenSize.min.x, screenSize.max.x);
		float y = Random.Range (screenSize.min.y, screenSize.max.y);
		GameObject prefab = Instantiate(generatedPrefab, new Vector2(x, y), transform.rotation);
		amountGenerated++; 
		if (dropParent != null) {
			prefab.transform.parent = dropParent;
		}
		if (amountGenerated < maxAmount) {
			Invoke ("generatePrefInRandomPosition", secondsBetweenPLacements);
		}

	}


}
