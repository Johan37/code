using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name ) {
        Debug.Log("Level load rec " + name);
    }

    public void QuitRequest() {
        Debug.Log("I want to quit");
    }
}
