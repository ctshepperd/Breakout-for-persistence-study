using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string currentPlayerName;

    public string highScorePlayerName;

    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string BestPlayer;
    }

    public void SaveHighScore()
    {
        //create a save data class instance
        SaveData data = new SaveData();

        //assign the team color in the save data to the currently selected color
        data.HighScore = highScore;
        data.BestPlayer = highScorePlayerName;

        //create a json script of the current data
        string json = JsonUtility.ToJson(data);

        //write that json data to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadHighScore()
    {
        //find the save data file
        string path = Application.persistentDataPath + "/savefile.json";

        //if the save data file exists...
        if (File.Exists(path))
        {
            //load the text of the file into a string
            string json = File.ReadAllText(path);

            //parse the string from json into our <SaveData> class
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //assign the color from the class into the current team color
            highScore = data.HighScore;
            highScorePlayerName = data.BestPlayer;
        }

    }
}
