using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private PlayerInteract playerInteract;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform originTransform;

    [SerializeField] private float coolDown;
    [SerializeField] private float timerShoot;

    private void Start()
    {
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
            Debug.Log("Attack");
            _input.attack = false;
        }
    }

    private void Shoot()
    {

        if (_input.shoot && timerShoot <= 0)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, originTransform.transform.position, originTransform.rotation);
            _input.shoot = false;
            timerShoot = coolDown;
        }
        else if (_input.shoot && timerShoot > 0)
        {
            _input.shoot = false;

        }
    }
}
