using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour 
{
    public Button button { get; private set; }
    public static FireButton Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy (gameObject);
        
        button = GetComponent<Button>();
    }
}
