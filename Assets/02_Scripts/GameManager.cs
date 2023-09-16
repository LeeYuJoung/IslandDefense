using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance()
    {
        return _instance;
    }

    public GameObject speedActivePanel;
    public GameObject powerActivePanel;
    public GameObject rangeActivePanel;

    public int level = 1;

    public int currentHP = 100;
    public int maxHP = 100;
    public int coin = 100;

    public int enemyHP = 100;
    public float enemySpeed = 1;
    public int enemyPower = 5;
    public int enemyMaxCount = 2;
    public int killCount = 0;

    public int speedPrice = 50;
    public int powerPrice = 50;
    public int rangePrice = 100;

    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    void Update()
    {
        SpeedLevelUP();
        PowerLevelUP();
        RangeLevelUP();
    }

    public void StageLevelUP()
    {
        enemyHP *= 2;
        enemySpeed *= 1.1f;
        enemyPower += 5;
        enemyMaxCount *= 2;
        killCount = 0;
    }

    public void SpeedLevelUP()
    {
        if(coin >= speedPrice)
        {
            speedActivePanel.SetActive(false);
        }
        else
        {
            speedActivePanel.SetActive(true);
        }
    }

    public void PowerLevelUP()
    {
        if(coin >= powerPrice)
        {
            powerActivePanel.SetActive(false);
        }
        else
        {
            powerActivePanel.SetActive(true);
        }
    }

    public void RangeLevelUP()
    {
        if(coin >= rangePrice)
        {
            rangeActivePanel.SetActive(false);
        }
        else
        {
            rangeActivePanel.SetActive(true);
        }
    }
}
