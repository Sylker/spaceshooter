using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 10;
    public float rate = 0.5f;
    public int hit = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime * speed;
        transform.position = pos;
    }
}
