using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilenceCS : MonoBehaviour
{ 
    public void ChangeScene()
    {
        SceneManager.LoadScene("Silences");
    }
}
