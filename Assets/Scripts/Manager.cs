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

    //private bool started;

    //public GameObject Results;
    //public GameObject Preparation;
    public GameObject SoundLoudness;


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
        //timerText.gameObject.SetActive(false);
        SoundLoudness.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        timerText.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);
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
        else if(countDown < 1 && countDown > 0)//SetSctive the texts only ones
        {
            countDown = 0;
            countDownText.gameObject.SetActive(false);
            SoundLoudness.gameObject.SetActive(true);
        }
        else
        {
            

            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //started = false;
                timerText.gameObject.SetActive(false);
                //Activas resultados resultados.setActive(true);
                //Results.SetActive(true);
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
