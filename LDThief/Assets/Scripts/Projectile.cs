using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
