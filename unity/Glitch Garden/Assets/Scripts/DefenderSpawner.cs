using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    private GameObject defenderParent;

	void Start () {
        myCamera = FindObjectOfType<Camera>();

        defenderParent = GameObject.Find("Defenders");
        if(!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }

	}
	
    private void OnMouseDown() {
        Vector2 pos = SnapToGrid(CalculateWorldPosition());
        GameObject newDefender = Instantiate(Button.selectedDefender, pos, Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;

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
