using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTowerController : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject rocketPos;
    public Transform firePos;
    public Collider[] _enemyColliders;

    public int targetIdx = 0;
    public float currentTime;
    public float attackTime = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= attackTime)
        {
            currentTime = 0;
            RocketTarget();

            if (_enemyColliders.Length != 0)
            {
                GameObject _rocket = Instantiate(rocketPrefab, firePos.position, firePos.rotation);
                _rocket.GetComponent<ArrowController>().target = _enemyColliders[targetIdx].gameObject;

                rocketPos.transform.LookAt(_enemyColliders[targetIdx].gameObject.transform.position);
            }
        }
    }

    public void RocketTarget()
    {
        _enemyColliders = Physics.OverlapSphere(transform.position, 3f, 1 << 6);
        if (_enemyColliders.Length == 0)
            return;

        float distance = Vector3.Distance(transform.position, _enemyColliders[0].transform.position);

        for (int i = 0; i < _enemyColliders.Length; i++)
        {
            if (Vector3.Distance(transform.position, _enemyColliders[i].transform.position) <= distance)
            {
                targetIdx = i;
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }
}
