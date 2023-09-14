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

    public Transform firePos;
    public GameObject targetEnemy;
    public GameObject bulletPrefab;

    public int attackDamage;
    public float currentTime;
    public float attackSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        switch(towerState)
        {
            case TOWERSTATE.IDLE:

                break;
            case TOWERSTATE.ATTACK:
                currentTime += Time.deltaTime;

                if(currentTime > attackSpeed)
                {
                    GameObject _bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
                    
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
