using System;
using UnityEngine;

namespace EnemiesLogic
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody _rb;


        private void Awake()
        {
            _rb = GetComponentInChildren<Rigidbody>();
        }

        private void Update()
        {
            _rb.velocity = Vector3.right * 10;
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }
}