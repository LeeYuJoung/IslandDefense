using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public enum TOWERSTATE
    {
        IDLE = 0,
        ATTACK,
        UPGRADE,
        NONE
    }
    public TOWERSTATE towerState = TOWERSTATE.IDLE;

    public EnemyDetecting enemyDetecting;
    public Transform firePos;
    public GameObject muzzlePos;
    public GameObject targetEnemy;
    public GameObject bulletPrefab;

    public int attackDamage = 10;
    public float currentTime;
    public float attackSpeed = 3.0f;

    void Start()
    {
        enemyDetecting = GetComponentInChildren<EnemyDetecting>();
    }

    void Update()
    {
        switch(towerState)
        {
            case TOWERSTATE.IDLE:
                if(enemyDetecting.enemies.Count > 0 && targetEnemy != null)
                {
                    targetEnemy = enemyDetecting.enemies[0];
                    towerState = TOWERSTATE.ATTACK;
                }

                break;
            case TOWERSTATE.ATTACK:
                if(targetEnemy != null)
                {
                    muzzlePos.transform.LookAt(targetEnemy.transform.position);
                    currentTime += Time.deltaTime;

                    if (currentTime > attackSpeed)
                    {
                        currentTime = 0;

                        GameObject _bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
                        _bullet.GetComponent<BulletController>().target = targetEnemy;
                        _bullet.GetComponent<BulletController>().bulletDamage = attackDamage;
                    }
                }
                else
                {
                    currentTime = 0;
                    towerState = TOWERSTATE.IDLE;
                }

                break;
            case TOWERSTATE.UPGRADE: 

                break;
            case TOWERSTATE.NONE:

                break;
            default:
                break;
        }
    }
}
