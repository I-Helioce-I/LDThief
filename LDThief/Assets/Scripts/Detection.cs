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
    [SerializeField] List<Detection> entities = new List<Detection>();

    [SerializeField] Detection currentTarget;

    [Header("Stats")]
    [SerializeField] float radius;


    private void Start()
    {

    }

    private void Update()
    {
        Detect();
        CheckForSound();
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

    public void CheckForSound()
    {

    }

}
