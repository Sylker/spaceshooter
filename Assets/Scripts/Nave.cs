using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour
{
    public float speed = 5;
    public GameObject explosion;
    public Shot shot;
    public Transform frontCannon;
    Animator animator;
    bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        position.x += horizontal * Time.deltaTime * speed;
        position.y += vertical * Time.deltaTime * speed;

        transform.position = position;
        animator.SetFloat("horizontal", horizontal);

        if (Input.GetKey(KeyCode.Space) && !shooting)
        {
            shooting = true;
            StartCoroutine(Tiro());
        }
    }

    IEnumerator Tiro ()
    {
        yield return new WaitForSeconds(shot.rate);
        Instantiate(shot.gameObject, frontCannon.position, Quaternion.identity);
        shooting = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Shot>()) return;

        GameObject boom =
            Instantiate(explosion, transform.position, transform.rotation);

        Destroy(boom, 3);

        Naves.Instance.Respawn();
        Destroy(gameObject);
    }
}
