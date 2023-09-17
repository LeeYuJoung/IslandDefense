using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject target;
    public float speed = 10.0f;

    void Update()
    {
        StartCoroutine(Crash());
    }

    IEnumerator Crash()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return new WaitForSeconds(0.15f);
            target.GetComponent<EnemyController>().OnDamege(target.GetComponent<EnemyController>().maxHP);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
