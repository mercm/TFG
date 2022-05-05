using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static OVRInput;

public class Manager : MonoBehaviour
{
    //public static DataManager instance = null;

    private float timer;//Ascencent timer
    public TextMeshPro timerText;//Ascendent timer Text
    private float countDown;//Countdown to start
    public Text countDownText;//Countdown to start Text
    public static string speech = "";
    //public TextMeshPro speechText;//Speech Text
    public Text speechText;//Speech Text
    private Dictation dictation;
    private Recognizer recognizer;

    private bool stop;

    public GameObject resultsGO;
    //public GameObject Preparation;
    public GameObject SoundLoudnessGO;
    public GameObject DictationGO;
    public GameObject RecognizerGO;

    private int points;
    //enum CategoryPts {Perfect = 5, Good = 1, Bad = -2};


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
        timerText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
        dictation = DictationGO.GetComponent<Dictation>();
        recognizer = RecognizerGO.GetComponent<Recognizer>();
        //Results.gameObject.SetActive(false);
        //SoundLoudnessGO.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        speechText.text = speech;
        timer = 0.0f;
        timerText.text = "" + (int)timer;
        countDown = 4;
        countDownText.text = "" + (int)countDown;
        stop = false;
        points = 0;

        timerText.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);
        speechText.gameObject.SetActive(true);
    }
    /*public void SetStart()
    {
        //started = true;
        timerText.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);
    }*/

    public void setStop(bool set)
    {
        stop = set;
    }

    public void setPoints(int pt)
    {
        points += pt;
    }

    public int GetPoints()
    {
        return points;
    }

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
            //speechText.gameObject.SetActive(true);
            SoundLoudnessGO.gameObject.SetActive(true);
            //dictation.enableDictation();
            recognizer.enableRecognizer();
        }
        else
        {
            timer += Time.deltaTime;

            if (OVRManager.isHmdPresent)// headset connected
            {
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    timerText.gameObject.SetActive(false);
                    speechText.gameObject.SetActive(false);
                    SoundLoudnessGO.gameObject.SetActive(false);
                    resultsGO.gameObject.SetActive(true);
                    recognizer.disableRecognizer();
                    //SoundLoudness.collect = false;
                    this.gameObject.SetActive(false);
                }
                else
                {
                    timerText.text = "" + (int)timer;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    timerText.gameObject.SetActive(false);
                    speechText.gameObject.SetActive(false);
                    SoundLoudnessGO.gameObject.SetActive(false);
                    resultsGO.gameObject.SetActive(true);
                    recognizer.disableRecognizer();
                    //SoundLoudness.collect = false;
                    this.gameObject.SetActive(false);
                }
                else
                {
                    timerText.text = "" + (int)timer;
                }
            }
                
            //   Debug.Log(timer);
        }
        //}
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        //if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("CinemaStart");
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
