using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	void Start () {
	    musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager) {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.ChangeVolume(volume);
        } 
        else {
            Debug.LogWarning("No music manager found");
        }
	}
}
