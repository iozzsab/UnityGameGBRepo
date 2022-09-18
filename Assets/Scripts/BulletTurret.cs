using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartGameDev
{
    public class BulletTurret : MonoBehaviour
    {
        private Transform _target;
        private float _speed;

        public void Init(Transform target, float lifeTime, float speed)
        {
            _target = target;
            _speed = speed;
            Destroy(gameObject, lifeTime);
        }
        void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
            //transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }
    }

}