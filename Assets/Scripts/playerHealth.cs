using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] float maxHP = 100f;
    [SerializeField] float currentHealth = 100f;
    [SerializeField] bool isDead = false;

    public void TakeDmg(float dmg) 
    { 
        currentHealth -= dmg;

        if (currentHealth <= 0) 
        { 
            isDead = true;
        }
    }

    void Update() 
    {
        if (isDead) 
        {
            Debug.Log("PlayerDied!");
        }
    }
}
