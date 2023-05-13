using UnityEngine;

namespace EnemiesLogic
{
    public class SkeletonController : EnemyController
    {
        public GameObject arrowPrefab;
        public Transform shootingPoint;

        protected override void Attack()
        {
            GameObject arrow = Instantiate(arrowPrefab, shootingPoint.position, transform.rotation);
            Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
            anim.SetTrigger("Shoot");
            arrowRb.AddForce(shootingPoint.forward * 5f, ForceMode.Impulse);
        }
    }
}
