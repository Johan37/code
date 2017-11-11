using UnityEngine;
using UnityEngine.UI;



public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE};

    private Text starText;
    private int stars = 100;

	void Start () {
        starText = GetComponent<Text>();
        UpdateDisplay();
	}

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStar(int amount) {
        if (stars >= amount) {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
