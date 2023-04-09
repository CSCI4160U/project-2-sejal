using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public playerMovement move;


    void OnTriggerStay(Collider col) 
    {
        if (col.tag == "Enemy" && move.isAttacking) 
        {
            Debug.Log("HIT!");
            StartCoroutine(Hit(col));
        }
    }

    IEnumerator Hit(Collider col) 
    {
        yield return new WaitForSeconds(1);
        col.GetComponent<Enemy>().TakeDamage(10);
    }
}
