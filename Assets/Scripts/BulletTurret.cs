using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace StartGameDev
{
    public class BulletTurret : MonoBehaviour
    {
        void FixedUpdate()
        {
            
            StartCoroutine(WaiterForDestroy());
        }
        IEnumerator WaiterForDestroy()
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHeal>().RecountHP(-5);
                Destroy(gameObject);

            }

                
        }
    }

}