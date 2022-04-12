using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{

    public Text resultsText;
    //public Button returnButton;
    //public Button playAgainButton;
    public GameObject preparation;
    public GameObject panel;
    private bool resultsReady;
    //public Button again;//Restart the game
    private Manager manager;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        resultsReady = false;
        manager = ManagerGO.GetComponent<Manager>();
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
        //playAgainButton.gameObject.SetActive(true);
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

            if (Preparation.silencesNeeded == SoundLoudness.silenceCounter)
            {
                resultsText.text = "Great job! You did the exact number of silences for this speech! \n\n";
            }
            else
            {
                resultsText.text = "You need a little more practice. You did " + SoundLoudness.silenceCounter +
                    " silences and the speech needed " + Preparation.silencesNeeded + ". \n\n";
            }

            if (Preparation.longSilencesNeeded == SoundLoudness.longSilenceCounter)
            {
                resultsText.text += "Excellent! You did the necessary long silences! \n\n\n";
            }
            else
            {
                resultsText.text += "You need to get more confident. You did " + SoundLoudness.longSilenceCounter +
                    " and this speech needed " + Preparation.longSilencesNeeded + ". \n\n\n";
            }

            resultsText.text += "You have made " + manager.getPoints() + " points!";
            //resultsText.text += "Press space to practice again.";//Cambiar por botón PlayAgain
        }
        if (Input.GetKeyDown(KeyCode.Space))//Restart the game
        //if (OVRInput.GetDown(OVRInput.Button.One))
        {
            preparation.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            //playAgainButton.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        //if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("CinemaStart");
        }
    }
}
