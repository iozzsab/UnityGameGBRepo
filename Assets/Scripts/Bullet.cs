using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 15;
    void Update()
    {
        StartCoroutine(WaiterForDestroy());
    }
    IEnumerator WaiterForDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().RecountHP(-damage);
            print("ouch");
            Destroy(gameObject);

        }
        if (collision.collider.tag == "EnemyTurret")
        {
            collision.gameObject.GetComponent<TurretHealth>().RecountHP(-damage);
            print("ouch");
            Destroy(gameObject);

        }
    }
}
