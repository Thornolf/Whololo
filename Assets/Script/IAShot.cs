using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAShot : MonoBehaviour {

	public GameObject projectile;
	private CharacterStats stats;
	private double nextAttackAllowed = 0.0f;
	public ParticleSystem	deadParticle;
	public ParticleSystem	convParticle;
	private bool okPart = false;

	// Use this for initialization
	void Start () {
		stats = GetComponent<CharacterStats> ();
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position);

		if (stats.isAlive) {
			if (dist < 10.5f) {
				if (Time.time > nextAttackAllowed) {
					nextAttackAllowed = Time.time + stats.attackSpeed;
					CreateProjectile ();
				}
			}
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

	void CreateProjectile()
	{
		Instantiate (projectile, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
	}
}
