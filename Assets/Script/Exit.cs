using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public float RestartDelay = 1.0f;
	private int nbEnemy;

	void Start ()
	{
		nbEnemy = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		gameObject.SetActive (false);
		if (nbEnemy <= 0)
			gameObject.SetActive (true);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            Invoke("Restart", RestartDelay);
    }

    void Update () {
		nbEnemy = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		Debug.Log ("NB : " + nbEnemy);
		if (nbEnemy <= 0)
			gameObject.SetActive(true);
	}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
