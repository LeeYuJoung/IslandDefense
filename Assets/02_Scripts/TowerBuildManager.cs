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
                if(hit.collider != null)
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Block":
                            GameObject _tower = Instantiate(towerPrefab) as GameObject;
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
}
