﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsConfig : MonoBehaviour
{
    public Button silence;
    public Button volume;
    public Button play;
    public Button VL1;
    public Button VL2;
    public Button VL3;
    public Button SL1;
    public Button SL2;
    public Button SL3;
    public Button PL1;
    public Button PL2;
    public Button PL3;
    public Text volumeText;
    public Text silenceText;
    public Text playText;

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
        PL1.gameObject.SetActive(false);
        PL2.gameObject.SetActive(false);
        PL3.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        silenceText.gameObject.SetActive(false);
        playText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}