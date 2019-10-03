using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;
    int score;

    public static Score Instance;

	private void Awake() {
		if(Instance == null) Instance = this;
	}

    void Start()
    {
        text = GetComponent<Text>();
        UpdateScore(0);
    }

    public void UpdateScore(int value) {
        score += value;
        text.text = score.ToString();
    }

}
