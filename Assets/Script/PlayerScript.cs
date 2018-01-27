using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {
	
	private Boolean Spotted;
	private CharacterStats stats; 
	private double nextAttackAllowed = 0.0f;

	public Transform sightStart;
	public Transform sightEnd;

	// Use this for initialization
	void Start () {
		stats = GetComponent<CharacterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

		if (Input.GetKeyDown ("space") && Time.time > nextAttackAllowed)
		{
			nextAttackAllowed = Time.time + stats.attackSpeed;
			Strike ();
		}
	}

	void Strike() {
		RaycastHit2D hit = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {
			CharacterStats enemyStat = hit.collider.GetComponent<CharacterStats>();
			enemyStat.hitpoint -= 2;
			Debug.Log (enemyStat.hitpoint);
		}
	}
}
