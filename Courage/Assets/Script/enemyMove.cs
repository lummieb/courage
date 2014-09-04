using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {

	private Vector3 pos1;
	private Vector3 pos2;

	public float moveSpeed;
	public int length;

	private Vector3 smallScale;
	private Vector3 largeScale;
	
	// Use this for initialization
	void Start () {
		moveSpeed = 5f;
		length = 4;

		pos1 = new Vector3(transform.position.x-length, transform.position.y, transform.position.z);
		pos2 = new Vector3(transform.position.x+length, transform.position.y, transform.position.z);

		smallScale = new Vector3(4.0F, 1.0F, 4.0F);
		largeScale = new Vector3(6.0F, 1.0F, 6.0F);

		gameObject.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("Rhythmbot").GetComponent<Rhythm>().rhythmIsOn)
		{
			moveSpeed = 2f;
			gameObject.renderer.material.color = Color.cyan;

			transform.localScale = smallScale;
		}
		else
		{
			moveSpeed = 5f;
			gameObject.renderer.material.color = Color.red;

			transform.localScale = largeScale;
		}

		if (GameObject.Find("Player").GetComponent<toMove>().hasWon)
		{
			Destroy(gameObject);
		}

	
	}

	void FixedUpdate () {

		transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(moveSpeed * Time.time) + 1.0f) / 2.0f);
	}
}
