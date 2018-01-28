using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFollow : MonoBehaviour {

	private GameObject wayPoint;
	private Vector2 wayPointPos;
	private CharacterStats stats;
	private double nextAttackAllowed = 0.0f;


	void Start () {
		wayPoint = GameObject.FindGameObjectWithTag("Player");
		stats = GetComponent<CharacterStats> ();
		stats.hitpoint = 10;
	}

	void Update () {
		float dist = Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position);

		if (dist < 1.5f) {
			if (Time.time > nextAttackAllowed) {
				nextAttackAllowed = Time.time + stats.attackSpeed;
				Attack ();
			}
		}
		else if (dist < 10.0f)
			FollowToDeath ();
	}

	void FollowToDeath() {
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, stats.speed * Time.deltaTime);
	}

	void Attack()
	{
		CharacterStats playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();
		playerStats.hitpoint -= 5;
	}

	void OnDrawGizmos()
	{
		/*Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.transform.position, 2);*/
	}
}
