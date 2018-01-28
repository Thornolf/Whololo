using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour {

    public GameObject[] availableRooms;
    public GameObject exit;
	private int nbEnemy;


    // Use this for initialization
    void Start ()
    {
		nbEnemy = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		exit.SetActive (false);
		if (nbEnemy <= 0)
			exit.SetActive (true);

        int id = Random.Range(0, availableRooms.Length);
        GameObject room = (GameObject)Instantiate(availableRooms[id]);
		room = room;
    }
	
	// Update is called once per frame
	void Update () {
		nbEnemy = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		Debug.Log ("NB : " + nbEnemy);
		if (nbEnemy <= 0)
			exit.SetActive(true);
	}
}
