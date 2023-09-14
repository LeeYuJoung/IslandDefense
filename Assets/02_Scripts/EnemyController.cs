using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CharacterController characterController;
    public List<Transform> targetPos;
    public Transform currentTargetPos;

    public float speed = 1.0f;
    public float rotateSpeed = 10.0f;
    public int enemyHP = 100;

    private bool isDead = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        for(int i = 1; i < 12; i++)
        {
            targetPos.Add(GameObject.Find("EnemyNode_" + i).transform);
        }
    }

    void Update()
    {
        currentTargetPos = targetPos[0];

        float distance = Vector3.Distance(transform.position, currentTargetPos.position);

        Vector3 dir = currentTargetPos.position - transform.position;
        dir.y = 0;
        dir.Normalize();
        characterController.Move(dir * speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);

        if(distance < 0.3f)
        {
            targetPos.RemoveAt(0);
        }
    }

    public void OnDamege(int damage)
    {
        if (!isDead)
        {
            enemyHP -= damage;

            if(enemyHP <= 0)
            {
                isDead = true;
                // Dead Effect
                // Dead Sound 
                // Coin UP
                Destroy(gameObject);
            }
        }
    }
}
