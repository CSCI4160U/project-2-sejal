using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public Animator anim;
    public GameObject msgTrigger;
    public GameObject dialogueScreen;
    public bool questGiven = false;
    public bool questDone = false;
    public bool prevDone = false;
    private playerStats data;
    private NPC1 q1;

    void Start()
    {
        data = FindObjectOfType<playerStats>();
        q1 = FindObjectOfType<NPC1>();
        msgTrigger.SetActive(false);
        dialogueScreen.SetActive(false);
    }
    void Update()
    {
        prevDone = q1.questDone;
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
                    col.gameObject.GetComponent<playerStats>().dialogueNum = 3;
                    col.gameObject.GetComponent<playerStats>().questNum = 2;
                    msgTrigger.SetActive(false);

                }
                else
                {
                    if (!data.checkQ2())
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 4;
                        msgTrigger.SetActive(false);
                    }
                    else
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 5;
                        data.currentHealth = data.maxHealth;
                        data.attackDmg += 10;
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
