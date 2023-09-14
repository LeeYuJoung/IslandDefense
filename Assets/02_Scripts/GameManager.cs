using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;
    public GameManager Instance()
    {
        return _instance;
    }

    public int currentHP = 100;
    public int maxHP = 100;
    public int coin = 0;

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
}
