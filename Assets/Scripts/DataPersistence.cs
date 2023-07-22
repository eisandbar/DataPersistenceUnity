using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence instance;
    public string highscoreUsername;
    public string currentUsername;
    public int score;

    private string file = "/score.json";

    public void UpdateName(string newName)
    {
        currentUsername = newName;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }


    [System.Serializable]
    class ScoreData
    {
        public string username;
        public int score;
    }
    public void SaveScore()
    {
        ScoreData data = new ScoreData();
        data.username = currentUsername;
        data.score = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + file, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + file;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            highscoreUsername = data.username;
            score = data.score;
        }
    }
}
