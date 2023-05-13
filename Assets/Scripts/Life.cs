using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxLife;
    public int currentLife;

    private void Awake()
    {
        currentLife = maxLife;
    }

    public virtual void TakeDamage(int damage)
    {
        currentLife -= damage;
        if (currentLife <= 0) 
            Destroy(gameObject);
    }
}
