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

        public float timeBetweenShots = 1f;
        private float _shotTimer;
        private void Awake()
        {
            _nma = GetComponent<NavMeshAgent>();
            _player = GameObject.Find("Player");
            _shotTimer = timeBetweenShots;
        }

        void ShootArrow()
        {
            Quaternion shootingAngle = Quaternion.Euler(_player.transform.position - shootingPoint.position);
            Instantiate(arrowPrefab, shootingPoint.position, Quaternion.Euler(new Vector3(shootingAngle.x, 0, -90)));
        }

        private void Update()
        {
            _nma.SetDestination(_player.transform.position);

            if (!_nma.pathPending && _shotTimer <= 0)
            {
                ShootArrow();
                _shotTimer = timeBetweenShots;
            }
            else
            {
                _shotTimer -= Time.deltaTime;
            }
        }
    }
}
