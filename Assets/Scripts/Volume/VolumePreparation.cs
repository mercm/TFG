using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumePreparation : MonoBehaviour
{

    private const float MAX_VOLUME = 8.0f;
    public Text preparationText;
    private string speech;

    private bool spacePressed;
    private int level;
    private float upperThreshold;
    private float lowerThreshold;
    
    public GameObject VolumeManagerGO;
    public GameObject VolumeSoundLoudnessGO;
    public GameObject panel;
    public GameObject pointerGO;
    public GameObject topPointerGO;
    public GameObject bottomPointerGO;
    public GameObject upperThresholdGO;
    public GameObject lowerThresholdGO;
    private VolumeSoundLoudness volumeSL;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(true);
        level = PlayerPrefs.GetInt("Level");
        volumeSL = VolumeSoundLoudnessGO.GetComponent<VolumeSoundLoudness>();
        if(level == 1)
        {
            if (OVRManager.isHmdPresent)// headset connected
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario PEQUEÑO (para las primeras 2 filas del cine), así que, recuerda no gritar. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a SMALL scenario so remember not to shout.\n\n" +
                //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
            else
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario PEQUEÑO (para las primeras 2 filas del cine), así que, recuerda no gritar. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona ESPACIO para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a SMALL scenario so remember not to shout.\n\n" +
                //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }

            upperThreshold = 8.0f;
            lowerThreshold = 1.0f;
            levelText.text = "Nivel 1";
            //levelText.text = "Level 1";
        }
        else if(level == 2)
        {
            if (OVRManager.isHmdPresent)// headset connected
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario MEDIANO (para las primeras 4 filas del cine), así que, recuerda levantar un poco el volumen de tu voz. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a MEDIUM scenario so remember to raise the volume a bit.\n\n" +
                //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
            else
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario MEDIANO (para las primeras 4 filas del cine), así que, recuerda levantar un poco el volumen de tu voz. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona ESPACIO para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a MEDIUM scenario so remember to raise the volume a bit.\n\n" +
                //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }

            upperThreshold = 11.0f;
            lowerThreshold = 3.0f;
            levelText.text = "Nivel 2";
            //levelText.text = "Level 2";
        }
        else if(level == 3)
        {
            if (OVRManager.isHmdPresent)// headset connected
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario GRANDE (para las primeras 6 filas del cine), así que, recuerda elevar la voz lo suficiente. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a BIG scenario so remember to raise the volume but try not to shout.\n\n" +
                //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
            else
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario GRANDE (para las primeras 6 filas del cine), así que, recuerda elevar la voz lo suficiente. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona ESPACIO para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a BIG scenario so remember to raise the volume but try not to shout.\n\n" +
                //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }

            upperThreshold = 15.0f;
            lowerThreshold = 6.0f;
            levelText.text = "Nivel 3";
            //levelText.text = "Level 3";
        }

        Debug.Log("UpperThreshold: " + upperThreshold + ". \nLowerThreshold: " + lowerThreshold);

        volumeSL.SetThresholds(upperThreshold, lowerThreshold);
    }

    private void OnEnable()
    {
        Manager.speech = "";
        speech = "Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente. "+
            "No era un camino muy ancho, ni muy transitado. No parecía que condujera a ninguna parte, como pasa con algunos caminos. El posadero inspiró el aire "+
            "otoñal y miró alrededor, inquieto, como si esperase que sucediera algo.";

        if (level == 1)
        {
            if (OVRManager.isHmdPresent)// headset connected
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario PEQUEÑO (para las primeras 2 filas del cine), así que, recuerda no gritar. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a SMALL scenario so remember not to shout.\n\n" +
                //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
            else
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario PEQUEÑO (para las primeras 2 filas del cine), así que, recuerda no gritar. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona ESPACIO para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a SMALL scenario so remember not to shout.\n\n" +
                //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
        }
        else if (level == 2)
        {
            if (OVRManager.isHmdPresent)// headset connected
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario MEDIANO (para las primeras 4 filas del cine), así que, recuerda levantar un poco el volumen de tu voz. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a MEDIUM scenario so remember to raise the volume a bit.\n\n" +
                //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
            else
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario MEDIANO (para las primeras 4 filas del cine), así que, recuerda levantar un poco el volumen de tu voz. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona ESPACIO para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a MEDIUM scenario so remember to raise the volume a bit.\n\n" +
                //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
        }
        else //if (level == 3)
        {
            if (OVRManager.isHmdPresent)// headset connected
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario GRANDE (para las primeras 6 filas del cine), así que, recuerda elevar la voz lo suficiente. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a BIG scenario so remember to raise the volume but try not to shout.\n\n" +
                //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
            else
            {
                preparationText.text =
                "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario GRANDE (para las primeras 6 filas del cine), así que, recuerda elevar la voz lo suficiente. \n\n" +
                "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
                "Presiona ESPACIO para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
                //"Welcome! It is time to practice the volume of your speech. You are going to speak in a BIG scenario so remember to raise the volume but try not to shout.\n\n" +
                //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            }
        }
        
        preparationText.gameObject.SetActive(true);
        spacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRManager.isHmdPresent)// headset connected
        {
            if (!spacePressed && OVRInput.GetDown(OVRInput.Button.One))
            {
                preparationText.text = speech + "\n\nPresiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
                //"\n\nPress SPACE when you are ready to present. Press SPACE again to finish the game.";
                spacePressed = true;
            }
            else if (OVRInput.GetDown(OVRInput.Button.One))
            {
                VolumeManager.speech = speech;
                panel.gameObject.SetActive(false);
                preparationText.gameObject.SetActive(false);
                VolumeManagerGO.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
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
                preparationText.text = speech + "\n\nPresiona ESPACIO cuando estés listo para presentar. Una vez estés jugando, presiona ESPACIO otra vez para parar el juego";
                //"\n\nPress SPACE when you are ready to present. Press SPACE again to finish the game.";
                spacePressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                VolumeManager.speech = speech;
                panel.gameObject.SetActive(false);
                preparationText.gameObject.SetActive(false);
                VolumeManagerGO.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
    }
}
