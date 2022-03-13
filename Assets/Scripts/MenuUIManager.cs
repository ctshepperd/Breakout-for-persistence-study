using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class MenuUIManager : MonoBehaviour
{
    public string nameText;

    public TextMeshProUGUI scoreText;

    public void Start()
    {
        DataManager.Instance.LoadHighScore();

        nameText = DataManager.Instance.highScorePlayerName;

        if (DataManager.Instance.highScorePlayerName != null)
        {
            scoreText.SetText("High Score: " + DataManager.Instance.highScorePlayerName + " : " + DataManager.Instance.highScore);
        } else
        {
            scoreText.SetText("No high score yet");
        }
    }

    public void InputPlayerName(string s)
    {
        
        if (DataManager.Instance == null) Debug.Log("DataManager instance doesn't exist");

        
        DataManager.Instance.currentPlayerName = s;

        Debug.Log(DataManager.Instance.currentPlayerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }



}
