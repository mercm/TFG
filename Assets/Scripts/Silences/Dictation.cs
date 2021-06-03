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
    private bool enable;
    private bool finish;
    private float countDown;
    private Results results;
    public GameObject ResultsGO;
    private Manager manager;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.InitialSilenceTimeoutSeconds = 7f;//Pensar si este valor tiene sentido
        dictationRecognizer.AutoSilenceTimeoutSeconds = 3.5f;//Pensar si este valor tiene sentido

        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;

        //enable = false;
        //finish = false;

        //results = ResultsGO.GetComponent<Results>();
        manager = ManagerGO.GetComponent<Manager>();

        //PhraseRecognitionSystem.Shutdown();//Lo necesito?
        //dictationRecognizer.Start();
    }

    //In this method we manage the output text
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        //dictationRecognizer.Start();
        resultText += " " + text;
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        //results.setReady(true);
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
        dictationRecognizer.Start();
        //enable = true;
        //finish = false;
        resultText = "";
        //countDown = 5;
    }

    public void addSilence()
    {
        resultText += " // ";
    }

    public void addLongSilence()
    {
        resultText += " /// ";
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log("DICTATOR STATUS: " + dictationRecognizer.Status);
        /*if (enable && Input.GetKeyDown(KeyCode.Space))
        {
            enable = false;
            finish = true;
        }
        if (finish)//To make sure all the text has been written
        {
            if (countDown <= 0)
            {
                results.setReady(true);
                dictationRecognizer.Stop();
                StreamWriter outputFile = new StreamWriter(@"C:\Users\esthe\Documents\Universidad\TFG\Repo\TFG\Assets\Outputs\output.txt");
                outputFile.WriteLine(resultText);
                outputFile.Close();
                finish = false;
                //PhraseRecognitionSystem.Restart();
            }
            else
            {
                countDown -= Time.deltaTime;
            }
        }*/
    }
}
