using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Entity
{
    Player,
    Enemy
}
public class Detection : MonoBehaviour
{
    [SerializeField] Entity currentEntity = Entity.Enemy;
    [SerializeField] public List<Detection> entities = new List<Detection>();

    [SerializeField] GameObject currentTarget;

    [Header("Stats")]
    [SerializeField] float radius;


    private void Start()
    {

    }

    private void Update()
    {
        Detect();
        CheckForSound();
        if(currentTarget != null)
        {
            transform.LookAt(currentTarget.transform.position);
        }
    }


    public void Detect()
    {
        entities.Clear();

        Collider[] _collidersArray = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in _collidersArray)
        {
            if (collider.TryGetComponent(out Detection detection))
            {
                if (detection.currentEntity != currentEntity)
                {
                    entities.Add(detection);
                }

            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            currentTarget = other.gameObject;
            GetComponent<EnemyMovementController>().isMoving = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentTarget = null;
            GetComponent<EnemyMovementController>().isMoving = true;

        }
    }

    public void CheckForSound()
    {

    }

}
