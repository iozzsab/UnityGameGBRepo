using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGameDev
{
    public class Turret : MonoBehaviour
    {
       [SerializeField] public FirstPersonController _player;
         [SerializeField] private float _speedRotate;
       [SerializeField] private float speed = 3f;

         [SerializeField] private Transform _bulletSpawnPosition;
         [SerializeField] private GameObject _bulletPrefab;

        private bool canFire = true;


         void Start()
         {
             _player = FindObjectOfType<FirstPersonController>(); 
         }



         void FixedUpdate()
         {   
            
            
             if (Vector3.Distance(_bulletSpawnPosition.transform.position, _player.transform.position) < 5)
             {
                 var direction = _player.transform.position - transform.position;

                 var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 5f);

                 transform.rotation = Quaternion.LookRotation(stepRotate);

             }

            if (Vector3.Distance(_bulletSpawnPosition.transform.position, _player.transform.position) < 5 && canFire)
            {
                Fire();
                canFire = false;
                StartCoroutine(WaiterForShoot());
            }


        }

         private void Fire()
         {
            GameObject bul = (GameObject)Instantiate(_bulletPrefab, _bulletSpawnPosition.position, Quaternion.identity);
            bul.gameObject.GetComponent<Rigidbody>().velocity = _bulletSpawnPosition.transform.forward * speed;
            
         }
        IEnumerator WaiterForShoot()
        {
            yield return new WaitForSeconds(0.5f);
            canFire = true;
            
        }

       
    }
}

   