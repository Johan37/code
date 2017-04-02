using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;

    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
    }

    void OnLevelWasLoaded (int level) {
        AudioClip thisLevelMusic = levelMusicArray[level];
        Debug.Log("Playing clip: " + level + " " + thisLevelMusic);

        if (thisLevelMusic) { // if ther is some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
