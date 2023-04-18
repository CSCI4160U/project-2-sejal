using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponDamage : MonoBehaviour
{
    [SerializeField] public int damage = 5;

    private bool canAttack = false;
    private void OnTriggerEnter(Collider other) 
    {
        playerHealth PlayerHealth = other.GetComponent<playerHealth>();

        if (PlayerHealth != null && canAttack) 
        {
            PlayerHealth.TakeDmg(damage);
            StartCoroutine(ResetAttackCoolDown(3f));
        }
        
    }

    IEnumerator ResetAttackCoolDown(float CoolDown)
    {
        yield return new WaitForSeconds(CoolDown);
        canAttack = true;
    }
}
