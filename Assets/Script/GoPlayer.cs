using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPlayer : MonoBehaviour
{

    public void LoadbyIndex(int index)
    {
        SceneManager.LoadScene(index);

    }
}