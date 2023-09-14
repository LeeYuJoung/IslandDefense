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
    public TOWERSTATE towerState = TOWERSTATE.NONE;



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
