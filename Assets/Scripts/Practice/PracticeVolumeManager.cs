using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeVolumeManager : MonoBehaviour
{
    //public static DataManager instance = null;
    private float timer;//Ascencent timer
    private float countDown;//Countdown to start
    public Text countDownText;//Countdown to start Text
    private int points;
    public static string speech = "";
    //public TextMeshPro speechText;
    public Text speechText;
    public TextMeshPro correctionsText;
    public TextMeshPro timerText;//Ascendent timer Text
    //public Text resultsText;//Results Text
    //public Button again;//Restart the game
    //public Button returnButton;

    private PracticeRecognizer recognizer;

    public GameObject panel;
    public GameObject RecognizerGO;

    //private bool started;

    //public static int neededSilences;//Seconds of silences the next need to be correct
    
    public GameObject SoundLoudnessGO;
    public GameObject resultsGO;


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
        //resultsText.gameObject.SetActive(false);
        //Results.gameObject.SetActive(false);
        SoundLoudnessGO.gameObject.SetActive(false);
        //again.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        recognizer = RecognizerGO.GetComponent<PracticeRecognizer>();

        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        speechText.text = speech;
        Debug.Log("Speech manager: " + speechText.text);
        countDown = 4;
        countDownText.text = "" + (int)countDown;
        correctionsText.text = "";
        timer = 0.0f;
        timerText.text = "" + (int)timer;
        points = 0;

        countDownText.gameObject.SetActive(true);
        speechText.gameObject.SetActive(true);
        correctionsText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
    }

    /*public void SetStart()
    {
        //started = true;
        timerText.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);
    }*/

    public void SetPoints(int pt)
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
            SoundLoudnessGO.gameObject.SetActive(true);
            recognizer.EnableRecognizer();
        }
        else if (OVRManager.isHmdPresent)// headset connected
        {
            if (OVRInput.GetDown(OVRInput.Button.One)) //When game is finished
            {
                SoundLoudnessGO.gameObject.SetActive(false);
                resultsGO.gameObject.SetActive(true);
                timerText.gameObject.SetActive(false);
                speechText.gameObject.SetActive(false);
                //resultsText.gameObject.SetActive(true);
                //again.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(true);
                correctionsText.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                recognizer.DisableRecognizer();


                this.gameObject.SetActive(false);
            }
            else
            {
                timer += Time.deltaTime;
                timerText.text = "" + (int)timer;
                //   Debug.Log(timer);
            }
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)) //When game is finished
            {
                SoundLoudnessGO.gameObject.SetActive(false);
                resultsGO.gameObject.SetActive(true);
                timerText.gameObject.SetActive(false);
                speechText.gameObject.SetActive(false);
                //resultsText.gameObject.SetActive(true);
                //again.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(true);
                correctionsText.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                recognizer.DisableRecognizer();


                this.gameObject.SetActive(false);
            }
            else
            {
                timer += Time.deltaTime;
                timerText.text = "" + (int)timer;
                //   Debug.Log(timer);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }
}
