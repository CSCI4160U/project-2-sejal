using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class playerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth;
    [SerializeField] bool isDead = false;
    [SerializeField] public Animator anim;
    public float attackDmg = 10;
    public int questNum;
    public int dialogueNum;
    public List<string> enemiesKilled = new List<string>();
    public GameObject DeathScreen = null;

    void Start() 
    {
        DeathScreen = GameObject.Find("DeadCanvas");
        DeathScreen.SetActive(false);
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
            anim.SetTrigger("Dead");
            StartCoroutine(IsDead(4f));
        }
    }

    public float GetHealthPercent() 
    {
        return currentHealth / maxHealth;
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
    public bool checkQ3()
    {
        List<string> q3Enemies = new List<string> { "Boss1", "Zombie", "Zombie2", "Zombie3", "Zombie4", "Zombie5", "Zombie6" };
        bool allKilled = q3Enemies.All(enemiesKilled.Contains);
        return allKilled;
    }
    public bool checkQ4()
    {
        List<string> q4Enemies = new List<string> { "BigWolf", "BigWolf2", "BigWolf3", "BigWolf4", "BigWolf5", "BigWolf6", "BigWolf7" };
        bool allKilled = q4Enemies.All(enemiesKilled.Contains);
        return allKilled;
    }
    public bool checkQ5()
    {
        List<string> q5Enemies = new List<string> {"Skeleton", "Skeleton2", "Skeleton3", "Skeleton4", "Skeleton5", "Skeleton6", "DemonBoss"};
        bool allKilled = q5Enemies.All(enemiesKilled.Contains);
        return allKilled;
    }
    IEnumerator IsDead(float deathTime)
    {
        yield return new WaitForSeconds(2);
        DeathScreen.SetActive(true);
        yield return new WaitForSeconds(deathTime-2);
        Destroy(gameObject);
    }
}
