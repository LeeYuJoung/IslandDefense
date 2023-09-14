using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaker : MonoBehaviour
{
    public GameObject shipPrefab;

    public void Start()
    {
        SpawnShip();
    }

    public void SpawnShip()
    {
        GameObject _ship = Instantiate(shipPrefab, transform.position, transform.rotation);
        _ship.name = "Ship";
    }
}
