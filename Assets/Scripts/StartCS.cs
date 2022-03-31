using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCS : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Start");
    }
}
