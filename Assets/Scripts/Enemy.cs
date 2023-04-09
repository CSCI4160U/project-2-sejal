using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 100f;


    public void TakeDamage(float dmg) 
    { 
        health-= dmg;   
    }
}
