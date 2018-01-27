using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {
	
	private Boolean Spotted;
	public Transform sightStart;
	public Transform sightEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

		if (Input.GetKeyDown ("space"))
			Strike ();
	}

	void Strike() {
		RaycastHit2D hit = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
		if (hit.collider != null) {
			Debug.Log ("COLLIDING");
		}
	}
}
