using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private float countDown;//Countdown to start
    public Text countDownText;//Countdown to start Text
    public static string speech = "";
    public Text speechText;
    public TextMeshPro correctionsText;
    public Text resultsText;//Results Text
    private bool spacePressed;
    public GameObject panel;
    
    private int correctSecs;//Correct seconds the user has done in the game
    private int upIncorrectSecs;//Incorrect upper volume seconds the user has done in the game
    private int lowIncorrectSecs;//Incorrect lower volume seconds the user has done in the game
    private float percentage;//Percentage of correct seconds in the game

    public GameObject VolumeSoundLoudnessGO;
    public GameObject VolumePreparationGO;

    // Start is called before the first frame update
    private void Start()
    {
        countDownText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
        resultsText.gameObject.SetActive(false);
        VolumeSoundLoudnessGO.gameObject.SetActive(false);

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
            VolumeSoundLoudnessGO.gameObject.SetActive(true);
        }
        else if (OVRManager.isHmdPresent)// headset connected
        {
            if (!spacePressed && OVRInput.GetDown(OVRInput.Button.One))
            {
                spacePressed = true;

                VolumeSoundLoudnessGO.gameObject.SetActive(false);

                //Give the result
                correctSecs = VolumeSoundLoudness.correctSecCounter;
                upIncorrectSecs = VolumeSoundLoudness.upIncorrectSecCounter;
                lowIncorrectSecs = VolumeSoundLoudness.lowIncorrectSecCounter;
                
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
            }
            else if (OVRInput.GetDown(OVRInput.Button.One)) //Restart the game
            {
                VolumePreparationGO.gameObject.SetActive(true);
                resultsText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
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
                spacePressed = true;

                VolumeSoundLoudnessGO.gameObject.SetActive(false);

                //Give the result
                correctSecs = VolumeSoundLoudness.correctSecCounter;
                upIncorrectSecs = VolumeSoundLoudness.upIncorrectSecCounter;
                lowIncorrectSecs = VolumeSoundLoudness.lowIncorrectSecCounter;
                
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
            }
            else if (Input.GetKeyDown(KeyCode.Space))//Restart the game
            {
                VolumePreparationGO.gameObject.SetActive(true);
                resultsText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                spacePressed = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }
}
