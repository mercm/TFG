using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{

    public Text resultsText;
    public GameObject preparation;
    public GameObject panel;
    private bool resultsReady;
    private Manager manager;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        resultsReady = false;
        manager = ManagerGO.GetComponent<Manager>();
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
                resultsText.text = "Necesitas un poco más práctica. Has hecho " + SoundLoudness.silenceCounter + " silencios y el texto necesitaba " + Preparation.silencesNeeded + ". \n\n";
                //"You need a little more practice. You did " + SoundLoudness.silenceCounter +
                //" silences and the speech needed " + Preparation.silencesNeeded + ". \n\n";
            }

            if (Preparation.longSilencesNeeded == SoundLoudness.longSilenceCounter)
            {
                resultsText.text += "¡Excelente! Has hecho la cantidad de silencios largos necesarios\n\n";//"Excellent! You did the necessary long silences! \n\n\n";
            }
            else
            {
                resultsText.text += "Necesitas un poco más de confianza. Has hecho " + SoundLoudness.longSilenceCounter + " silencios largos y el texto necesitaba "
                    + Preparation.longSilencesNeeded + ". \n\n";
                //"You need to get more confident. You did " + SoundLoudness.longSilenceCounter +
                //" and this speech needed " + Preparation.longSilencesNeeded + ". \n\n\n";
            }

            int points = manager.GetPoints() < 0 ? 0 : manager.GetPoints();
            string auxResult = "";
            if (PlayerPrefs.GetInt("Level") == 1)
            {
                if (points <= 5)
                {
                    auxResult = "Aún tienes mucho que mejorar.";
                }
                else if (points > 5 && points <= 15)
                {
                    auxResult = "Vas por buen camino.";
                }
                else if (points > 15 && points <= 30)
                {
                    auxResult = "¡Excelente! No se te da nada mal.";
                }
                else if (points > 30 && points <= 40)
                {
                    auxResult = "¡Perfecto! Has dado en el clavo.";
                }
            }
            else if (PlayerPrefs.GetInt("Level") == 2)
            {
                if (points <= 5)
                {
                    auxResult = "Aún tienes mucho que mejorar.";
                }
                else if (points > 5 && points <= 18)
                {
                    auxResult = "Vas por buen camino.";
                }
                else if (points > 18 && points <= 27)
                {
                    auxResult = "¡Excelente! No se te da nada mal.";
                }
                else if (points > 27 && points <= 35)
                {
                    auxResult = "¡Perfecto! Has dado en el clavo.";
                }
            }
            else if (PlayerPrefs.GetInt("Level") == 3)
            {
                if (points <= 5)
                {
                    auxResult = "Aún tienes mucho que mejorar.";
                }
                else if (points > 5 && points <= 13)
                {
                    auxResult = "Vas por buen camino.";
                }
                else if (points > 13 && points <= 22)
                {
                    auxResult = "¡Excelente! No se te da nada mal.";
                }
                else if (points > 22 && points <= 30)
                {
                    auxResult = "¡Perfecto! Has dado en el clavo.";
                }
            }
            else
            {
                Debug.LogError("Problems with level number.");
            }

            resultsText.text += "Has hecho " + points + " puntos. " + auxResult; //"You made " + points + " points. " + auxResult;;
        }
        if (OVRManager.isHmdPresent)// headset connected
        {
            if (OVRInput.GetDown(OVRInput.Button.One)) //Restart the game
            {
                preparation.gameObject.SetActive(true);
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
                preparation.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }
}
