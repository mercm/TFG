﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeResults : MonoBehaviour
{

    public Text resultsText;
    //public Button returnButton;
    private int correctSecs;//Correct seconds the user has done in the game
    private int upIncorrectSecs;//Incorrect upper volume seconds the user has done in the game
    private int lowIncorrectSecs;//Incorrect lower volume seconds the user has done in the game
    private float percentage;//Percentage of correct seconds in the game
    public GameObject preparationGO;
    public GameObject panel;
    private bool resultsReady;
    //public Button again;//Restart the game
    private PracticeVolumeManager manager;
    public GameObject ManagerGO;
    public GameObject PreparationGO;

    // Start is called before the first frame update
    void Start()
    {
        resultsReady = false;
        manager = ManagerGO.GetComponent<PracticeVolumeManager>();
        resultsText.gameObject.SetActive(false);
        //again.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    /*public void setReady(bool ready)
    {
        resultsReady = ready;
    }*/
    void OnEnable()
    {
        resultsText.gameObject.SetActive(true);
        //returnButton.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        resultsReady = true;
    }
    void OnDisable()
    {
        resultsReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!resultsReady)
        {
            resultsText.text = "Calculating the results. Please, wait...";
        }
        else
        {
            //again.gameObject.SetActive(true);

            if (PracticeVolumePreparation.silencesNeeded == PracticeSoundLoudness.silenceCounter)
            {
                resultsText.text = "Great job! You did the exact number of silences for this speech! \n\n";
            }
            else
            {
                resultsText.text = "You need a little more practice. You did " + PracticeSoundLoudness.silenceCounter +
                    " silences and the speech needed " + PracticeVolumePreparation.silencesNeeded + ". \n\n";
            }

            if (PracticeVolumePreparation.longSilencesNeeded == PracticeSoundLoudness.longSilenceCounter)
            {
                resultsText.text += "Excellent! You did the necessary long silences! \n\n\n";
            }
            else
            {
                resultsText.text += "You need to get more confident. You did " + PracticeSoundLoudness.longSilenceCounter +
                    " and this speech needed " + PracticeVolumePreparation.longSilencesNeeded + ". \n\n\n";
            }

            resultsText.text += "You have made " + manager.GetPoints() + " silences points!\n\n\n";
            //resultsText.text += "Press space to practice again.";//Cambiar por botón PlayAgain

            //Give the volume results
            correctSecs = PracticeVolumeSoundLoudness.correctSecCounter;
            upIncorrectSecs = PracticeVolumeSoundLoudness.upIncorrectSecCounter;
            lowIncorrectSecs = PracticeVolumeSoundLoudness.lowIncorrectSecCounter;

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
                total = (correctSecs / total);
                percentage = total * 100;
                percentage = Mathf.Round(percentage * 100f) / 100f;
            }
            else
            {
                percentage = 0;
            }
            resultsText.text += "You have used the correct volume the " + percentage + "% of the time!";
        }
        if (OVRManager.isHmdPresent)// headset connected
        {
            if (OVRInput.GetDown(OVRInput.Button.One)) //Restart the game
            {
                PreparationGO.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))//Restart the game
            {
                PreparationGO.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }
}