using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //public static DataManager instance = null;

    private float timer;//Ascencent timer
    public TextMeshPro timerText;//Ascendent timer Text
    private float countDown;//Countdown to start
    public Text countDownText;//Countdown to start Text
    public static string speech = "";
    public TextMeshPro speechText;//Speech Text

    //private bool started;

    public GameObject Results;
    //public GameObject Preparation;
    public GameObject SoundLoudnessGO;


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

        timer = 0.0f;
        timerText.text = "" + (int)timer;
        countDown = 4;
        countDownText.text = "" + (int)countDown;

        countDownText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
        //Results.gameObject.SetActive(false);
        //SoundLoudnessGO.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        speechText.text = speech;

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
        }
        else
        {


            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //started = false;
                timerText.gameObject.SetActive(false);
                speechText.gameObject.SetActive(false);
                Results.gameObject.SetActive(true);
                //SoundLoudness.gameObject.SetActive(false);
                SoundLoudness.collect = false;
            }
            else
            {
                timerText.text = "" + (int)timer;
            }
            //   Debug.Log(timer);
        }
        //}
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
