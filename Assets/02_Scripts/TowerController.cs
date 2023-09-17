using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public AudioClip explosionSound;

    public Slider coolTimeSlider;

    public int attackDamage = 10;
    public float currentTime;
    public float attackSpeed = 1.5f;

    public int speedLevel = 1;
    public int powerLevel = 1;
    public int rangeLevel = 1;

    void Start()
    {
        towerState = TOWERSTATE.IDLE;
        enemyDetecting = GetComponentInChildren<EnemyDetecting>();
    }

    void Update()
    {
        switch (towerState)
        {
            case TOWERSTATE.IDLE:
                coolTimeSlider.value = (float)currentTime / attackSpeed;
                currentTime += Time.deltaTime;

                if (enemyDetecting.enemies.Count > 0 && targetEnemy != null)
                {
                    targetEnemy = enemyDetecting.enemies[0];
                    towerState = TOWERSTATE.ATTACK;
                }

                break;
            case TOWERSTATE.ATTACK:
                if(targetEnemy != null)
                {
                    muzzlePos.transform.LookAt(targetEnemy.transform.position);
                    coolTimeSlider.value = (float)currentTime / attackSpeed;
                    currentTime += Time.deltaTime;

                    if (currentTime > attackSpeed)
                    {
                        currentTime = 0;

                        GameObject.Find("BackgroundSound").GetComponent<AudioSource>().PlayOneShot(explosionSound);
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
