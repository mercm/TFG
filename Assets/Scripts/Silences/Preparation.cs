﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Preparation : MonoBehaviour
{
    public TextMeshPro preparationText;

    //List<string> speeches = new List<string>(); //contains the speeches the user can select.
    //List<string> instructions = new List<string>(); //contains the specific instructions for starting the game.
    private string[] speeches = new string[3];
    private string[] instructions = new string[3];

    private bool spacePressed;
    private int choosenSpeech;
    public static int silencesNeeded;
    public static int longSilencesNeeded;
    public Button returnButton;

    //public GameObject SoundLoudness;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        //SoundLoudness.gameObject.SetActive(false);
        //Manager.gameObject.SetActive(false);

        instructions[0] = CreateSilencesText(2, 2);
        instructions[1] = CreateSilencesText(3, 1);
        instructions[2] = CreateSilencesText(3, 0);

        speeches[0] =
            @"La vida es lo mas preciado que posee el hombre, a el se le otorga una sola vez y debe saber vivirla de forma tal, 
            que no le cause un dolor torturante por los años pasados en vano; y para que no le remuerda la conciencia, por el ayer 
            vil y mezquino que no lo supo aprovechar, y para que al morir pueda exclamar que toda su vida y todas sus fuerzas, 
            lo ha dedicado a lo mas hermoso que posee el mundo, a la lucha por la justicia, la paz y la liberación de la humanidad.";
        speeches[1] =
            @"El pueblo clama ¡paz!, ¡paz!, pero no hay paz. La guerra ha empezado ya, yo no se que piensan hacer los otros pero
            en lo que a mi respecta,  dadme la libertad o dadme la muerte.";
        speeches[2] =
            @"Sé que a muchos os escandalizará la severidad de mis palabras” ¿pero, acaso no existen motivos para esta severidad?
            Hoy, seré tan crudo como la verdad y tan inflexible como la justicia. Sobre este punto no quiero pensar, ni hablar, ni
            escribir con moderación. ¡No! ¡No! Decid a un hombre que su casa está en llamas para no darle una alarma moderada;
            decidle que rescate a su esposa de manos del raptor; decidle a una madre, que libere poco a poco a su hijo del fuego
            en que ha caído; pero no me animéis a emplear la moderación en la lucha por una causa tan justa como la presente.";

        preparationText.text =
            "Welcome! It is time to practice the silences of your speech. Select an speech from 1 to " +
            speeches.Length + " and practice it. \n\nPress SPACE when you are ready to present. Press the LEFT ARROW to choose another speech.";
    }

    private void OnEnable()
    {
        choosenSpeech = -1;
        spacePressed = false;
        returnButton.gameObject.SetActive(true);

        Manager.speech = "";
        preparationText.text =
            "Welcome! It is time to practice the silences of your speech. Select an speech from 1 to " +
            speeches.Length + " and practice it. \n\nPress SPACE when you are ready to present. Press the LEFT ARROW to choose another speech.";
        preparationText.gameObject.SetActive(true);
        //ManagerGO.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (choosenSpeech == -1)
        {
            switch (Input.inputString)
            {
                case "1":
                    choosenSpeech = 0;
                    preparationText.text = instructions[choosenSpeech];
                    silencesNeeded = 2;
                    longSilencesNeeded = 2;
                    break;
                case "2":
                    choosenSpeech = 1;
                    preparationText.text = instructions[choosenSpeech];
                    silencesNeeded = 3;
                    longSilencesNeeded = 1;
                    break;
                case "3":
                    choosenSpeech = 2;
                    preparationText.text = instructions[choosenSpeech];
                    silencesNeeded = 3;
                    longSilencesNeeded = 0;
                    break;
            }
        }
        else if (!spacePressed && Input.GetKeyDown(KeyCode.Space))
        {
            preparationText.text = speeches[choosenSpeech];
            spacePressed = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Manager.speech = preparationText.text;
            preparationText.gameObject.SetActive(false);
            ManagerGO.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            choosenSpeech = -1;
            spacePressed = false;
            preparationText.text =
                "Select an speech from 1 to " + speeches.Length + " and practice it. \n\nPress SPACE when you are ready to present.";
        }
    }

    string CreateSilencesText(int silences, int longSilences)
    {
        return "For this speech, you will need to do " + silences + " silences (between 1.5 and 2.5 seconds) and " + longSilences +
            " long silences (between 2.5 and 3.5 seconds)." + 
            "\n\nPress space to see the speech. Practice it as many times as you need and press SPACE to start presenting.";
    }
}
