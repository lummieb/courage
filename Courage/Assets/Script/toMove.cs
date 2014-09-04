using UnityEngine;
using System.Collections;

public class toMove : MonoBehaviour {

	public float movespeed;
	public int life;
	public int trinkets;

	public bool hasWon;

	public Camera camera;

	// Use this for initialization
	void Start () {

		gameObject.renderer.material.color = Color.grey;

		life = 5;
		trinkets = 5;
		movespeed = 5f;

		hasWon = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * movespeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-Vector3.right * movespeed * Time.deltaTime);
		}

		if (GameObject.Find("Rhythmbot").GetComponent<Rhythm>().quickRhythm)
		{
			movespeed = 10f;
			gameObject.renderer.material.color = Color.magenta;
		}
		else 
		{
			movespeed = 5f;
			//gameObject.renderer.material.color = Color.grey;
		}

		if (life <= 0 )
		{
			movespeed = 0;
			gameObject.renderer.material.color = Color.black;
		}

		if (trinkets == 0)
		{
			camera.backgroundColor = Color.cyan;
			hasWon = true;
		}

	}

	void OnTriggerEnter(Collider collide)
	{
		if (collide.gameObject.tag == "enemy")
		{
			gameObject.renderer.material.color = Color.red;
			life --;
			print("your life is");
			print(life);
		}

		if (collide.gameObject.tag == "trinket")
		{
			trinkets --;
			print("trinkets:");
			print(trinkets);
		}
	}

	void OnTriggerExit(Collider collide1)
	{
		{
			gameObject.renderer.material.color = Color.grey;
		}
	}
}
