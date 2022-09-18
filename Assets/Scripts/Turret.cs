using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGameDev
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] public FirstPersonController _player;
        [SerializeField] private float _speedRotate;

        [SerializeField] private Transform _bulletSpawnPosition;
        [SerializeField] private GameObject _bulletPrefab;

        void Start()
        {
            _player = FindObjectOfType<FirstPersonController>();

        }

        void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 3)
            {
                var direction = _player.transform.position - transform.position;

                var stepRotate = Vector3.RotateTowards(transform.forward, direction, _speedRotate * Time.fixedDeltaTime, 5f);

                transform.rotation = Quaternion.LookRotation(stepRotate);
            }
        }
        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 3)
            {

                Fire();
            }
        }
        private void Fire()
        {
            var bulletObj = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
            var bullet = bulletObj.GetComponent<BulletTurret>();
            bullet.Init(_player.transform, 5, 1);//Transform target, float lifeTime, float speed)

        }
    }
}