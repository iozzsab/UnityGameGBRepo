using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHeal>().RecountHP(-20);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 50f, ForceMode.Impulse);
        }
    }
}


    

