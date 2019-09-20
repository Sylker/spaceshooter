using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] meteoros;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create ()
    {
        float time = Random.Range(.5f, 1.5f);
        yield return new WaitForSeconds(time);
        
        int stone = Random.Range(0, meteoros.Length - 1);
        float x = Random.Range(-3, 3);
        float y = transform.position.y;
        float z = transform.position.z;

        GameObject meteoro =
            Instantiate(meteoros[stone],
                        new Vector3(x, y, z),
                        transform.rotation);

        Destroy(meteoro, 2);
        StartCoroutine(Create());
    }
}
