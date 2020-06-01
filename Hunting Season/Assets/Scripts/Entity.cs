using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private int armour;
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    

    public float GetSpeed()
    {
        return speed;
    }
}
