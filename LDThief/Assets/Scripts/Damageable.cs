using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            Die();
        }
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

    }
}
