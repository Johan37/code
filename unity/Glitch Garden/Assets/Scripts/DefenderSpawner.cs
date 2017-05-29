using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

	void Start () {
        myCamera = FindObjectOfType<Camera>();
        starDisplay = FindObjectOfType<StarDisplay>();

        defenderParent = GameObject.Find("Defenders");
        if(!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }

	}
	
    private void OnMouseDown() {
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStar(defenderCost) == StarDisplay.Status.SUCCESS) {
            Vector2 pos = SnapToGrid(CalculateWorldPosition());
            GameObject newDefender = Instantiate(defender, pos, Quaternion.identity);
            newDefender.transform.parent = defenderParent.transform;
        }
        else {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    private Vector2 CalculateWorldPosition() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
