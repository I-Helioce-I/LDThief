using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage = 0f;


    public float Damage {  get { return damage; } set { damage = value; } }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damageable>(out Damageable damageable))
        {
            Debug.Log("TouchEnemy");
            damageable.TakeDamage(damage);
        }
    }

}
