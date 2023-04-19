using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    [SerializeField] public GameObject gameOver;
    [SerializeField] public GameObject DeathScreen;
    public playerMovement move;
    public float attackTime;

    void OnTriggerStay(Collider col) 
    {
        if (col.tag == "Enemy" && move.isAttacking)
        {
            col.GetComponent<Enemy>().TakeDamage(move.attackDmg, move.attackTime);
        }
        if (col.tag == "Boss" && move.isAttacking)
        {
            //Debug.Log("Hit Boss");
            col.GetComponent<Boss>().TakeDamage(move.attackDmg, move.attackTime);
        }
        if (col.tag == "FinalBoss" && move.isAttacking)
        {
            //Debug.Log("Hit Boss");
            col.GetComponent<finalBoss>().TakeDamage(move.attackDmg, move.attackTime);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "GameOver")
        {
            Debug.Log("GameOver");
            gameOver.SetActive(true);
        }
        if (col.tag == "Water")
        {
            DeathScreen.SetActive(true);
        }
    }
}
