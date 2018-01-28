using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getInfoPlayerSet : MonoBehaviour {

    public Text faith;
    public GameObject btn;
    private bool okFaith = false;

    // Use this for initialization
    void Start ()
    {
        btn.SetActive(false);
    }

    public void GetFaith()
    {
        string Faith = faith.text.ToString();
        PlayerPrefs.SetString("Faith", Faith);
        okFaith = true;
    }

	// Update is called once per frame
	void Update ()
	{
	    if (okFaith)
	        btn.SetActive(true);
	}
}
