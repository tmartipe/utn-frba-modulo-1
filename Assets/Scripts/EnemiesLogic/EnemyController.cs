using UnityEngine;
using UnityEngine.AI;

namespace EnemiesLogic
{
    public abstract class EnemyController : MonoBehaviour
    {
        protected Animator anim;
        protected NavMeshAgent nma;
        protected GameObject player;

        protected bool hasSeenPlayer;

        public LayerMask detectLayerMask;
        public float detectDistance;
        public float timeBetweenAttack = 3f;
        private float _attackTimer;
        protected virtual void Awake()
        {
            nma = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player");
            anim = GetComponentInChildren<Animator>();
            hasSeenPlayer = false;
        }

        protected virtual void Update()
        {
            if (!hasSeenPlayer)
                ScanRadius();
            HandleAnimation();
            if (hasSeenPlayer)
                nma.SetDestination(player.transform.position);
            
            if (nma.velocity == Vector3.zero && _attackTimer <= 0 && hasSeenPlayer)
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

        protected void ScanRadius()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectDistance, detectLayerMask);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    hasSeenPlayer = true;
                }
            }
        }
        
        void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectDistance);
        }
    }
}