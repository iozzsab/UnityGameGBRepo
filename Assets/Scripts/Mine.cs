using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float force = 15;
   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "LowEnemy")
        {
            Vector3 dirrection = collision.gameObject.transform.position - gameObject.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dirrection.normalized * force, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}

