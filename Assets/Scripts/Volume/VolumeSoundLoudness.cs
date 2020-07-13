using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class VolumeSoundLoudness : MonoBehaviour
{

    public static float step = 0.5f;//half a second
    public static float upperThreshold;//Upper threshold 
    public static float lowerThreshold;//Lower threshold

    public Material pointerMaterial;
    public Material thresholdMaterial;

    public GameObject pointerGO;
    public GameObject topPointerGO;
    public GameObject bottomPointerGO;
    public GameObject upperThresholdGO;
    public GameObject lowerThresholdGO;


    int _sampleWindow = 1024;
    private List<float> results;
    public static bool collect;

    float actTime;

    private int secCounter = 0;

    //mic initialization

    void Start()
    {
        //Results.gameObject.SetActive(false);

        //results = new List<float>();
        //collect = false;
        actTime = Time.realtimeSinceStartup;
        secCounter = 0;

        //Set physical thresholds and pointer
        lowerThreshold = 0.09f;
        upperThreshold = 0.2f;
        float height = upperThreshold * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        upperThresholdGO.transform.position = new Vector3(upperThresholdGO.transform.position.x, height, upperThresholdGO.transform.position.z);
        height = lowerThreshold * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        lowerThresholdGO.transform.position = new Vector3(lowerThresholdGO.transform.position.x, height, lowerThresholdGO.transform.position.z);
        height = ((upperThreshold + lowerThreshold) / 2) * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);
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
            CheckVolume(aux);
            //results.Add(aux);
            // Debug.Log(aux);
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
            thresholdMaterial.color = Color.white;
            secCounter++;
        }
        else if(aux >= upperThreshold) //Incorrect volume upper
        {
            //Puntar la raya roja por encima de las marcas. Mandar mensaje "lower the volume"
            pointerMaterial.color = Color.red;
            thresholdMaterial.color = Color.red;
        }
        else//Incorrect volume lower
        {
            //Pintar la raya roja por debajo de las marcas. Mandar mensaje "raise the volume"
            pointerMaterial.color = Color.red;
            thresholdMaterial.color = Color.red;
        }
        //Actualizar los dibujos
        float height = aux * (topPointerGO.transform.position.y - bottomPointerGO.transform.position.y) + bottomPointerGO.transform.position.y;
        pointerGO.transform.position = new Vector3(pointerGO.transform.position.x, height, pointerGO.transform.position.z);

        Debug.Log(aux);
    }
}