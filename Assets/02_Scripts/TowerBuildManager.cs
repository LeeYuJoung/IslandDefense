using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public GameObject towerPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Block":
                        GameObject _tower = Instantiate(towerPrefab);
                        _tower.transform.position = hit.collider.transform.position;
                        break;
                    case "Tower":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
