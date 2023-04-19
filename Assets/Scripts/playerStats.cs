using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class playerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth;
    [SerializeField] bool isDead = false;
    public float attackDmg = 10;
    public int questNum;
    public int dialogueNum;
    public List<string> enemiesKilled = new List<string>();

    void Start() 
    {
        currentHealth = maxHealth;
    }
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

   public bool checkQ1()
    {
        List<string> q1Enemies = new List<string> { "Wolf", "Wolf2", "Wolf3", "Wolf4", "Wolf5", "Wolf6", "Wolf7" };

        bool allKilled = q1Enemies.All(enemiesKilled.Contains);
        return allKilled;
    }
    public bool checkQ2() 
    {
        List<string> q2Enemies = new List<string> {"Vampire1", "Vampire2", "Vampire3", "Vampire4", "Vampire5", "Vampire6"};
        bool allKilled = q2Enemies.All(enemiesKilled.Contains);
        return allKilled;
    }
}
