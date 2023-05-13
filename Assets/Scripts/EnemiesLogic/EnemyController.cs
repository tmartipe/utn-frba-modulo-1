using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace EnemiesLogic
{
    public abstract class EnemyController : MonoBehaviour
    {
        protected Animator anim;
        protected NavMeshAgent nma;
        protected GameObject player;
        
        public float timeBetweenAttack = 3f;
        private float _attackTimer;
        protected virtual void Awake()
        {
            nma = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player");
            anim = GetComponentInChildren<Animator>();
        }

        protected virtual void Update()
        {
            HandleAnimation();
            nma.SetDestination(player.transform.position);
            if (nma.velocity == Vector3.zero && _attackTimer <= 0)
            {
                Attack();
                _attackTimer = timeBetweenAttack;
            }
            else
            {
                _attackTimer -= Time.deltaTime;
            }
            transform.LookAt(player.transform);
        }
        
        protected void HandleAnimation()
        {
            anim.SetFloat("Velocity", nma.velocity.magnitude);
        }

        protected abstract void Attack();
    }
}