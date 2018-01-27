using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFollow : MonoBehaviour {

	private GameObject wayPoint;
	private Vector2 wayPointPos;

	void Start () {
		wayPoint = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		FollowToDeath ();
	}

	void FollowToDeath() {
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, 10.0f * Time.deltaTime);
	}
}
