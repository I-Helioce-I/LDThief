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
    [SerializeField] private Entity entity = Entity.Enemy;

    private void Start()
    {
        
    }


}
