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
        if(target != null)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().OnDamege(bulletDamage);
            Destroy(gameObject);
        }
    }
}
