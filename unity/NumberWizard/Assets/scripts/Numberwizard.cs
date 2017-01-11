using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numberwizard : MonoBehaviour {
    int max;
    int min;
    int guess;
    
    public int maxGuessesAllowed = 5;

    public Text text;

	// Use this for initialization
	void Start () {
        StartGame();
	}
	
    void StartGame() {
        max = 1001;
        min = 1;
        NextGuess();
    }

    void NextGuess() {
        guess = Random.Range(min, max +1) ;
        text.text = guess.ToString();
        maxGuessesAllowed--;
        if(maxGuessesAllowed <= 0) {
            Application.LoadLevel("Win");
        }
    }

    public void GuessHigher() {
        min = guess;
        NextGuess();
    }

    public void GuessLower() {
            max = guess;
            NextGuess();
    }

}
