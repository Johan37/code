using UnityEngine;
using UnityEngine.UI;



public class StarDisplay : MonoBehaviour {

    private Text starText;
    private int stars = 0;

	void Start () {
        starText = GetComponent<Text>();
	}

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public void UseStar(int amount) {
        stars -= amount;
        UpdateDisplay();
    }
}
