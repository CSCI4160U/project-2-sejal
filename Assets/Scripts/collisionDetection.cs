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
            col.GetComponent<Enemy>().TakeDamage(10);
        }
    }
}
