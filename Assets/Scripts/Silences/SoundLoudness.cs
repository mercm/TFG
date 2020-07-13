using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SoundLoudness : MonoBehaviour
{

    public static float step = 0.5f;//half a second
    public static float silenceThreshold = 0.02f;//Calculate value depending on microphone and place


    int _sampleWindow = 1024;
    private List<float> results;
    public static bool collect;

    float actTime;

    private int secCounter = 0;
    public static int silenceCounter;
    public static int longSilenceCounter;

    public Text silencesText;
    public Text longSilencesText;

    public GameObject Results;
    //public GameObject PreparationGO;

    //mic initialization

    void Start()
    {
        //Results.gameObject.SetActive(false);

        results = new List<float>();
        //collect = true;
        actTime = Time.realtimeSinceStartup;
        secCounter = 0;
        silenceCounter = 0;
        longSilenceCounter = 0;
        this.gameObject.SetActive(false);
    }
    public void changeCollecting(bool change)
    {
        collect = change;
    }
    /*void OnDisable()
    {
        collect = false;
    }*/
    void OnEnable()
    {
        collect = true;
    }
    public float[] GetData()
    {
        return results.ToArray();
    }
    /// <summary>
    /// Obtiene el valor medio cuadrático de 1024 muestras obtenidas en el instante.
    /// Con ese valor, calcula el valor en decibelios de la muestra. 
    /// </summary>
    /// <returns>Valor en decibelios del micrófono.</returns>
    float getLoudness()
    {

        float[] waveData = new float[_sampleWindow];
        int micPosition = MicrophoneManager.GetMicrophonePosition() - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        MicrophoneManager.AudioClip.GetData(waveData, micPosition);

        //Normalize(waveData);

        //Root Mean Square value calculation
        float rmsvalue = 0.0f;
        for (int i = 0; i < _sampleWindow; i++)
        {
            rmsvalue += waveData[i] * waveData[i];
        }
        rmsvalue = Mathf.Sqrt(rmsvalue / _sampleWindow);//Value between 0 and 1 which indicates the loudness of the sound

        //float decibels = 20 * Mathf.Log10(rmsvalue / 0.01f);

        return rmsvalue;
    }

    //Normalización multiplicado por 1/max del array
    void Normalize(float[] arr)
    {
        //Normalización de los datos
        float max = arr.Max();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i] * (1 / max);
        }
    }

    void Update()
    {
        if (!collect)
        {
            silencesText.text = "Silences";
            longSilencesText.text = "Long silences";
            return;
        }
        float aux = -100f;
        UpdateSilencesTexts();
        //Destroy(Preparation);
        if (Time.realtimeSinceStartup - actTime > step)
        {
            aux = getLoudness();
            CheckSilences(aux);
            //results.Add(aux);
            // Debug.Log(aux);
            //if (DataManager.instance != null) DataManager.instance.AddSound(aux);
            actTime = Time.realtimeSinceStartup;
        }
    }

    void CheckSilences(float aux)
    {
        if (aux <= silenceThreshold)//if the user is in silence
        {
            secCounter++;
        }
        else//if the user starts talking again
        {
            if (secCounter >= 3 && secCounter <= 5)//if the silence has a duration between 1.5 and 2.5 seconds.
            {
                silenceCounter++;
            }
            else if (secCounter > 5 && secCounter <= 7)//if the silence has a duration between 2.5 and 3.5 seconds.
            {
                longSilenceCounter++;
            }
            UpdateSilencesTexts();
            secCounter = 0;
        }
    }

    void UpdateSilencesTexts()
    {
        silencesText.text = "Silences: " + silenceCounter.ToString() + " /" + Preparation.silencesNeeded;
        longSilencesText.text = "Long silences: " + longSilenceCounter.ToString() + " /" + Preparation.longSilencesNeeded;
    }
}