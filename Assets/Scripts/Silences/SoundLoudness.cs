using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SoundLoudness : MonoBehaviour
{

    public static float step = 0.5f;//half a second
    public static float silenceThreshold = 1.0f;//Calculate value depending on microphone and place


    int _sampleWindow = 1024;
    //private List<float> results;
    public static bool collect;
    //public bool startedTalking;//Not taking into consideration the first silence
    private float volume;

    float actTime;

    private float secCounter = 0f;
    public static int silenceCounter;
    public static int longSilenceCounter;
    private string lastSilence;

    public Text silencesText;
    public Text longSilencesText;

    //private Dictation dictation;

    public GameObject Results;
    //public GameObject DictationGO;
    //public GameObject PreparationGO;

    //mic initialization

    void Start()
    {
        //results = new List<float>();
        //dictation = DictationGO.GetComponent<Dictation>();
        //collect = true;
        this.gameObject.SetActive(false);
    }
    void OnDisable()
    {
        collect = false;
        //startedTalking = false;
        silencesText.text = "Silences";
        longSilencesText.text = "Long silences";
    }
    void OnEnable()
    {
        collect = true;
        UpdateSilencesTexts();
        actTime = Time.realtimeSinceStartup;
        secCounter = 0f;
        silenceCounter = 0;
        longSilenceCounter = 0;
    }
    /*public float[] GetData()
    {
        return results.ToArray();
    }*/
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
            return;
        }
        volume = -100f;
        UpdateSilencesTexts();
        //Destroy(Preparation);
        if (Time.realtimeSinceStartup - actTime > step)
        {
            volume = getLoudness();
            volume = volume * 100;
            /*if(!startedTalking && aux >= silenceThreshold)//Make sure the first silence is not taken into consideration
            {
                startedTalking = true;
            }
            if (startedTalking)
            {
                CheckSilences(aux);
            }*/
            //results.Add(aux);
            Debug.Log(volume);
            //if (DataManager.instance != null) DataManager.instance.AddSound(aux);
            actTime = Time.realtimeSinceStartup;
        }
    }

    /*void CheckSilences(float aux)
    {
        if (aux <= silenceThreshold)//if the user is in silence
        {
            secCounter += 0.5f;//mid seconds counter
            //Debug.Log(secCounter);
        }
        else//if the user starts talking again
        {

            //Debug.Log(secCounter);
            if (secCounter >= 0.5 && secCounter <= 0.9)
            {
                silenceCounter++;
                //dictation.addSilence();
            }
            else if (secCounter > 0.9 && secCounter <= 3.9)
            {
                longSilenceCounter++;
                //dictation.addLongSilence();
            }
            UpdateSilencesTexts();
            //secCounter = 0;
        }
    }*/

    void UpdateSilencesTexts()
    {
        silencesText.text = "Silences: " + silenceCounter.ToString() + " /" + Preparation.silencesNeeded;
        longSilencesText.text = "Long silences: " + longSilenceCounter.ToString() + " /" + Preparation.longSilencesNeeded;
    }

    /*public float GetSecCounter()
    {
        return secCounter;
    }
    public void setSecCounter(float set)
    {
        secCounter = set;
    }*/
    public void AddSilence()
    {
        silenceCounter++;
    }
    public void AddLongSilence()
    {
        longSilenceCounter++;
    }

    public bool StillOnSilence()
    {
        if (volume <= silenceThreshold)//if the user is in silence
        {
            return true;
        }
        return false;
    }
}