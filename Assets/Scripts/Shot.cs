using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour  {

    public float speed = 10;
    public float rate = 0.5f;
    int hit = 1;
    
    void Start() {
        Destroy(gameObject, 1);
    }

    void Update() {
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime * speed;
        transform.position = pos;
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Meteor") Destroy (gameObject);
	}
}
