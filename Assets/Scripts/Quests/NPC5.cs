using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC5 : MonoBehaviour
{
    public Animator anim;
    public GameObject msgTrigger;
    public GameObject dialogueScreen;
    public bool questGiven = false;
    public bool questDone = false;
    public bool prevDone = false;
    private playerStats data;
    private NPC4 q4;

    void Start()
    {
        data = FindObjectOfType<playerStats>();
        q4 = FindObjectOfType<NPC4>();
        msgTrigger.SetActive(false);
        dialogueScreen.SetActive(false);
    }
    void Update()
    {
        prevDone = q4.questDone;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !questDone && prevDone)
        {
            msgTrigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!questGiven)
                {
                    dialogueScreen.SetActive(true);
                    col.gameObject.GetComponent<playerStats>().dialogueNum = 12;
                    col.gameObject.GetComponent<playerStats>().questNum = 5;
                    data.maxHealth += 30;
                    data.currentHealth = data.maxHealth;
                    data.attackDmg += 10;
                    msgTrigger.SetActive(false);
                }
                else
                {
                    if (!data.checkQ5())
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 13;
                        msgTrigger.SetActive(false);
                    }
                    else
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 14;
                        data.currentHealth = data.maxHealth;
                        msgTrigger.SetActive(false);
                        questDone = true;
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        msgTrigger.SetActive(false);
    }
}
