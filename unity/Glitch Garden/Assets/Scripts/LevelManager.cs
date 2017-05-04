using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start () {
        if (autoLoadNextLevelAfter <= 0) {
        }
        else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    void AutoLoadLevel(string name) {
    }

    public void LoadLevel(string name ) {
        Debug.Log("Level load rec " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest() {
        Debug.Log("I want to quit");
        Application.Quit();
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
