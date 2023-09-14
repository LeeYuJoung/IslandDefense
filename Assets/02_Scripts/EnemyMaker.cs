using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float currentTime;
    public float spawnCoolTime = 2.0f;
    public int enemyCount = 0;
    public int enemyMaxCount = 3;

    public bool isRunning = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (enemyCount >= enemyMaxCount)
            isRunning = false;

        if (isRunning)
        {
            currentTime += Time.deltaTime;

            if(currentTime > spawnCoolTime)
            {
                currentTime = 0;
                GameObject _enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                _enemy.name = "Enemy_" + enemyCount;
                _enemy.GetComponent<EnemyController>().enemyHP = GameManager.Instance().enemyHP;
                _enemy.GetComponent<EnemyController>().speed = GameManager.Instance().enemySpeed;
                enemyMaxCount = GameManager.Instance().enemyMaxCount;
                enemyCount++;
            }
        }
    }

    // 다음 레벨 Enemy 생성 초기화
    public void InitEnemyMaker()
    {
        enemyCount = 0;
        isRunning = true;
        GameManager.Instance().level += 1;
        GameManager.Instance().StageLevelUP();
    }
}
