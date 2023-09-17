using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public ShipMaker shipMaker;
    public GameObject enemyPrefab;
    public GameObject ship;

    public float currentTime;
    public float spawnCoolTime = 2.0f;
    public int enemyCount = 0;
    public int enemyMaxCount = 3;

    public bool isRunning = false;

    void Start()
    {
        shipMaker = GameObject.Find("ShipMaker").GetComponent<ShipMaker>();
    }


    void Update()
    {
        if (enemyCount >= enemyMaxCount)
        {
            ship = GameObject.Find("Ship");
            isRunning = false;
            Destroy(ship, 0.5f);
        }

        if (isRunning)
        {
            currentTime += Time.deltaTime;

            if(currentTime > spawnCoolTime)
            {
                currentTime = 0;
                GameObject _enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                _enemy.name = "Enemy_" + enemyCount;
                _enemy.GetComponent<EnemyController>().enemyHP = GameManager.Instance().enemyHP;
                _enemy.GetComponent<EnemyController>().maxHP = GameManager.Instance().enemyHP;
                _enemy.GetComponent<EnemyController>().speed = GameManager.Instance().enemySpeed;
                _enemy.GetComponent<EnemyController>().power = GameManager.Instance().enemyPower; 
                enemyCount++;
            }
        }
    }

    // 다음 레벨 Enemy 생성 초기화
    public void InitEnemyMaker()
    {
        enemyCount = 0;
        GameManager.Instance().level += 1;
        UIManager.Instance().LevelTextChange();
        GameManager.Instance().StageLevelUP();
        enemyMaxCount = GameManager.Instance().enemyMaxCount;
        shipMaker.SpawnShip();
    }
}
