using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private GameObject wayPoint;
	private Vector2 wayPointPos;
	public float speed = 20.0f;

	// Use this for initialization
	void Start () {
		wayPoint = GameObject.Find("Cube");
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 precPos = transform.position;
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
		if (precPos == transform.position)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print (other.name);
		if (other.tag == "Food") {
			other.GetComponent<CharacterStats> ().hitpoint -= 4;
			Destroy (gameObject);
		}
	}
}
