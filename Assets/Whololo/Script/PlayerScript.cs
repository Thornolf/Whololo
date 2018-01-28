using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	
	private Boolean Spotted;
	private CharacterStats stats; 
	private double nextAttackAllowed = 0.0f;
	private double nextBlinkAllowed = 0.0f;

	public Transform sightStart;
	public Transform sightEnd;

	public UnityEngine.UI.Slider faithSlider;
	public Text faithText;

	// Use this for initialization
	void Start () {
		stats = GetComponent<CharacterStats> ();
		//faithSlider.value = 100;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

	    if (Input.GetKeyDown("left"))
	    {
	        sightEnd.transform.localPosition = new Vector2(-2, 0);
	    }
        if (Input.GetKeyDown("up"))
	    {
	        sightEnd.transform.localPosition = new Vector2(0, 4);
	    }
	    if (Input.GetKeyDown("down"))
	    {
	        sightEnd.transform.localPosition = new Vector2(0, -4);
	    }
        if (Input.GetKeyDown("right"))
	    {
	        sightEnd.transform.localPosition = new Vector2(2, 0);
	    }

        if (Input.GetKeyDown ("space") && Time.time > nextAttackAllowed)
		{
			nextAttackAllowed = Time.time + stats.attackSpeed;
			Strike ();
		}
		//faithSlider.value = stats.hitpoint;
		faithText.text = stats.hitpoint.ToString ();
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
