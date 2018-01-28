using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFollow : MonoBehaviour {

	private GameObject wayPoint;
	private Vector2 wayPointPos;
	private CharacterStats stats;

	void Start () {
		wayPoint = GameObject.FindGameObjectWithTag("Player");
		stats = GetComponent<CharacterStats> ();
	}

	void Update () {
		FollowToDeath ();
	}

	void FollowToDeath() {
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, stats.speed * Time.deltaTime);
	}

	void OnDrawGizmos()
	{
		/*Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.transform.position, 2);*/
	}
}
