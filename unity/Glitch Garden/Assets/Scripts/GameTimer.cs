
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 90;

    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();

        winLabel = GameObject.Find("You Won");
        if (!winLabel) {
            Debug.LogWarning("No win label");
        }
        winLabel.SetActive(false);
	}
	
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
            // Handle win condition
            isEndOfLevel = true;
            audioSource.Play();
            winLabel.SetActive(true);
            ClearPlaySpace();
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
	}

    void ClearPlaySpace() {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach ( GameObject obj in taggedObjectArray) {
            Destroy(obj);
        }
    }

    void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}
