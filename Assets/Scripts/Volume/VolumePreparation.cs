using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumePreparation : MonoBehaviour
{
    public Text preparationText;
    private string speech;
    public Button returnButton;

    private bool spacePressed;
    private int neededSilences;
    private int level;
    //private bool next;
    //private float countDown;//Countdown to start
    //public Text countDownText;//Countdown to start Text

    //public GameObject VolumeSoundLoudnessGO;
    public GameObject VolumeManagerGO;
    public GameObject panel;

    // Start is called before the first frame update
    /*void Start()
    {
        panel.gameObject.SetActive(true);
        level = PlayerPrefs.GetInt("Level");
    }*/

    private void OnEnable()
    {
        returnButton.gameObject.SetActive(true);

        Manager.speech = "";
        speech = "La vida es lo mas preciado que posee el hombre, a el se le otorga una sola vez y debe saber vivirla de forma tal, " +
            "que no le cause un dolor torturante por los años pasados en vano; y para que no le remuerda la conciencia, por el ayer " +
            "vil y mezquino que no lo supo aprovechar, y para que al morir pueda exclamar que toda su vida y todas sus fuerzas, " +
            "lo ha dedicado a lo mas hermoso que posee el mundo, a la lucha por la justicia, la paz y la liberación de la humanidad.";
        neededSilences = 20;

        preparationText.text =
            "Welcome! It is time to practice the volume of your speech. You are going to speak in a small scenario so remember not to shout.\n\n" +
            "Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";

        preparationText.gameObject.SetActive(true);
        spacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spacePressed && Input.GetKeyDown(KeyCode.Space))
        {
            preparationText.text = speech + "\n\nPress SPACE when you are ready to start. Press SPACE again to finish the game.";
            spacePressed = true;
        }
        else if (spacePressed && Input.GetKeyDown(KeyCode.Space))
        {
            VolumeManager.speech = speech;
            VolumeManager.neededSilences = neededSilences;
            panel.gameObject.SetActive(false);
            preparationText.gameObject.SetActive(false);
            VolumeManagerGO.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
