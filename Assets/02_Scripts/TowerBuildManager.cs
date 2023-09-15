using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public Canvas canvas;
    public GameObject upgradePanel;

    public float mousePushTime;

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
                            //if(mousePushTime > 2.0f)
                            //{
                            //    mousePushTime = 0;

                            //    upgradePanel = hit.transform.GetChild(0).GetChild(0).gameObject;
                            //    upgradePanel.SetActive(true);
                            //}

                            canvas = hit.collider.gameObject.GetComponentInChildren<Canvas>();
                            upgradePanel = canvas.transform.GetChild(0).gameObject;
                            upgradePanel.SetActive(true);

                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
