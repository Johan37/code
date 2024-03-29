﻿using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;

    private void Start() {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.LogWarning(name + " has no cost text"); }
        else {
            costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
        }
    }

    private void OnMouseDown() {
        foreach (Button thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab; 
    }
}
