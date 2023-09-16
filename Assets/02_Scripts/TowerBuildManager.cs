using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public GameObject towerPrefab;
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
                            Debug.Log(upgradePanel.activeSelf);

                            if (upgradePanel.activeSelf)
                            {
                                upgradePanel.SetActive(false);
                                hit.transform.Find("AttackRange").GetComponent<MeshRenderer>().enabled = false;
                            }
                            else
                            {
                                upgradePanel.SetActive(true);
                                hit.transform.Find("AttackRange").GetComponent<MeshRenderer>().enabled = true;
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
