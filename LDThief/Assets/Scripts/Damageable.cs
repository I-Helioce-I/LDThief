using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
