using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilenceCS : MonoBehaviour
{ 
    public void ChangeSceneSLv1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("CinemaSilence");
    }
    public void ChangeSceneSLv2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("CinemaSilence");
    }
    public void ChangeSceneSLv3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("CinemaSilence");
    }
    public void ChangeSceneVLv1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("CinemaVolume");
    }
    public void ChangeSceneVLv2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("CinemaVolume");
    }
    public void ChangeSceneVLv3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("CinemaVolume");
    }
    public void ChangeSceneP()
    {
        SceneManager.LoadScene("CinemaPractice");
    }
}
