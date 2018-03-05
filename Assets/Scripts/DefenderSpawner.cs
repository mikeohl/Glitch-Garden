/* DefenderSpawner handles placement of defender in grid on user mouse click. */

using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private Camera myCamera;
	private GameObject defenderParent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        // Group defenders in defender GameObject
		defenderParent = GameObject.Find("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}

    // Call SpawnDefender for selected defender on player mouse click
    void OnMouseDown() {
        if (SelectDefenderButton.selectedDefender) {
            int starCost = SelectDefenderButton.selectedDefender.GetComponent<DefenderCurrency>().starCost;
            if (starDisplay.UseStars(starCost) == StarDisplay.Status.SUCCESS) {
                SpawnDefender();
            } else {
                Debug.Log("Insufficient Stars");
            }
        }
    }

    // Place selected defender on board
    private void SpawnDefender () {
        if (SelectDefenderButton.selectedDefender) {
            GameObject newDefender = Instantiate(SelectDefenderButton.selectedDefender, 
                                                 SnapToGrid(MouseClickToWorldPoint()), 
                                                 Quaternion.identity) as GameObject;
            newDefender.transform.parent = defenderParent.transform;
        }
	}
	
    // Set position of defender to center of cell
	private Vector2 SnapToGrid (Vector2 worldPoint) {
		return new Vector2 (Mathf.RoundToInt(worldPoint.x), Mathf.RoundToInt(worldPoint.y));
	}
	
	private Vector2 MouseClickToWorldPoint () {
		// 10.0f in mousePosition vector3 is arbitrary z-distance from camera
		myCamera = GameObject.FindObjectOfType<Camera>();
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);
		return myCamera.ScreenToWorldPoint(mousePosition);
	}
}
