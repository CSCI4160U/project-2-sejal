using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4 : MonoBehaviour
{
    public Animator anim;
    public GameObject msgTrigger;
    public GameObject dialogueScreen;
    public bool questGiven = false;
    public bool questDone = false;
    public bool prevDone = false;
    private playerStats data;
    private NPC3 q3;

    void Start()
    {
        data = FindObjectOfType<playerStats>();
        q3 = FindObjectOfType<NPC3>();
        msgTrigger.SetActive(false);
        dialogueScreen.SetActive(false);
    }
    void Update()
    {
        prevDone = q3.questDone;
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
                    col.gameObject.GetComponent<playerStats>().dialogueNum = 9;
                    col.gameObject.GetComponent<playerStats>().questNum = 4;
                    msgTrigger.SetActive(false);
                }
                else
                {
                    if (!data.checkQ4())
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 10;
                        msgTrigger.SetActive(false);
                    }
                    else
                    {
                        dialogueScreen.SetActive(true);
                        col.gameObject.GetComponent<playerStats>().dialogueNum = 11;
                        data.maxHealth += 10;
                        data.currentHealth += 30;
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
