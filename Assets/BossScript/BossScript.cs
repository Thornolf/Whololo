using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

	public GameObject projectile;
	public GameObject otherProjectile;
	private CharacterStats stats;
	private double nextAttackAllowed = 1.0f;
	private int timeAttacked = 0;
	private int timeAttackedOther = 0;

	// Use this for initialization
	void Start () {
		stats = GetComponent<CharacterStats> ();
	}

	// Update is called once per frame
	void Update () {
		if (timeAttacked <= 2) {
			if (Time.time > nextAttackAllowed) {
				nextAttackAllowed = Time.time + stats.attackSpeed;
				CreateProjectile ();
			}
		} else if (timeAttackedOther <= 30) {
			CreateProjectileOther ();
		} else if (Time.time > nextAttackAllowed + 1) {
			nextAttackAllowed = Time.time + stats.attackSpeed;
			timeAttacked = 0;
			timeAttackedOther = 0;
		}
	}
		

	void CreateProjectile()
	{
		Debug.Log (timeAttacked);
		timeAttacked++;
		GameObject obj = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj.GetComponent<BossProjectile>().wayPointPos = new Vector2(40, 0);
		GameObject obj2 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj2.GetComponent<BossProjectile>().wayPointPos = new Vector2(-40, 0);
		GameObject obj3 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj3.GetComponent<BossProjectile>().wayPointPos = new Vector2(0, 40);
		GameObject obj4 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj4.GetComponent<BossProjectile>().wayPointPos = new Vector2(0, -40);

		GameObject obj5 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj5.GetComponent<BossProjectile>().wayPointPos = new Vector2(40, -40);
		GameObject obj6 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj6.GetComponent<BossProjectile>().wayPointPos = new Vector2(-40, -40);
		GameObject obj7 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj7.GetComponent<BossProjectile>().wayPointPos = new Vector2(-40, 40);
		GameObject obj8 = Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		obj8.GetComponent<BossProjectile>().wayPointPos = new Vector2(40, 40);

	}

	void CreateProjectileOther()
	{
		timeAttackedOther++;
		Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
	}
}
