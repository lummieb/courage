using UnityEngine;
using System.Collections;

public class trinket : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.renderer.material.color = Color.green;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collide)
	{
		if (collide.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
