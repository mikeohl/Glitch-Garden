using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Camera myCamera;
	private GameObject defenderParent;

	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find("Defenders");
		
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		// Debug.Log ("mouse clicked");
		GameObject newDefender = Instantiate (Button.selectedDefender, SnapToGrid (MouseClickToWorldPoint()), Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
		Debug.Log(SnapToGrid(MouseClickToWorldPoint()));
		
	}
	
	Vector2 SnapToGrid (Vector2 worldPoint) {
		return new Vector2 (Mathf.RoundToInt(worldPoint.x), Mathf.RoundToInt(worldPoint.y));
	}
	
	Vector2 MouseClickToWorldPoint () {
		// Arbitrary z-distance from camera 10f
		
		myCamera = GameObject.FindObjectOfType<Camera>();
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		return myCamera.ScreenToWorldPoint(mousePosition);
	}
}
