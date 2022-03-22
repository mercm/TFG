using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilenceCS : MonoBehaviour
{ 
    public void ChangeSceneLv1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("Silences");
    }
    public void ChangeSceneLv2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("Silences");
    }
    public void ChangeSceneLv3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("Silences");
    }
}
