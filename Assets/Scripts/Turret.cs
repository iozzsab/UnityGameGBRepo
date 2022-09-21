using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGameDev
{
    public class Turret : MonoBehaviour
    {
       /* [SerializeField] public FirstPersonController _player;
         [SerializeField] private float _speedRotate;
        [SerializeField] private float speed = 3f;

         [SerializeField] private Transform _bulletSpawnPosition;
         [SerializeField] private GameObject _bulletPrefab;

        private bool canFire;


         void Start()
         {
             _player = FindObjectOfType<FirstPersonController>(); 
         }



         void FixedUpdate()
         {   
            StartCoroutine(Waiter());
             if (Vector3.Distance(_bulletSpawnPosition.transform.position, _player.transform.position) < 5)
             {
                 var direction = _player.transform.position - transform.position;

                 var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 5f);

                 transform.rotation = Quaternion.LookRotation(stepRotate);
                 Fire(); 

                 
             }
         }

         private void Fire()
         {

            if (canFire)
            {
                var bulletObj = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
                bulletObj.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;
            }
             //Transform target, float lifeTime, float speed)

         }

         IEnumerator  Waiter()
         {
             yield return new WaitForSeconds(1f);
             canFire = true;
            yield return new WaitForSeconds(1f);
            canFire = false;
           /*  /**/
    }
}

   