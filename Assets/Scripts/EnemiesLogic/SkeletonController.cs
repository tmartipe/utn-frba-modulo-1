using UnityEngine;
using UnityEngine.AI;

namespace EnemiesLogic
{
    public class SkeletonController : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform shootingPoint;
        private NavMeshAgent _nma;
        private GameObject _player;

        private Animator _anim;

        public float timeBetweenShots = 3f;
        private float _shotTimer;
        private void Awake()
        {
            _nma = GetComponent<NavMeshAgent>();
            _player = GameObject.Find("Player");
            _shotTimer = timeBetweenShots;
            _anim = GetComponentInChildren<Animator>();
        }

        void ShootArrow()
        {
            GameObject arrow = Instantiate(arrowPrefab, shootingPoint.position, transform.rotation);
            Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
            _anim.SetTrigger("Shoot");
            arrowRb.AddForce(shootingPoint.forward * 5f, ForceMode.Impulse);
        }

        private void Update()
        {
            HandleAnimation();
            _nma.SetDestination(_player.transform.position);
            if (_nma.velocity == Vector3.zero && _shotTimer <= 0)
            {
                ShootArrow();
                _shotTimer = timeBetweenShots;
            }
            else
            {
                _shotTimer -= Time.deltaTime;
            }
        }

        void HandleAnimation()
        {
            _anim.SetFloat("Velocity", _nma.velocity.magnitude);
        }
    }
}
