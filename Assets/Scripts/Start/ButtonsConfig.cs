using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsConfig : MonoBehaviour
{
    public bool silenceB;
    public bool volumeB;
    public Button silence;
    public Button volume;
    public Button play;
    public Button VL1;
    public Button VL2;
    public Button VL3;
    public Button SL1;
    public Button SL2;
    public Button SL3;
    public Button PL;
    public Button X;
    public Button returnButton;
    public Text volumeText;
    public Text silenceText;
    public Text playText;
    public Text silenceInstructions;
    public Text volumeInstructions;
    public Text playInstructions;
    private SilenceCS Cs;
    public GameObject instructionsPanel;
    public GameObject CSGO;

    // Start is called before the first frame update
    void Start()
    {
        silence.gameObject.SetActive(true);
        volume.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
        VL1.gameObject.SetActive(false);
        VL2.gameObject.SetActive(false);
        VL3.gameObject.SetActive(false);
        SL1.gameObject.SetActive(false);
        SL2.gameObject.SetActive(false);
        SL3.gameObject.SetActive(false);
        PL.gameObject.SetActive(false);
        //GetComponent<PL1>().interactable = false;
        //GetComponent<PL2>()..interactable = false;
        //GetComponent<PL3>()..interactable = false;
        X.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        silenceText.gameObject.SetActive(false);
        playText.gameObject.SetActive(false);
        silenceInstructions.gameObject.SetActive(false);
        volumeInstructions.gameObject.SetActive(false);
        playInstructions.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(false);

        silenceB = false;
        volumeB = false;

        Cs = CSGO.GetComponent<SilenceCS>();
    }

    public void SilenceAction()
    {

        silence.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        VL1.gameObject.SetActive(false);
        VL2.gameObject.SetActive(false);
        VL3.gameObject.SetActive(false);
        SL1.gameObject.SetActive(true);
        SL2.gameObject.SetActive(true);
        SL3.gameObject.SetActive(true);
        PL.gameObject.SetActive(true);
        SL1.interactable = false;
        SL2.interactable = false;
        SL3.interactable = false;
        X.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        volumeText.gameObject.SetActive(false);
        silenceText.gameObject.SetActive(true);
        playText.gameObject.SetActive(false);
        silenceInstructions.gameObject.SetActive(true);
        volumeInstructions.gameObject.SetActive(false);
        playInstructions.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(true);
    }

    public void VolumeAction()
    {

        silence.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        VL1.gameObject.SetActive(true);
        VL2.gameObject.SetActive(true);
        VL3.gameObject.SetActive(true);
        SL1.gameObject.SetActive(false);
        SL2.gameObject.SetActive(false);
        SL3.gameObject.SetActive(false);
        PL.gameObject.SetActive(false);
        VL1.interactable = false;
        VL2.interactable = false;
        VL3.interactable = false;
        X.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        volumeText.gameObject.SetActive(true);
        silenceText.gameObject.SetActive(false);
        playText.gameObject.SetActive(false);
        silenceInstructions.gameObject.SetActive(false);
        volumeInstructions.gameObject.SetActive(true);
        playInstructions.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(true); 
    }

    public void PlayAction()
    {

        silence.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        VL1.gameObject.SetActive(false);
        VL2.gameObject.SetActive(false);
        VL3.gameObject.SetActive(false);
        SL1.gameObject.SetActive(false);
        SL2.gameObject.SetActive(false);
        SL3.gameObject.SetActive(false);
        PL.gameObject.SetActive(true);
        PL.interactable = false;
        X.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        volumeText.gameObject.SetActive(false);
        silenceText.gameObject.SetActive(false);
        playText.gameObject.SetActive(true);
        silenceInstructions.gameObject.SetActive(false);
        volumeInstructions.gameObject.SetActive(false);
        playInstructions.gameObject.SetActive(true);
        instructionsPanel.gameObject.SetActive(true);
    }

    public void CloseInstructions()
    {
        SL1.interactable = true;
        SL2.interactable = true;
        SL3.interactable = true;
        VL1.interactable = true;
        VL2.interactable = true;
        VL3.interactable = true;
        PL.interactable = true;
        X.gameObject.SetActive(false);
        silenceInstructions.gameObject.SetActive(false);
        volumeInstructions.gameObject.SetActive(false);
        playInstructions.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(false);
    }

    public void ReturnAction()
    {

        silence.gameObject.SetActive(true);
        volume.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
        VL1.gameObject.SetActive(false);
        VL2.gameObject.SetActive(false);
        VL3.gameObject.SetActive(false);
        SL1.gameObject.SetActive(false);
        SL2.gameObject.SetActive(false);
        SL3.gameObject.SetActive(false);
        PL.gameObject.SetActive(false);
        X.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        silenceText.gameObject.SetActive(false);
        playText.gameObject.SetActive(false);
        silenceInstructions.gameObject.SetActive(false);
        volumeInstructions.gameObject.SetActive(false);
        playInstructions.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(false);

        silenceB = false;
        volumeB = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRManager.isHmdPresent)// headset connected
        {
            /*if (OVRInput.GetDown(OVRInput.Button.One)) //Deactivate instructions
            {
                //X.gameObject.SetActive(false);
                silenceInstructions.gameObject.SetActive(false);
                volumeInstructions.gameObject.SetActive(false);
                instructionsPanel.gameObject.SetActive(false);
            }*/
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                ReturnAction();
            }
        }
        else
        {
            if (!silenceB && !volumeB && Input.GetKeyDown(KeyCode.Alpha1))
            {
                SilenceAction();
                silenceB = true;
            }
            else if (!volumeB && !silenceB && Input.GetKeyDown(KeyCode.Alpha2))
            {
                VolumeAction();
                volumeB = true;
            }
            else if (silenceB)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Cs.ChangeSceneSLv1();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Cs.ChangeSceneSLv2();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Cs.ChangeSceneSLv3();
                }
            }
            else if (volumeB)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Cs.ChangeSceneVLv1();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Cs.ChangeSceneVLv2();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Cs.ChangeSceneVLv3();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Cs.ChangeSceneP();
            }
            if (Input.GetKeyDown(KeyCode.Space)) //Deactivate instructions
            {
                X.gameObject.SetActive(false);
                silenceInstructions.gameObject.SetActive(false);
                volumeInstructions.gameObject.SetActive(false);
                playInstructions.gameObject.SetActive(false);
                instructionsPanel.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ReturnAction();
            }
        }
    }
}
