using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public int hitPoints = 1;
    public int scorePoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Nave>()) return;

        if (hitPoints > 1)
        {
            hitPoints--;
            return;
        }

        Score.Instance.UpdateScore(scorePoints);

        GameObject boom =
            Instantiate(explosion, transform.position, transform.rotation);

        Destroy(boom, 3);
        Destroy(gameObject);
    }
}
