using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFollow : MonoBehaviour {

	private GameObject wayPoint;
	private Vector2 wayPointPos;
	private CharacterStats stats;
	private double nextAttackAllowed = 0.0f;
	public ParticleSystem	deadParticle;
	public ParticleSystem	convParticle;
	private bool okPart = false;

	void Start () {
		wayPoint = GameObject.FindGameObjectWithTag("Player");
		stats = GetComponent<CharacterStats> ();
		stats.hitpoint = 10;
	}

	void Update () {
		float dist = Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position);

		if (stats.isAlive) {
			if (dist < 1.5f) {
				if (Time.time > nextAttackAllowed) {
					nextAttackAllowed = Time.time + stats.attackSpeed;
					Attack ();
				}
			}
			else if (dist < 10.0f)
				FollowToDeath ();
		} else {
			gameObject.tag = "Untagged";
			if (!okPart) {
				ParticleSystem part = (ParticleSystem)Instantiate (convParticle);
				part.transform.position = transform.position;
				ParticleSystem partConv = (ParticleSystem)Instantiate (deadParticle);
				partConv.transform.position = transform.position;
				okPart = true;
			}
		}
	}

	void FollowToDeath() {
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, stats.speed * Time.deltaTime);
	}

	void Attack()
	{
		CharacterStats playerStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterStats> ();
		playerStats.hitpoint -= 5;
		SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer> ();
		spriteR.color = Color.red;
		spriteR.color = Color.white;
	}

	void OnDrawGizmos()
	{
		/*Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.transform.position, 2);*/
	}
}
