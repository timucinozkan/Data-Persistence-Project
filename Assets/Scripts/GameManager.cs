using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public int bestScorePoints;
    public string bestScoreName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public string bestScoreName;
        public int bestScorePoints;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScoreName = bestScoreName;
        data.bestScorePoints = bestScorePoints;

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScoreName = data.bestScoreName;
            bestScorePoints = data.bestScorePoints;
        }
    }
}
