using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;


[Serializable]
public class dOBJs
{
    public string[] dialogues;
    public string CharacterName;
    
}

public class DialogueObj : MonoBehaviour

{
    public playerStats data;
    public TMP_Text name;
    public TMP_Text dialogueText;

    private QuestOBJ obj; 

    private int currentDialogueNum = 0;
    private dOBJs currDialogue = null;

    [Header("Dialogue objects")]
    public dOBJs dialogue0;
    public dOBJs dialogue1;
    public dOBJs dialogue2;
    public dOBJs dialogue3;
    public dOBJs dialogue4;
    public dOBJs dialogue5;

    [Header("NPCS")]
    public NPC1 npc1;
    public NPC2 npc2;


    private void Start()
    {
        obj = FindObjectOfType<QuestOBJ>();
    }

    private void Update()
    {
        switch (data.dialogueNum)
        {
            case 0:
                initDialogue(dialogue0);
                currDialogue = dialogue0;

                break;
            case 1:
                initDialogue(dialogue1);
                currDialogue = dialogue1;
                break;
            case 2:
                initDialogue(dialogue2);
                currDialogue = dialogue2;
                break;
            case 3:
                initDialogue(dialogue3);
                currDialogue = dialogue2;
                break;
            case 4:
                initDialogue(dialogue4);
                currDialogue = dialogue2;
                break;
            case 5:
                initDialogue(dialogue5);
                currDialogue = dialogue2;
                break;
            default:
                break;
        }

    }
    void initDialogue(dOBJs tempobj)
    {
        name.text = tempobj.CharacterName;
        if (currentDialogueNum < tempobj.dialogues.Length)
        {
            dialogueText.text = tempobj.dialogues[currentDialogueNum];

        }
        else
        {
            switch (data.dialogueNum)
            {
                case 0:
                    npc1.questGiven = true;
                    obj.StartQuest(obj.questObjs[0]);
                    break;
                case 2:
                    obj.StartQuest(obj.questObjs[1]);
                    break;
                case 3:
                    npc2.questGiven = true;
                    obj.StartQuest(obj.questObjs[2]);
                    break;
                case 5:
                    obj.StartQuest(obj.questObjs[3]);
                    break;
            }
            data.dialogueNum = 0;
            currentDialogueNum = 0;
            currDialogue = null;
            this.gameObject.SetActive(false);
        }
    }
    public void next()
    {
        if(currDialogue != null)
        {
            currentDialogueNum += 1; 
            initDialogue(currDialogue);
        }
    }
}
