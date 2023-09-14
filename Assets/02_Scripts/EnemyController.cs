using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public CharacterController characterController;
    public NavMeshAgent agent;
    public Animator animator;
    public Transform _base;

    public List<Transform> targetPos;
    public Transform currentTargetPos;

    public Transform[] attackPos = new Transform[8];
    public Transform currentAttackPos;

    public float speed = 1.0f;
    public float rotateSpeed = 10.0f;
    public int enemyHP = 100;

    private bool isDead = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        _base = GameObject.Find("Base").GetComponent<Transform>();

        for (int i = 1; i < 12; i++)
        {
            targetPos.Add(GameObject.Find("EnemyNode_" + i).transform);
        }

        for(int i = 0; i < 8; i++)
        {
            attackPos[i] = GameObject.Find("AttackPosition_" + i).transform;
        }
        currentAttackPos = attackPos[Random.Range(0, attackPos.Length)];
    }

    void Update()
    {
        if (targetPos.Count == 0)
        {
            OnAttack();
            return;
        }

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
                animator.SetTrigger("DIE");
                // Dead Effect
                // Dead Sound 
                // Coin UP
                Destroy(gameObject);
            }
        }
    }

    public void OnAttack()
    {
        agent.enabled = true;
        agent.speed = this.speed;
        agent.SetDestination(currentAttackPos.position);

        animator.SetBool("ATTACK", true);

        transform.LookAt(_base.position);
        Vector3 dir = transform.localRotation.eulerAngles;
        dir.x = 0;
        transform.localRotation = Quaternion.Euler(dir);
    }
}