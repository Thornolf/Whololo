using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	// Use this for initialization
	public bool isAlive = true;
	public int hitpoint = 100;
	public float speed = 2.0f;
	public float attackSpeed = 1.3f;

	public Sprite deadSprite;
	public SpriteRenderer spriteR;

	void Start () {
		spriteR = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive == false) {
			spriteR.sprite = deadSprite;

		}
		if (hitpoint <= 0)
			isAlive = false;
	}
}
