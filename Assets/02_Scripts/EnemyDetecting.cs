using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> enemies;
    public TowerController towerController;

    void Start()
    {
        
    }

    void Update()
    {
        if(enemies.Count < 0 && enemies[0] == null)
        {
            enemies.RemoveAt(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            towerController.targetEnemy = other.gameObject;
            towerController.towerState = TowerController.TOWERSTATE.ATTACK;
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Remove(other.gameObject);
        }
    }
}
