using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour {

	// Use this for initialization
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
