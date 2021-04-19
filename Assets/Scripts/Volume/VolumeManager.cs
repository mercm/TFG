using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public Button again;//Restart the game
    public Button returnButton;
    public GameObject panel;

    //private bool started;

    public static int neededSilences;//Seconds of silences the next need to be correct
    private int correctSecs;//Correct seconds the user has done in the game
    private int upIncorrectSecs;//Incorrect upper volume seconds the user has done in the game
    private int lowIncorrectSecs;//Incorrect lower volume seconds the user has done in the game
    private float percentage;//Percentage of correct seconds in the game

    public GameObject VolumeSoundLoudnessGO;


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
        again.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        speechText.text = speech;
        countDown = 4;
        countDownText.text = "" + (int)countDown;
        correctionsText.text = "";

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
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //started = false;

            VolumeSoundLoudnessGO.gameObject.SetActive(false);
            //SoundLoudness.collect = false;

            //Give the result
            correctSecs = VolumeSoundLoudness.correctSecCounter;
            upIncorrectSecs = VolumeSoundLoudness.upIncorrectSecCounter;

            if (lowIncorrectSecs < neededSilences)
            {
                lowIncorrectSecs = 0;
            }
            else
            {
                lowIncorrectSecs = VolumeSoundLoudness.lowIncorrectSecCounter - neededSilences;

            }
            if (correctSecs + upIncorrectSecs + lowIncorrectSecs != 0)
            {
                percentage = (correctSecs / (correctSecs + upIncorrectSecs + lowIncorrectSecs)) * 100;
            }
            else
            {
                percentage = 0;
            }
            speechText.gameObject.SetActive(false);
            correctionsText.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            resultsText.text = "You have done " + percentage + "% correct!";
            resultsText.gameObject.SetActive(true);
            again.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
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
