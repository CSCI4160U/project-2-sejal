using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float maxHealth = 20f;
    [SerializeField] public float health;
    [SerializeField] float alertDist = 12f;
    [SerializeField] float attackDist = 2f;
    [SerializeField] Transform target;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float closeEnoughDistance = 1;
    [SerializeField] bool loop = true;
    [SerializeField] float deathTime;

    public GameObject player;
    public GameObject HealthBar;
    private Animator anim;
    private int wayPointIndex = 0;
    private NavMeshAgent agent;
    public bool isAttacked = false;
    private bool patrolling = true;
    public bool canAttack = true;
    public bool isDead = false;

    private void Start()
    {
        health = maxHealth;
        HealthBar = transform.Find("HealthBar").gameObject;
        HealthBar.SetActive(false);
        player = target.gameObject;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if ((agent != null) && (waypoints.Length > 0))
        {
            agent.SetDestination(waypoints[wayPointIndex].position);
        }
    }

    private void Update()
    {
        if (!patrolling)
        {
            return;
        }
        Vector3 direction = target.position - transform.position;
        direction.y = 0.0f;
        float distanceToTarget = Vector3.Distance(agent.transform.position, waypoints[wayPointIndex].position);
       
        if (direction.magnitude < attackDist)
        {
            if (canAttack && !isDead)
            {
                agent.speed = 0;
                canAttack = false;
                anim.SetTrigger("attack");
                player.GetComponent<playerHealth>().TakeDmg(6f);
                StartCoroutine(ResetAttackCoolDown(4f));
            }
        }
        else if (direction.magnitude < alertDist)
        {
            HealthBar.SetActive(true);
            agent.speed = 5;
            anim.SetTrigger("run");
            agent.SetDestination(target.position);  
        }
        
        else if (distanceToTarget < closeEnoughDistance)
        {
            // make the next waypoint active
            wayPointIndex++;
            // loop, if desired
            if (wayPointIndex >= waypoints.Length)
            {
                if (loop)
                {
                    wayPointIndex = 0;
                }
                else
                {
                    patrolling = false;
                    return;
                }
            }
            // navigate to the waypoint
            agent.SetDestination(waypoints[wayPointIndex].position);
        }
        else
        {
            agent.speed = 3;
            anim.SetTrigger("walk");
            agent.SetDestination(waypoints[wayPointIndex].position);
        }
        
    }
    public void TakeDamage(float dmg, float isAttackCool) 
    {
        if (!isAttacked)
        {
            health -= dmg;
            isAttacked= true;
            
            if (health <= 0)
            {
                isDead = true;
                anim.SetTrigger("death");
                StartCoroutine(IsDead(deathTime));
                Debug.Log("Wolf Died!");
            }
            StartCoroutine(ResetIsAttacked(isAttackCool));
        }
        
    }
    public float GetHealthPercent()
    {
        return health / maxHealth;
    }
    IEnumerator ResetIsAttacked(float isAttackCool)
    {
        yield return new WaitForSeconds(isAttackCool);
        isAttacked = false;
    }
    IEnumerator IsDead(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
    IEnumerator ResetAttackCoolDown(float CoolDown)
    {
        yield return new WaitForSeconds(CoolDown);
        canAttack = true;
    }
}
