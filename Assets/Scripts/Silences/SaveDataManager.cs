using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager instance = null;

    [Serializable]
    class Data
    {
        public string info;
        public List<float> data;
        public int epoch;

    }
    public int user = 0;
    
    public void SaveData(string info, List<float> datos)
    {
        Data aux = new Data();
        aux.info = info;
        aux.epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        
        aux.data = new List<float>(datos);

        string json = JsonUtility.ToJson(aux);
  
        File.WriteAllText(Application.dataPath + "/RecordedData/" + "User" + user +"Type"+info+".json", json);

    }


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

}

