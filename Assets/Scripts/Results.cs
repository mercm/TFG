using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{

    public TextMeshPro resultsText;

    // Start is called before the first frame update
    void Start()
    {
        resultsText.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        resultsText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
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

        resultsText.text += "Press space to finish the game.";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Cambiar al inicio para poder cambiar de juego
        }
    }
}
