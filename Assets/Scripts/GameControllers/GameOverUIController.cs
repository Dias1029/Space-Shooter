using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController Instance;

    [SerializeField] private Canvas playerCanvas, enemyCanvas, gameOverCanvas;
    [SerializeField] private TextMeshProUGUI enemyDestroyedInfo, meteorDestroyedInfo, waveInfo;
    [SerializeField] private TextMeshProUGUI enemyDestroyedHighScore, meteorDestroyedHighScore, waveHighScore;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public void GameOverCanvasOpen()
    {
        playerCanvas.enabled = false;
        enemyCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        int enemyDestroyed = GamePlayUI.Instance.GetEnemyDestroyedCount();
        int meteorDestroyed = GamePlayUI.Instance.GetMeteorsDestroyedCount();
        int waveCount = GamePlayUI.Instance.GetWaveCount();

        waveCount--;

        enemyDestroyedInfo.text = "x" + enemyDestroyed;
        meteorDestroyedInfo.text = "x" + meteorDestroyed;
        waveInfo.text = "Wave: " + waveCount;

        // calculate highscore;
        UpdateRecord(enemyDestroyed, meteorDestroyed, waveCount);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.GAME_SCENE);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE);
    }

    void UpdateRecord(int enemyDestroyed_Current, int meteorDestroyed_Current, int waveSurvived_Current)
    {
        int enemyDestroyedRecord = DataManager.GetData(TagManager.ENEMY_DESTROYED);
        int meteorDestroyedRecord = DataManager.GetData(TagManager.METEOR_DESTROYED);
        int waveSurvivedRecord = DataManager.GetData(TagManager.WAVE_NUMBER);

        if (enemyDestroyed_Current > enemyDestroyedRecord)
        {
            DataManager.SaveData(TagManager.ENEMY_DESTROYED, enemyDestroyed_Current);
        }

        if (meteorDestroyed_Current > meteorDestroyedRecord)
        {
            DataManager.SaveData(TagManager.METEOR_DESTROYED, meteorDestroyed_Current);
        }

        if (waveSurvived_Current > waveSurvivedRecord)
        {
            DataManager.SaveData(TagManager.WAVE_NUMBER, waveSurvived_Current);
        }

        enemyDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.ENEMY_DESTROYED);
        meteorDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.METEOR_DESTROYED);
        waveHighScore.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER);
    }
}
