using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTowerController : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject rocketPos;
    public Transform firePos;

    public Collider[] _enemyColliders;
    public AudioClip explosionSound;

    public Slider coolTimeSlider;

    public int targetIdx = 0;
    public float currentTime;
    public float attackTime = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        RocketTarget();

        coolTimeSlider.value = (float)currentTime / attackTime;
        currentTime += Time.deltaTime;

        if(currentTime >= attackTime)
        {
            if (_enemyColliders.Length != 0)
            {
                currentTime = 0;

                GameObject.Find("BackgroundSound").GetComponent<AudioSource>().PlayOneShot(explosionSound);
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
