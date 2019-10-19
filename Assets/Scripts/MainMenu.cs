using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public Text text;
	
	// Update is called once per frame
	void Update () 
    {   
        if (Input.anyKey) SceneManager.LoadScene("Game");
        
        float alpha = Mathf.Lerp(0,1,Mathf.PingPong(Time.time,1));
        Color color = text.color;
        color.a = alpha;
        text.color = color;
	}
}
