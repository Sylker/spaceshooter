using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Naves : MonoBehaviour {
	public Text lifeCounter;
	public int lives = 3;
	public GameObject nave;
	public GameObject gameOver;
	public Transform grid;
	public GameObject lifeCounterIcon;
	public Button restartButton;
    AudioSource audioSource;

	List<GameObject> lifeCounterIcons = new List<GameObject> ();

	public static Naves Instance;

	private void Awake() {
		if(Instance == null) Instance = this;
        audioSource = GetComponent<AudioSource>();
	}

	void Start() {
		lifeCounter.text = "x" + lives+1;
		restartButton.onClick.AddListener (Restart);
		for (var i = 0; i < lives; i++)
			AddLifeIcon ();
		StartCoroutine(Create(0));
	}

	void Restart () {
        audioSource.Play();
		SceneManager.LoadScene (0);
	}

	public void Respawn() {
		if(lives > 0) { 
			lives--;
            RemoveLifeIcon();
            StartCoroutine(Create(1)); 
		}
		else { 
			gameOver.SetActive(true);
		}
		lifeCounter.text = "x" + lives;
	}

	IEnumerator Create(float time) {
		yield return new WaitForSeconds(time);
		Instantiate(nave, transform.position, transform.rotation);
	}

	void AddLifeIcon ()
	{
		GameObject newIcon = Instantiate (lifeCounterIcon, grid);
		newIcon.SetActive (true);
		lifeCounterIcons.Add (newIcon);
	}

	void RemoveLifeIcon()
	{
        int index = lifeCounterIcons.Count - 1;
        GameObject icon = lifeCounterIcons[index];
        lifeCounterIcons.Remove(icon);
        Destroy(icon);
    }
}
