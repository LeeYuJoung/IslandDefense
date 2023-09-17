using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject arrowTowerPrefab;

    public GameObject towerBuyPanel;
    public GameObject rocketSalePanel;
    public GameObject upgradePanel;

    public RaycastHit hit;
    public RaycastHit blockHit;

    public float mousePushTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Block":
                            blockHit = hit;
                            if (!towerBuyPanel.activeSelf)
                            {
                                towerBuyPanel.SetActive(true);
                            }
                            else
                            {
                                towerBuyPanel.SetActive(false);
                            }

                            break;
                        case "Tower":
                            UpgradeManager.Instance().upgradeTarget = hit.collider.gameObject;

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
                        case "ArrowTower":
                            UpgradeManager.Instance().upgradeTarget = hit.collider.gameObject;

                            if (rocketSalePanel.activeSelf)
                            {
                                rocketSalePanel.SetActive(false);
                                hit.transform.Find("AttackRange").GetComponent<MeshRenderer>().enabled = false;
                            }
                            else
                            {
                                rocketSalePanel.SetActive(true);
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

    public void TowerCreate()
    {
        GameManager.Instance().coin -= GameManager.Instance().towerPrice;
        UIManager.Instance().CoinTextChange();

        GameObject _tower = Instantiate(towerPrefab) as GameObject;
        _tower.transform.position = blockHit.collider.transform.position;
    }

    public void ArrowTowerCreate()
    {
        GameManager.Instance().coin -= GameManager.Instance().arrowTowerPrice;
        UIManager.Instance().CoinTextChange();

        GameObject _arrowTower = Instantiate(arrowTowerPrefab) as GameObject;
        _arrowTower.transform.position = blockHit.collider.transform.position + new Vector3(0, 0.25f, 0);
    }
}
