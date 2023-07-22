using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        DataPersistence.instance.LoadScore();
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = "Best Score: " + DataPersistence.instance.highscoreUsername + ": " + DataPersistence.instance.score;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
