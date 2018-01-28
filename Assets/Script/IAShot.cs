using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAShot : MonoBehaviour {

	public GameObject projectile;
	private CharacterStats stats;
	private double nextAttackAllowed = 0.0f;

	// Use this for initialization
	void Start () {
		stats = GetComponent<CharacterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextAttackAllowed) {
			nextAttackAllowed = Time.time + stats.attackSpeed;
			CreateProjectile ();
		}

	}

	void CreateProjectile()
	{
		Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
	}
}
