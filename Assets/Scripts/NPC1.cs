using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public GameObject msgTrigger;
    public GameObject dialogueScreen;
    public bool questGiven = false;
    public bool questDone = false;

    void Start()
    {
        msgTrigger.SetActive(false);
        dialogueScreen.SetActive(false);
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            msgTrigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!questGiven)
                {
                    dialogueScreen.SetActive(true);
                    col.gameObject.GetComponent<PlayersData>().dialogueNum = 0;
                    msgTrigger.SetActive(false);
                }
                else
                {
                    //Figure out way to check if all the wolves are dead
                    dialogueScreen.SetActive(true);
                    col.gameObject.GetComponent<PlayersData>().dialogueNum = 1;
                    msgTrigger.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        msgTrigger.SetActive(false);
    }
}
