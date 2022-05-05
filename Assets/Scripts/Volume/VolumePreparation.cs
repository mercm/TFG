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
    //public Button returnButton;

    private bool spacePressed;
    //private int neededSilences;
    private int level;
    //private bool next;
    //private float countDown;//Countdown to start
    //public Text countDownText;//Countdown to start Text
    private float upperThreshold;
    private float lowerThreshold;

    //public GameObject VolumeSoundLoudnessGO;
    public GameObject VolumeManagerGO;
    public GameObject VolumeSoundLoudnessGO;
    public GameObject panel;
    public GameObject pointerGO;
    public GameObject topPointerGO;
    public GameObject bottomPointerGO;
    public GameObject upperThresholdGO;
    public GameObject lowerThresholdGO;
    public GameObject scenarioLevel1;
    public GameObject scenarioLevel2;
    public GameObject scenarioLevel3;
    //public GameObject speechPanel;
    private VolumeSoundLoudness volumeSL;

    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(true);
        level = PlayerPrefs.GetInt("Level");
        volumeSL = VolumeSoundLoudnessGO.GetComponent<VolumeSoundLoudness>();
        if(level == 1)
        {
            preparationText.text =
            "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario PEQUEÑO (para las primeras 4 filas del cine), así que, recuerda no gritar. \n\n" +
            "Presiona A para ver el texto del discurso. Podrás verlo durante del juego, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the volume of your speech. You are going to speak in a small scenario so remember not to shout.\n\n" +
            //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            upperThreshold = 3.5f;
            lowerThreshold = 0.5f;
        }
        else if(level == 2)
        {
            preparationText.text =
            "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario MEDIANO (para las primeras 10 filas del cine), así que, recuerda levantar un poco el volumen de tu voz. \n\n" +
            "Presiona A para ver el texto del discurso. Podrás verlo durante del juego, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the volume of your speech. You are going to speak in a medium scenario so remember to raise the volume a bit.\n\n" +
            //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            upperThreshold = 5.0f;
            lowerThreshold = 3.0f;
        }
        else if(level == 3)
        {
            preparationText.text =
            "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario GRANDE, así que, recuerda elevar la voz lo suficiente. \n\n" +
            "Presiona A para ver el texto del discurso. Podrás verlo durante del juego, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the volume of your speech. You are going to speak in a big scenario so remember to raise the volume but try not to shout.\n\n" +
            //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            upperThreshold = 6.0f;
            lowerThreshold = 5.0f;
        }
        /*else
        {
            upperThreshold = 3.5f;
            lowerThreshold = 0.5f;
        }*/

        volumeSL.SetThresholds(upperThreshold, lowerThreshold);
        /*float height = (upperThreshold * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y) / MAX_VOLUME;
        upperThresholdGO.transform.position = new Vector3(upperThresholdGO.transform.position.x, height, upperThresholdGO.transform.position.z);
        height = (lowerThreshold * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y) / MAX_VOLUME;
        lowerThresholdGO.transform.position = new Vector3(lowerThresholdGO.transform.position.x, height, lowerThresholdGO.transform.position.z);
        height = ((upperThreshold + lowerThreshold) / 2) * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);*/
    }

    private void OnEnable()
    {
        //returnButton.gameObject.SetActive(true);

        Manager.speech = "";
        speech = @"Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente. 
            No era un camino muy ancho, ni muy transitado. No parecía que condujera a ninguna parte, como pasa con algunos caminos. El posadero inspiró el aire 
            otoñal y miró alrededor, inquieto, como si esperase que sucediera algo.";
        //neededSilences = 20;

        if (level == 1)
        {
            preparationText.text =
            "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario PEQUEÑO (para las primeras 4 filas del cine), así que, recuerda no gritar. \n\n" +
            "Presiona A para ver el texto del discurso. Podrás verlo durante del juego, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the volume of your speech. You are going to speak in a SMALL scenario (for the firs 4 rows) so remember not to shout.\n\n" +
            //"Press A to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            scenarioLevel1.gameObject.SetActive(true);
            scenarioLevel2.gameObject.SetActive(false);
            scenarioLevel3.gameObject.SetActive(false);
        }
        else if (level == 2)
        {
            preparationText.text =
            "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario MEDIANO (para las primeras 10 filas del cine), así que, recuerda levantar un poco el volumen de tu voz. \n\n" +
            "Presiona A para ver el texto del discurso. Podrás verlo durante del juego, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the volume of your speech. You are going to speak in a medium scenario so remember to raise the volume a bit.\n\n" +
            //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            scenarioLevel1.gameObject.SetActive(false);
            scenarioLevel2.gameObject.SetActive(true);
            scenarioLevel3.gameObject.SetActive(false);
        }
        else //if (level == 3)
        {
            preparationText.text =
            "¡Bienvenido! Es momento de practicar el volumen de un discurso. Vas a hablar en un escenario GRANDE, así que, recuerda elevar la voz lo suficiente. \n\n" +
            "Presiona A para ver el texto del discurso. Podrás verlo durante del juego, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the volume of your speech. You are going to speak in a big scenario so remember to raise the volume but try not to shout.\n\n" +
            //"Press SPACE to see the speech. You will be able to see it during the game so it's not necessary to memorize it.";
            scenarioLevel1.gameObject.SetActive(false);
            scenarioLevel2.gameObject.SetActive(false);
            scenarioLevel3.gameObject.SetActive(true);
        }

        //speechPanel.gameObject.SetActive(false);
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
                preparationText.text = speech + "Presiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
                //"\n\nPress SPACE when you are ready to present. Press SPACE again to finish the game.";
                spacePressed = true;
            }
            else if (OVRInput.GetDown(OVRInput.Button.One))
            {
                VolumeManager.speech = speech;
                //VolumeManager.neededSilences = neededSilences;
                panel.gameObject.SetActive(false);
                //speechPanel.gameObject.SetActive(true);
                preparationText.gameObject.SetActive(false);
                VolumeManagerGO.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
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
                preparationText.text = speech + "Presiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
                //"\n\nPress SPACE when you are ready to present. Press SPACE again to finish the game.";
                spacePressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                VolumeManager.speech = speech;
                //VolumeManager.neededSilences = neededSilences;
                panel.gameObject.SetActive(false);
                //speechPanel.gameObject.SetActive(true);
                preparationText.gameObject.SetActive(false);
                VolumeManagerGO.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
        
    }
}
