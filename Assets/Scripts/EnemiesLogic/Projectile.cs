using UnityEngine;

namespace EnemiesLogic
{
    public class Projectile : MonoBehaviour
    { 
        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }
}