using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeResults : MonoBehaviour
{

    public Text resultsText;
    private int correctSecs;//Correct seconds the user has done in the game
    private int upIncorrectSecs;//Incorrect upper volume seconds the user has done in the game
    private int lowIncorrectSecs;//Incorrect lower volume seconds the user has done in the game
    private float percentage;//Percentage of correct seconds in the game
    public GameObject preparationGO;
    public GameObject panel;
    private bool resultsReady;
    private PracticeVolumeManager manager;
    public GameObject ManagerGO;
    public GameObject PreparationGO;

    // Start is called before the first frame update
    void Start()
    {
        resultsReady = false;
        manager = ManagerGO.GetComponent<PracticeVolumeManager>();
        resultsText.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        resultsText.gameObject.SetActive(true);
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
            resultsText.text = "Calculando los resultados. Espera, por favor...";//"Calculating the results. Please, wait...";
        }
        else
        {

            if (Preparation.silencesNeeded == SoundLoudness.silenceCounter)
            {
                resultsText.text = "¡Buen trabajo! Has hecho el número correcto de silencios para este texto\n\n";
                //"Great job! You did the exact number of silences for this speech! \n\n";
            }
            else
            {
                resultsText.text = "Necesitas un poco más práctica. Has hecho " + PracticeSoundLoudness.silenceCounter + " silencios y el texto necesitaba " + Preparation.silencesNeeded + ". \n\n";
                //"You need a little more practice. You did " + SoundLoudness.silenceCounter +
                //" silences and the speech needed " + Preparation.silencesNeeded + ". \n\n";
            }

            if (Preparation.longSilencesNeeded == SoundLoudness.longSilenceCounter)
            {
                resultsText.text += "¡Excelente! Has hecho la cantidad de silencios largos necesarios\n\n";//"Excellent! You did the necessary long silences! \n\n\n";
            }
            else
            {
                resultsText.text += "Necesitas un poco más de confianza. Has hecho " + PracticeSoundLoudness.longSilenceCounter + " silencios largos y el texto necesitaba "
                    + Preparation.longSilencesNeeded + ". \n\n";
                //"You need to get more confident. You did " + SoundLoudness.longSilenceCounter +
                //" and this speech needed " + Preparation.longSilencesNeeded + ". \n\n\n";
            }

            int points = manager.GetPoints() < 0 ? 0 : manager.GetPoints();
            string auxResult = "";
            if (points <= 5)
            {
                auxResult = "Aún tienes mucho que mejorar.";
            }
            else if (points > 5 && points <= 10)
            {
                auxResult = "Vas por buen camino.";
            }
            else if (points > 10 && points <= 17)
            {
                auxResult = "¡Excelente! No se te da nada mal.";
            }
            else if (points > 17 && points <= 25)
            {
                auxResult = "¡Perfecto! Has dado en el clavo.";
            }

            resultsText.text += "Has hecho " + points + " puntos. " + auxResult + "\n\n";

            //Give the volume results
            correctSecs = PracticeVolumeSoundLoudness.correctSecCounter;
            upIncorrectSecs = PracticeVolumeSoundLoudness.upIncorrectSecCounter;
            lowIncorrectSecs = PracticeVolumeSoundLoudness.lowIncorrectSecCounter;

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
            resultsText.text += "Has utilizado el volumen correcto el " + percentage + "% del tiempo!";//"You have used the correct volume the " + percentage + "% of the time!";
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
