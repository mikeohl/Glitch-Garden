/* DefenderCurrency allows Unity editor to set the star cost
 * of each defender. Defender can also add stars to the 
 * total in StarDisplay.
 */

using UnityEngine;

public class DefenderCurrency : MonoBehaviour {

	public int starCost = 10; // default, change in editor

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStars (int amount) {
		starDisplay.AddStars (amount);
	}
}
