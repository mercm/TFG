using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilenceCS : MonoBehaviour
{ 
    public void ChangeSceneSLv1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("Silences");
    }
    public void ChangeSceneSLv2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("Silences");
    }
    public void ChangeSceneSLv3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("Silences");
    }
    public void ChangeSceneVLv1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("Volume");
    }
    public void ChangeSceneVLv2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("Volume");
    }
    public void ChangeSceneVLv3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("Volume");
    }
}
