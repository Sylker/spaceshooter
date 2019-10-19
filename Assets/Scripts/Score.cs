using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;
    int score;
    int lastScore;

    public static Score Instance;

	private void Awake() {
		if(Instance == null) Instance = this;
	}

    void Start()
    {
        // PlayerPrefs.DeleteKey("LastScore");
        
        text = GetComponent<Text>();
       
        if (PlayerPrefs.HasKey("LastScore"))
        {
            lastScore = PlayerPrefs.GetInt("LastScore");
        }
        
        UpdateScore(0);
    }

    public void UpdateScore(int value) {
        score += value;
        text.text = score.ToString();
        PlayerPrefs.SetInt("LastScore", score);
    }
    
    public bool NewRecord
    {
        get
        { 
            return score > lastScore; 
        }
    }
}
