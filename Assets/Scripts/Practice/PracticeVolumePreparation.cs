using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PracticeVolumePreparation : MonoBehaviour
{

    private const float MAX_VOLUME = 8.0f;
    public Text preparationText;
    private string speech;

    private bool spacePressed;
    private float upperThreshold;
    private float lowerThreshold;
    public static int silencesNeeded;
    public static int longSilencesNeeded;
    public static List<string> kwordNeeded = new List<string>();
    
    public GameObject VolumeManagerGO;
    public GameObject VolumeSoundLoudnessGO;
    public GameObject panel;
    public GameObject pointerGO;
    public GameObject topPointerGO;
    public GameObject bottomPointerGO;
    public GameObject upperThresholdGO;
    public GameObject lowerThresholdGO;
    public GameObject TimerGO;
    private PracticeVolumeSoundLoudness volumeSL;

    
    void Start()
    {
        panel.gameObject.SetActive(true);
        TimerGO.gameObject.SetActive(true);
        volumeSL = VolumeSoundLoudnessGO.GetComponent<PracticeVolumeSoundLoudness>();
        
        
        upperThreshold = 11.0f;
        lowerThreshold = 3.0f;
        silencesNeeded = 4;
        longSilencesNeeded = 1;
        Manager.speech = "";
        speech = "Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente. "+ 
            "No era un camino muy ancho, ni muy transitado. No parecía que condujera a ninguna parte, como pasa con algunos caminos. El posadero inspiró el aire "+ 
            "otoñal y miró alrededor, inquieto, como si esperase que sucediera algo.";
        kwordNeeded.Add("No era un camino");
        kwordNeeded.Add("ni muy transitado");
        kwordNeeded.Add("No parecía que");
        kwordNeeded.Add("El posadero");
        kwordNeeded.Add("inquieto");
        kwordNeeded.Add("como si esperase");

        volumeSL.SetThresholds(upperThreshold, lowerThreshold);
    }

    private void OnEnable()
    {
        if (OVRManager.isHmdPresent)// headset connected
        {
            preparationText.text =
        "¡Bienvenido! Es momento de practicar todo lo que has aprendido. Vas a hacer un discurso en un escenario MEDIANO (para las primeras 4 filas del cine) con 4 silencios de entre 0.6 y 1.1 segundos " +
        "y 2 silencios largos de entre 1.1 y 2.1 segundos. " +
        "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
        "\n\nPresiona A para leer el discurso.";
        }
        else
        {
            preparationText.text =
        "¡Bienvenido! Es momento de practicar todo lo que has aprendido. Vas a hacer un discurso en un escenario MEDIANO (para las primeras 4 filas del cine) con 4 silencios de entre 0.6 y 1.1 segundos " +
        "y 2 silencios largos de entre 1.1 y 2.1 segundos. " +
        "Las barritas que tienes a la izquierda del texto te indicarán si hablas muy alto, muy bajo o al volumen correcto.\n\n" +
        "\n\nPresiona ESPACIO para leer el discurso.";
        }

        preparationText.gameObject.SetActive(true);
        spacePressed = false;
    }
    
    void Update()
    {
        if (OVRManager.isHmdPresent)// headset connected
        {
            if (!spacePressed && OVRInput.GetDown(OVRInput.Button.One))
            {
                preparationText.text = speech + "\n\nPresiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego"; //"\n\nPress A when you are ready to present. Press A again to finish the game.";
                spacePressed = true;
            }
            else if (OVRInput.GetDown(OVRInput.Button.One))
            {
                PracticeVolumeManager.speech = speech;
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
                preparationText.text = speech + "\n\nPresiona ESPACIO cuando estés listo para presentar. Una vez estés jugando, presiona ESPACIO otra vez para parar el juego"; //"\n\nPress SPACE when you are ready to present. Press SPACE again to finish the game.";
                spacePressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                PracticeVolumeManager.speech = speech;
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
