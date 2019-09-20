using System.Collections;
using UnityEngine;

public class Naves : MonoBehaviour
{
    public int lives = 3;
    public GameObject nave;
    public GameObject gameOver;

    public static Naves Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        StartCoroutine(Create(0));
    }

    public void Respawn ()
    {
        if (lives > 0)
        {
            lives--;
            StartCoroutine(Create(1));
        }

        else
        {
            gameOver.SetActive(true);
        }
    }

    IEnumerator Create (float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(nave, transform.position, transform.rotation);
    }
}
