using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private PlayerInteract playerInteract;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform originTransform;
    [SerializeField] private float damageArrow;
    [SerializeField] private float closeCombnatDamages;

    [SerializeField] private float coolDown;
    [SerializeField] private float timerShoot;
    [SerializeField] Detection myDetection;

    private void Start()
    {
        myDetection = GetComponent<Detection>();
        _input = GetComponent<StarterAssetsInputs>();
        playerInteract = GetComponent<PlayerInteract>();
        timerShoot = coolDown;
    }

    private void Update()
    {
        CloseCombat();
        Shoot();

        if (timerShoot > 0)
        {

            timerShoot -= Time.deltaTime;
        }

    }

    private void CloseCombat()
    {
        if (_input.attack)
        {

            if (myDetection.entities != null && myDetection.entities.Count > 0)
            {
                Debug.Log("Attack");

                myDetection.entities[0].GetComponent<Damageable>().TakeDamage(closeCombnatDamages);
            }
            _input.attack = false;
        }
    }

    private void Shoot()
    {

        if (_input.shoot && timerShoot <= 0)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, originTransform.transform.position, originTransform.rotation);
            projectileInstance.GetComponent<Damager>().Damage = damageArrow;
            _input.shoot = false;
            timerShoot = coolDown;
        }
        else if (_input.shoot && timerShoot > 0)
        {
            _input.shoot = false;

        }
    }
}
