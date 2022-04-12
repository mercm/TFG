using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PracticeVolumeSoundLoudness : MonoBehaviour
{
    private const int MAX_VOLUME = 100;

    public static float step = 0.5f;//half a second
    public static float upperThreshold;//Upper threshold 
    public static float lowerThreshold;//Lower threshold
    public static float silenceThreshold = 0.4f;//Calculate value depending on microphone and place

    public Material pointerMaterial;
    public Material thresholdMaterial;

    public GameObject pointerGO;
    public GameObject topPointerGO;
    public GameObject bottomPointerGO;
    public GameObject upperThresholdGO;
    public GameObject lowerThresholdGO;

    private List<float> ambiente = new List<float>();


    int _sampleWindow = 1024;
    //private List<float> results;
    public static bool collect;
    public bool startedTalking;//Not taking into consideration the first silence
    float actTime;
    public TextMeshPro correctionText;

    public static int correctSecCounter = 0;
    public static int upIncorrectSecCounter;
    public static int lowIncorrectSecCounter;

    //mic initialization

    void Start()
    {
        //Results.gameObject.SetActive(false);

        //results = new List<float>();
        //collect = false;
        actTime = Time.realtimeSinceStartup;
        correctSecCounter = 0;
        upIncorrectSecCounter = 0;
        lowIncorrectSecCounter = 0;
        correctionText.text = "";

        //Set physical thresholds and pointer
        //lowerThreshold = 0.5f;//1.0f;
        //upperThreshold = 3.0f;//6.0f;
        //float height = upperThreshold * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        //upperThresholdGO.transform.position = new Vector3(upperThresholdGO.transform.position.x, height, upperThresholdGO.transform.position.z);
        //height = lowerThreshold * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        //lowerThresholdGO.transform.position = new Vector3(lowerThresholdGO.transform.position.x, height, lowerThresholdGO.transform.position.z);
        float height = ((upperThreshold + lowerThreshold) / 2) * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);
        //correctionText.gameObject.SetActive(false);
        //this.gameObject.SetActive(false);
    }
    public void ChangeCollecting(bool change)
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
        //correctionText.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        startedTalking = false;
    }

    public void SetThresholds(float upper, float lower)
    {
        upperThreshold = upper;
        lowerThreshold = lower;
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
    float GetLoudness()
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
        float aux = -100f;
        if (Time.realtimeSinceStartup - actTime > step)
        {
            aux = GetLoudness();
            //Debug.Log("valor: " + aux);
            aux = aux * MAX_VOLUME;
            //Debug.Log("valor por 100: " + aux);
            if (!startedTalking && aux >= silenceThreshold)//Make sure the first silence is not taken into consideration
            {
                startedTalking = true;
            }
            if (startedTalking)
            {
                CheckVolume(aux);
            }
            
            //results.Add(aux);
            //if (DataManager.instance != null) DataManager.instance.AddSound(aux);
            actTime = Time.realtimeSinceStartup;
        }
    }

    void CheckVolume(float aux)
    {
        if (aux <= upperThreshold && aux >= lowerThreshold)//Correct volume
        {
            //Pintar la raya verde entre los márgenes dependiendo de aux. Contar el tiempo que lo ha hecho bien.
            pointerMaterial.color = Color.green;
            thresholdMaterial.color = Color.green;
            correctSecCounter++;
            correctionText.text = "";
            float aux1 = (aux - lowerThreshold) / (upperThreshold - lowerThreshold);
            float height = aux1 * (upperThresholdGO.transform.position.y - lowerThresholdGO.transform.position.y) + lowerThresholdGO.transform.position.y;
            pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);
        }
        else if(aux > upperThreshold) //Incorrect volume (too loud)
        {
            //Puntar la raya roja por encima de las marcas. Mandar mensaje "lower the volume"
            pointerMaterial.color = Color.red;
            thresholdMaterial.color = Color.red;
            upIncorrectSecCounter++;
            correctionText.text = "Lower down the volume";
            float aux2 = (aux - upperThreshold) / (MAX_VOLUME - upperThreshold);
            float height = aux2 * (topPointerGO.transform.position.y - upperThresholdGO.transform.position.y) + upperThresholdGO.transform.position.y;
            pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);
        }
        else //Incorrect volume (too low)
        {
            //Puntar la raya roja por encima de las marcas. Mandar mensaje "raise the volume"
            pointerMaterial.color = Color.red;
            thresholdMaterial.color = Color.red;
            if (aux < lowerThreshold && aux > silenceThreshold)//Solo se cuenta negativo si no se ha hecho un silencio sino que se ha hablado bajo
            {
                lowIncorrectSecCounter++;
            }
            correctionText.text = "Raise up the volume";
            float aux3 = (aux - lowerThreshold) / lowerThreshold;
            float height = aux3 * (lowerThresholdGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
            pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);
        }

        Debug.Log("volume: " + aux);
    }
}