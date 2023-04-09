using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 100f;

    public bool isAttacked = false;


    public void TakeDamage(float dmg) 
    {
        if (!isAttacked)
        {
            health -= dmg;
            isAttacked= true;   
            StartCoroutine(ResetIsAttacked());

        }
        
    }
    IEnumerator ResetIsAttacked()
    {
        yield return new WaitForSeconds(1.5f);
        isAttacked = false;
    }
}
