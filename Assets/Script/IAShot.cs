using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAShot : MonoBehaviour {

	public GameObject projectile;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("e"))
			CreateProjectile ();

	}

	void CreateProjectile()
	{
		Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
	}
}
