using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    //public static DataManager instance = null;
    public float timer;
    bool started;
    private Text counter;
    float countDown;
    public Text countDownText;
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
    void Start()
    {
        started = false;
        countDown = 3;
        timer = 0.0f;
        countDownText.text = "";
        countDownText.gameObject.SetActive(false);
        counter.gameObject.SetActive(false);
        SoundLoudness.gameObject.SetActive(false);
    }

    public void SetStart()
    {
        started = true;
        counter.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (countDown != 0)
            {
                countDown -= Time.deltaTime;
                countDownText.text = "" + (int)countDown;
            }
            else
            {
                countDownText.gameObject.SetActive(false);
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    started = false;
                    counter.gameObject.SetActive(false);
                    //Activas resultados resultados.setActive(true);
                    //Results.SetActive(true);
                }
                else
                {
                    counter.text = "" + (int)timer;
                }
                //   Debug.Log(timer);
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
