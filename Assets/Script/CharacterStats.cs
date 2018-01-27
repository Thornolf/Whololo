using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	// Use this for initialization
	public bool isAlive = true;
	public int hitpoint = 100;
	public float speed = 2.0f;
	public float attackSpeed = 1.3f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive == false) {
			Destroy (gameObject);
		}
		if (hitpoint <= 0)
			isAlive = false;
	}
}
