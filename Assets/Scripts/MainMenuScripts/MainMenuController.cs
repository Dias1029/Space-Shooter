using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas canvas_MainMenu;
    [SerializeField] private Canvas canvas_HighScore;

    [SerializeField] private TextMeshProUGUI meteorsDestroyedRecord;
    [SerializeField] private TextMeshProUGUI shipsDestroyedRecord;
    [SerializeField] private TextMeshProUGUI wavesSurvivesRecord;

    private void Start()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(TagManager.GAME_SCENE);
    }

    public void Quit()
    {

    }

    public void OpenOrCloseHighScoreCanvas(bool open)
    {
        canvas_MainMenu.enabled = !open;
        canvas_HighScore.enabled = open;

        if (open)
            ShowHighScore();
    }

    public void ExitGame()
    {
        Debug.Log("You quitted the game!");
        Application.Quit();
    }

    private void ShowHighScore()
    {
        shipsDestroyedRecord.text = "x" + DataManager.GetData(TagManager.ENEMY_DESTROYED);
        meteorsDestroyedRecord.text = "x" + DataManager.GetData(TagManager.METEOR_DESTROYED);
        wavesSurvivesRecord.text = "Waves Survived: " + DataManager.GetData(TagManager.WAVE_NUMBER);
    }
}
