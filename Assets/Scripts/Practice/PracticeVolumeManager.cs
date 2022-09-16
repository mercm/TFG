using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeVolumeManager : MonoBehaviour
{
    private float timer;//Ascencent timer
    private float countDown;//Countdown to start
    public Text countDownText;//Countdown to start Text
    private int points;
    public static string speech = "";
    public Text speechText;
    public TextMeshPro correctionsText;
    public TextMeshPro timerText;//Ascendent timer Text

    private PracticeRecognizer recognizer;

    public GameObject panel;
    public GameObject RecognizerGO;
    
    public GameObject SoundLoudnessGO;
    public GameObject resultsGO;

    // Start is called before the first frame update
    private void Start()
    {
        countDownText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
        SoundLoudnessGO.gameObject.SetActive(false);
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
                correctionsText.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                recognizer.DisableRecognizer();


                this.gameObject.SetActive(false);
            }
            else
            {
                timer += Time.deltaTime;
                timerText.text = "" + (int)timer;
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
                correctionsText.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                recognizer.DisableRecognizer();


                this.gameObject.SetActive(false);
            }
            else
            {
                timer += Time.deltaTime;
                timerText.text = "" + (int)timer;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }
}
