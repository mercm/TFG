using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEditor;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine.UI;
using System.Threading;
using System.IO;

public class Dictation : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;

    private string resultText;
    private string auxText;
    private bool enableCount;
    private bool finish;
    private float secCounter;

    private Manager manager;
    private SoundLoudness soundLoudness;

    public GameObject ManagerGO;
    public GameObject SoundLoudnessGO;

    // Start is called before the first frame update
    void Start()
    {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.InitialSilenceTimeoutSeconds = 4.0f;
        dictationRecognizer.AutoSilenceTimeoutSeconds = 0.5f;

        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;

        manager = ManagerGO.GetComponent<Manager>();
        soundLoudness = SoundLoudnessGO.GetComponent<SoundLoudness>();

        //PhraseRecognitionSystem.Shutdown();//Lo necesito?
        //dictationRecognizer.Start();
    }

    //In this method we manage the output text
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        resultText += " " + text;//Adds the text said before starting the silence
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        //Ahora está en Update() en más de 4 segundos
        manager.setStop(true);
        dictationRecognizer.Stop();
        StreamWriter outputFile = new StreamWriter(@"C:\Users\esthe\Documents\Universidad\TFG\Repo\TFG\Assets\Outputs\output.txt");
        outputFile.WriteLine(resultText);
        outputFile.Close();
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        //Not needed method
        //Could be used to check if the text is correct
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        //Not needed method
    }

    void OnDestroy()
    {

        dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
        dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
        dictationRecognizer.Dispose();

    }

    public void enableDictation()
    {
       // PhraseRecognitionSystem.Shutdown();//Lo necesito?

        resultText = "";
        secCounter = 0.5f;
        auxText = "";
        enableCount = false;
        finish = false;

        dictationRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //if (enableCount && !finish)
        if (!finish)
        {
            if (!soundLoudness.StillOnSilence())
            {
                secCounter += 0.5f;
            }
            else
            {
                if (secCounter >= 0.5 && secCounter <= 0.9)
                {
                    soundLoudness.AddSilence();
                    resultText += " // ";
                }
                else if (secCounter > 0.9 && secCounter <= 3.9)
                {
                    soundLoudness.AddLongSilence();
                    resultText += " /// ";
                }
                else if(secCounter > 3.9)
                {
                    finish = true;
                }
                auxText = "";
                enableCount = false;
                secCounter = 0.5f;
            }
        }
    }
}
