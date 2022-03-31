using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PracticeVolumePreparation : MonoBehaviour
{

    private const float MAX_VOLUME = 8.0f;
    public Text preparationText;
    private string speech;
    public Button returnButton;

    private bool spacePressed;
    //private int neededSilences;
    //private bool next;
    //private float countDown;//Countdown to start
    //public Text countDownText;//Countdown to start Text
    private float upperThreshold;
    private float lowerThreshold;
    public static int silencesNeeded;
    public static int longSilencesNeeded;
    public static List<string> kwordNeeded = new List<string>();

    //public GameObject VolumeSoundLoudnessGO;
    public GameObject VolumeManagerGO;
    public GameObject VolumeSoundLoudnessGO;
    public GameObject panel;
    public GameObject pointerGO;
    public GameObject topPointerGO;
    public GameObject bottomPointerGO;
    public GameObject upperThresholdGO;
    public GameObject lowerThresholdGO;
    //public GameObject speechPanel;
    private PracticeVolumeSoundLoudness volumeSL;

    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(true);
        volumeSL = VolumeSoundLoudnessGO.GetComponent<PracticeVolumeSoundLoudness>();
        
        
        upperThreshold = 3.5f;
        lowerThreshold = 0.5f;
        silencesNeeded = 4;
        longSilencesNeeded = 1;
        Manager.speech = "";
        speech = @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de
            personas de todos los lugares de nuestro territorio y sin cuya participación no puede entenderse el curso de la Humanidad.";
        kwordNeeded.Add("consciente de la responsabilidad");
        kwordNeeded.Add("y con la mayor esperanza");
        kwordNeeded.Add("Una nación forjada");
        kwordNeeded.Add("por el trabajo compartido");
        kwordNeeded.Add("y sin cuya participación");

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
        returnButton.gameObject.SetActive(true);
        preparationText.text =
        "Welcome! It is time to practice every thing you learnt. You are going to do a speech in a medium scenario with 4 silences between 0.7 and 1.4 seconds" +
        "and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";

        //neededSilences = 20;

        //speechPanel.gameObject.SetActive(false);
        preparationText.gameObject.SetActive(true);
        spacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spacePressed && Input.GetKeyDown(KeyCode.Space))
        {
            preparationText.text = speech + "\n\n\nPress SPACE when you are ready to present. Press SPACE again to finish the game.";
            spacePressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            PracticeVolumeManager.speech = speech;
            //VolumeManager.neededSilences = neededSilences;
            panel.gameObject.SetActive(false);
            //speechPanel.gameObject.SetActive(true);
            preparationText.gameObject.SetActive(false);
            VolumeManagerGO.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
