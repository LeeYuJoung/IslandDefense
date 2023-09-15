using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject target;
    public float speed = 10.0f;
    public int bulletDamage;

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
            target.GetComponent<EnemyController>().OnDamege(bulletDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
