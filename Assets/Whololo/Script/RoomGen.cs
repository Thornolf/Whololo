using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour {

    public GameObject[] availableRooms;
    public GameObject current;

    // Use this for initialization
    void Start ()
    {
        int id = Random.Range(0, availableRooms.Length);
        GameObject room = (GameObject)Instantiate(availableRooms[id]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
