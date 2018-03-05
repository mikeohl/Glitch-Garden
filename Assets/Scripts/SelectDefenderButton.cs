/* SelectDefenderButton controls the Defender selection.
 * Initializes the UI of selectable defender. Sets selected 
 * defender when user clicks a defender in UI.
 */

using UnityEngine;
using UnityEngine.UI;

public class SelectDefenderButton : MonoBehaviour {

	public static GameObject selectedDefender;
	
	public GameObject defenderPrefab;

	private SelectDefenderButton [] buttonArray;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<SelectDefenderButton>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {
			Debug.LogWarning (name + " has no cost indicator");
		}
		DefenderCurrency thisDefender = defenderPrefab.GetComponent<DefenderCurrency>();
		costText.text = thisDefender.starCost.ToString();
	}
	
    // Change color of selected defender to show it is selected
    // and set selectedDefender
	void OnMouseDown () {
		foreach (SelectDefenderButton thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;	
	}
}
