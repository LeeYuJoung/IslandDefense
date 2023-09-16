using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public EnemyMaker enemyMaker;
    public Transform targetPos;
    public float speed = 1.5f;
    public float rotationSpeed = 10.0f;

    void Start()
    {
        enemyMaker = GameObject.Find("EnemyMaker").GetComponent<EnemyMaker>();
        targetPos = GameObject.Find("EnemyMaker").GetComponent<Transform>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetPos.position);

        Vector3 dir = targetPos.position - transform.position;
        dir.y = 0;
        dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(enemyMaker != null && other.CompareTag("EnemyMaker"))
        {
            enemyMaker.isRunning = true;
            speed = 0;
        }
    }
}
