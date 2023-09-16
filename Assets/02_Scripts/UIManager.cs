using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance()
    {
        return _instance;
    }

    public GameObject gameOverPanel;
    public GameObject levelUpPanel;
    public GameObject optionPanel;

    public Slider playerHP;
    public Text cointText;
    public Text levelText;

    public Text speedLevel;
    public Text powerLevel;
    public Text rangeLevel;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PlayerHPBar()
    {
        playerHP.value = (float)GameManager.Instance().currentHP / GameManager.Instance().maxHP;

        if(GameManager.Instance().currentHP <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CoinTextChange()
    {
        cointText.text = string.Format("{0:0000}", GameManager.Instance().coin);
    }

    public void LevelUp()
    {
        levelUpPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTextChange()
    {
        levelText.text = string.Format("LV.{0:00}", GameManager.Instance().level);
    }

    public void OptionPanelOpen()
    {
        if (optionPanel.activeSelf)
        {
            optionPanel.SetActive(false);
        }
        else
        {
            optionPanel.SetActive(true);
        }
    }

    public void SpeedLevelChange(TowerController _target)
    {
        speedLevel.text = string.Format("LV.{0:00}", _target.speedLevel);
    }

    public void PowerLevelChange(TowerController _target)
    {
        powerLevel.text = string.Format("LV.{0:00}", _target.powerLevel);
    }

    public void RangeLevelChange(TowerController _target)
    {
        rangeLevel.text = string.Format("LV.{0:00}", _target.rangeLevel);
    }
}
