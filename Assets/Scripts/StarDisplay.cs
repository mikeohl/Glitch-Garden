using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	public enum Status {FAILURE, SUCCESS};

	private int stars = 100;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		UpdateDisplay ();
		
		// stars = GameObject.FindObjectOfType<Stars>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars (int amount) {
		stars += amount;
		UpdateDisplay ();
		// print (amount + " stars added to display");
	}
	
	public Status UseStars (int amount) {
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	public void UpdateDisplay () {
		text.text = stars.ToString ();
	}
}
