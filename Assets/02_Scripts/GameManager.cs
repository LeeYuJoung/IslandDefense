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

    public int level = 1;

    public int currentHP = 100;
    public int maxHP = 100;
    public int coin = 0;

    public int enemyHP = 100;
    public float enemySpeed = 1;
    public int enemyPower = 5;
    public int enemyMaxCount = 2;
    public int killCount = 0;

    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    void Update()
    {
        
    }

    public void StageLevelUP()
    {
        enemyHP *= 2;
        enemySpeed *= 1.1f;
        enemyPower += 5;
        enemyMaxCount *= 2;
        killCount = 0;
    }
}
