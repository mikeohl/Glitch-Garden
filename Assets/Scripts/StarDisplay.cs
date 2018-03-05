/* Star display manages the UI element that displays
 * the star currency available to the player. */

using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    public enum Status {FAILURE, SUCCESS};

    private int stars = 100;
    private Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        UpdateDisplay ();
    }
    
    public void AddStars (int amount) {
        stars += amount;
        UpdateDisplay ();
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
