using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3 : MonoBehaviour
{
    public Animator anim;
    public GameObject msgTrigger;
    public GameObject dialogueScreen;
    public bool questGiven = false;
    public bool questDone = false;
    public bool prevDone = false;
    private playerStats data;
    private NPC2 q2;

    void Start()
    {
        data = FindObjectOfType<playerStats>();
        q2 = FindObjectOfType<NPC2>();
        msgTrigger.SetActive(false);
        dialogueScreen.SetActive(false);
    }
    void Update()
    {
        prevDone = q2.questDone;
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
                    col.gameObject.GetComponent<playerStats>().dialogueNum = 6;
                    col.gameObject.GetComponent<playerStats>().questNum = 3;
                    msgTrigger.SetActive(false);
                }
                else
                {
                    if (!data.checkQ3())
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 7;
                        msgTrigger.SetActive(false);
                    }
                    else
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 8;
                        data.currentHealth = data.maxHealth;
                        data.attackDmg += 5;
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
