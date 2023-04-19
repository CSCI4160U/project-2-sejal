using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public Animator anim;
    public GameObject msgTrigger;
    public GameObject dialogueScreen;
    public bool questGiven = false;
    public bool questDone = false;
    private playerStats data;

    void Start()
    {
        data = FindObjectOfType<playerStats>();
        msgTrigger.SetActive(false);
        dialogueScreen.SetActive(false);
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player" && !questDone)
        {
            msgTrigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!questGiven)
                {
                    dialogueScreen.SetActive(true);
                    col.gameObject.GetComponent<playerStats>().dialogueNum = 0;
                    col.gameObject.GetComponent<playerStats>().questNum = 1;
                    msgTrigger.SetActive(false);

                }
                else
                {
                    if (!data.checkQ1())
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 1;
                        msgTrigger.SetActive(false);
                    }
                    else 
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 2;
                        data.maxHealth += 10;
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
