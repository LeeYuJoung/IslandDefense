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

    public GameObject towerBuyPanel;
    public GameObject towerLevelUpPaenl;

    public Slider playerHP;
    public Text cointText;
    public Text levelText;

    public Text speedLevel;
    public Text powerLevel;
    public Text rangeLevel;

    public GameObject soundButton;
    public Sprite soundOff;
    public Sprite soundOn;

    public GameObject stopButton;
    public Sprite stopOn;
    public Sprite stopOff;

    public GameObject optionButton;
    public Sprite optionOn;
    public Sprite optionOff;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
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
            towerBuyPanel.SetActive(false);
            towerLevelUpPaenl.SetActive(false);

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
        towerBuyPanel.SetActive(false);
        towerLevelUpPaenl.SetActive(false);

        levelUpPanel.SetActive(true);
    }

    public void LevelTextChange()
    {
        levelText.text = string.Format("LV.{0:00}", GameManager.Instance().level);
    }

    public void OptionPanelOpen()
    {
        if (optionPanel.activeSelf)
        {
            optionButton.GetComponent<Button>().image.sprite = optionOff;
            optionPanel.SetActive(false);
        }
        else
        {
            optionButton.GetComponent<Button>().image.sprite = optionOn;
            optionPanel.SetActive(true);
        }
    }

    public void SoundOnOff()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            soundButton.GetComponent<Button>().image.sprite = soundOn;
        }
        else
        {
            AudioListener.volume = 0;
            soundButton.GetComponent<Button>().image.sprite = soundOff;
        }
    }

    public void StopOnOff()
    {
        if(Time.timeScale == 1 || Time.timeScale == 2)
        {
            stopButton.GetComponent<Button>().image.sprite = stopOn;
            Time.timeScale = 0;
            return;
        }
        else
        {
            stopButton.GetComponent<Button>().image.sprite = stopOff;
            Time.timeScale = 1;
            return;
        }
    }

    public void DoubleSpeed()
    {
        if(Time.timeScale != 0)
            Time.timeScale = 2;
    }

    public void SlowSpeed()
    {
        if(Time.timeScale != 0)
            Time.timeScale = 1;
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
