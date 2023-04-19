using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float alertDistance = 6f;
    [SerializeField] float attackDistance = 1f;
    [SerializeField] float maxHealth = 90f;
    [SerializeField] float health;

    private Animator anim;
    public GameObject HealthBar;
    private NavMeshAgent agent;
    public bool canAttack = true;
    public bool isAttacked = false;
    public GameObject player;

    private void Awake()
    {
        HealthBar = transform.Find("HealthBar").gameObject;
        HealthBar.SetActive(false);
        health = maxHealth;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = target.gameObject;
    }

    private void Update()
    {
        Vector3 towardPlayer = target.position - transform.position;
        towardPlayer.y = 0f;

        if (towardPlayer.magnitude < attackDistance)
        {
            agent.enabled = false;
            anim.SetFloat("Forward", 0f);
            Quaternion lookRotation = Quaternion.LookRotation(towardPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.1f);
            if (canAttack)
            {
                int x = Random.Range(1, 6);
                anim.SetInteger("AttackNum", x);
                anim.SetTrigger("Attack");
                canAttack = false;
                if (x <= 3)
                {
                    player.GetComponent<playerStats>().TakeDmg(10f);
                }
                else
                {
                    player.GetComponent<playerStats>().TakeDmg(15f);
                }
                StartCoroutine(ResetAttackCoolDown(5f));
            }
        }
        else if (towardPlayer.magnitude < alertDistance)
        {
            HealthBar.SetActive(true);
            agent.enabled = true;
            agent.SetDestination(target.position);
            anim.SetFloat("Forward", agent.velocity.magnitude);
        }
    }
    public void TakeDamage(float dmg, float isAttackCool)
    {
        if (!isAttacked)
        {
            health -= dmg;
            isAttacked = true;

            if (health <= 0)
            {
                anim.SetTrigger("Dead");
                var name = this.name;
                player.GetComponent<playerStats>().enemiesKilled.Add(name);
                StartCoroutine(IsDead(4f));
                Debug.Log("Wolf Died!");
            }
            StartCoroutine(ResetIsAttacked(isAttackCool));
        }
    }

    IEnumerator ResetIsAttacked(float isAttackCool)
    {
        yield return new WaitForSeconds(isAttackCool);
        isAttacked = false;
    }
    IEnumerator ResetAttackCoolDown(float CoolDown)
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetInteger("AttackNum", 0);
        yield return new WaitForSeconds(CoolDown - 1.5f);
        canAttack = true;
    }
    IEnumerator IsDead(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
    public float GetHealthPercent()
    {
        return health / maxHealth;
    }
}
