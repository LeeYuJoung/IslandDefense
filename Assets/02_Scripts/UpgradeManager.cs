using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager _instance;
    public static UpgradeManager Instance()
    {
        return _instance;
    }

    public GameObject upgradeTarget;

    public void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void Update()
    {
        if(upgradeTarget != null && upgradeTarget.CompareTag("Tower"))
        {
            UIManager.Instance().SpeedLevelChange(upgradeTarget.GetComponent<TowerController>());
            UIManager.Instance().PowerLevelChange(upgradeTarget.GetComponent<TowerController>());
            UIManager.Instance().RangeLevelChange(upgradeTarget.GetComponent<TowerController>());
        }
    }

    public void PowerUP()
    {
        GameManager.Instance().coin -= GameManager.Instance().speedPrice;
        UIManager.Instance().CoinTextChange();

        upgradeTarget.GetComponent<TowerController>().powerLevel += 1;
        UIManager.Instance().PowerLevelChange(upgradeTarget.GetComponent<TowerController>());
        upgradeTarget.GetComponent<TowerController>().attackDamage += 10;
    }

    public void SpeedUP()
    {
        if (upgradeTarget.GetComponent<TowerController>().attackSpeed > 0.2f)
        {
            GameManager.Instance().coin -= GameManager.Instance().powerPrice;
            UIManager.Instance().CoinTextChange();

            upgradeTarget.GetComponent<TowerController>().speedLevel += 1;
            UIManager.Instance().SpeedLevelChange(upgradeTarget.GetComponent<TowerController>());
            upgradeTarget.GetComponent<TowerController>().attackSpeed -= 0.1f;
        }
    }

    public void RangeUP()
    {
        if(upgradeTarget.transform.GetChild(1).transform.localScale.x < 10)
        {
            GameManager.Instance().coin -= GameManager.Instance().rangePrice;
            UIManager.Instance().CoinTextChange();

            upgradeTarget.GetComponent<TowerController>().rangeLevel += 1;
            UIManager.Instance().RangeLevelChange(upgradeTarget.GetComponent<TowerController>());
            upgradeTarget.transform.GetChild(1).transform.localScale += new Vector3(1, 0, 1);
        }
    }

    public void SaleButton()
    {
        Destroy(upgradeTarget);
    }

    public void RocketSaleButton()
    {
        Destroy(upgradeTarget);
    }
}
