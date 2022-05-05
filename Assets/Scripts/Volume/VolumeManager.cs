using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    //public static DataManager instance = null;
    private float countDown;//Countdown to start
    public Text countDownText;//Countdown to start Text
    public static string speech = "";
    public TextMeshPro speechText;
    public TextMeshPro correctionsText;
    public Text resultsText;//Results Text
    private bool spacePressed;
    //public Button again;//Restart the game
    //public Button returnButton;
    public GameObject panel;

    //private bool started;

    //public static int neededSilences;//Seconds of silences the next need to be correct
    private int correctSecs;//Correct seconds the user has done in the game
    private int upIncorrectSecs;//Incorrect upper volume seconds the user has done in the game
    private int lowIncorrectSecs;//Incorrect lower volume seconds the user has done in the game
    private float percentage;//Percentage of correct seconds in the game

    public GameObject VolumeSoundLoudnessGO;
    public GameObject VolumePreparationGO;


    //Sound
    //List<float> Sound;

    /*void Awake()
    {
        if (instance == null)
            instance = this;
        Sound = new List<float>();
    }*/

    // Start is called before the first frame update
    private void Start()
    {
        //started = false;

        countDownText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
        resultsText.gameObject.SetActive(false);
        //Results.gameObject.SetActive(false);
        VolumeSoundLoudnessGO.gameObject.SetActive(false);
        //again.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        speechText.text = speech;
        countDown = 4;
        countDownText.text = "" + (int)countDown;
        correctionsText.text = "";
        spacePressed = false;

        countDownText.gameObject.SetActive(true);
        speechText.gameObject.SetActive(true);
        correctionsText.gameObject.SetActive(true);
    }
    /*public void SetStart()
    {
        //started = true;
        timerText.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);
    }*/

    // Update is called once per frame
    private void Update()
    {
        // if (started)
        // {
        if (countDown > 1 && countDown <= 4)
        {
            countDown -= Time.deltaTime;
            countDownText.text = "" + (int)countDown;
        }
        else if (countDown < 1 && countDown > 0)//SetActive the texts only once
        {
            countDown = 0;
            countDownText.gameObject.SetActive(false);
            VolumeSoundLoudnessGO.gameObject.SetActive(true);
        }
        else if (OVRManager.isHmdPresent)// headset connected
        {
            if (!spacePressed && OVRInput.GetDown(OVRInput.Button.One))
            {
                //started = false;
                spacePressed = true;

                VolumeSoundLoudnessGO.gameObject.SetActive(false);
                //SoundLoudness.collect = false;

                //Give the result
                correctSecs = VolumeSoundLoudness.correctSecCounter;
                upIncorrectSecs = VolumeSoundLoudness.upIncorrectSecCounter;
                lowIncorrectSecs = VolumeSoundLoudness.lowIncorrectSecCounter;

                /*if (lowIncorrectSecs <= neededSilences)
                {
                    lowIncorrectSecs = 0;
                }
                else
                {
                    lowIncorrectSecs = lowIncorrectSecs - neededSilences;

                }*/
                if (correctSecs + upIncorrectSecs + lowIncorrectSecs != 0)
                {
                    float total = correctSecs + upIncorrectSecs + lowIncorrectSecs;
                    float points = (correctSecs / total);
                    percentage = points * 100;
                    percentage = Mathf.Round(percentage * 100f) / 100f;
                }
                else
                {
                    percentage = 0;
                }
                speechText.gameObject.SetActive(false);
                correctionsText.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                resultsText.text = "Has utilizado el volumen correcto el " + percentage + "% del tiempo!";//"You have used the correct volume the " + percentage + "% of the time!";
                resultsText.gameObject.SetActive(true);
                //again.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(true);
                //this.gameObject.SetActive(false);
            }
            else if (OVRInput.GetDown(OVRInput.Button.One)) //Restart the game
            {
                VolumePreparationGO.gameObject.SetActive(true);
                resultsText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                //playAgainButton.gameObject.SetActive(false);
                spacePressed = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
        else
        {
            if (!spacePressed && Input.GetKeyDown(KeyCode.Space))
            {
                //started = false;
                spacePressed = true;

                VolumeSoundLoudnessGO.gameObject.SetActive(false);
                //SoundLoudness.collect = false;

                //Give the result
                correctSecs = VolumeSoundLoudness.correctSecCounter;
                upIncorrectSecs = VolumeSoundLoudness.upIncorrectSecCounter;
                lowIncorrectSecs = VolumeSoundLoudness.lowIncorrectSecCounter;

                /*if (lowIncorrectSecs <= neededSilences)
                {
                    lowIncorrectSecs = 0;
                }
                else
                {
                    lowIncorrectSecs = lowIncorrectSecs - neededSilences;

                }*/
                if (correctSecs + upIncorrectSecs + lowIncorrectSecs != 0)
                {
                    float total = correctSecs + upIncorrectSecs + lowIncorrectSecs;
                    float points = (correctSecs / total);
                    percentage = points * 100;
                    percentage = Mathf.Round(percentage * 100f) / 100f;
                }
                else
                {
                    percentage = 0;
                }
                speechText.gameObject.SetActive(false);
                correctionsText.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                resultsText.text = "Has utilizado el volumen correcto el " + percentage + "% del tiempo!";//"You have used the correct volume the " + percentage + "% of the time!";
                resultsText.gameObject.SetActive(true);
                //again.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(true);
                //this.gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Space))//Restart the game
            {
                VolumePreparationGO.gameObject.SetActive(true);
                resultsText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                //playAgainButton.gameObject.SetActive(false);
                spacePressed = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }

    //Sound
    /* public void AddSound(float x)
     {
         if (!finished && started)
         {
             Sound.Add(x);
             Debug.Log("added!");
         }
     }*/
}
