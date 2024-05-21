using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Instance;

    [SerializeField] private TextMeshProUGUI waveText, enemyDestroyed, meteorsDestroyed;
    [SerializeField] private Button[] weaponButtons;

    private int waveCount, enemyDestroyed_Count, meteorsDestroyed_Count;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        for (int i = 1; i < weaponButtons.Length; i++)
        {
            GrayButtonVisual(i);
        }
    }

    public void UpdateInfo(int infoType)
    {
        switch(infoType)
        {
            case 0:
                waveCount++;
                waveText.text = "Wave: " + waveCount;
                break;
            case 1:
                enemyDestroyed_Count++;
                enemyDestroyed.text = enemyDestroyed_Count + "x";
                break;
            case 2:
                meteorsDestroyed_Count++;
                meteorsDestroyed.text = meteorsDestroyed_Count + "x";
                break; 
        }
    }

    public void GrayButtonVisual(int weaponButtonIndex)
    {
        ColorBlock color = weaponButtons[weaponButtonIndex].colors;
        color.normalColor = Color.gray;
        weaponButtons[weaponButtonIndex].colors = color;
    }

    public void ActivateButtonVisual(int activatedWeaponIndex)
    {
        ColorBlock color = weaponButtons[activatedWeaponIndex].colors;
        color.normalColor = Color.white;
        weaponButtons[activatedWeaponIndex].colors = color;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public int GetEnemyDestroyedCount()
    {
        return enemyDestroyed_Count;
    }

    public int GetMeteorsDestroyedCount()
    {
        return meteorsDestroyed_Count;
    }
}
