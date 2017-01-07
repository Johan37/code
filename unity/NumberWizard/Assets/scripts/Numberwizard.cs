using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numberwizard : MonoBehaviour {
    int max;
    int min;
    int guess;

	// Use this for initialization
	void Start () {
        StartGame();
	}
	
    void StartGame() {
        max = 1000;
        min = 1;
        guess = 500;

        print("==========================");
		print("Welcome to Number Wizard!");
		print("Pick a number in your head, don't tell me");


        print("The highest number you can pick " + max);
        print("The lowest number you can pick " + min);

        print("Is the number higher or lower than " + guess + " ?");
        print("Up for yes, down for lower, return for equal");

        max++;
    }

    void NextGuess() {
        guess = (max + min) / 2;
        print("Is the number higher or lower than " + guess + " ?");
        print("Up for yes, down for lower, return for equal");
    }

	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            print("I won!");
            StartGame();
        }
	}
}
