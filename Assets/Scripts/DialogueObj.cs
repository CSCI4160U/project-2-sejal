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
    public dOBJs dialogue6;
    public dOBJs dialogue7;
    public dOBJs dialogue8;
    public dOBJs dialogue9;
    public dOBJs dialogue10;
    public dOBJs dialogue11;
    public dOBJs dialogue12;
    public dOBJs dialogue13;
    public dOBJs dialogue14;


    [Header("NPCS")]
    public NPC1 npc1;
    public NPC2 npc2;
    public NPC3 npc3;
    public NPC4 npc4;
    public NPC5 npc5;


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
                currDialogue = dialogue3;
                break;
            case 4:
                initDialogue(dialogue4);
                currDialogue = dialogue4;
                break;
            case 5:
                initDialogue(dialogue5);
                currDialogue = dialogue5;
                break;
            case 6:
                initDialogue(dialogue6);
                currDialogue = dialogue6;
                break;
            case 7:
                initDialogue(dialogue7);
                currDialogue = dialogue7;
                break;
            case 8:
                initDialogue(dialogue8);
                currDialogue = dialogue8;
                break;
            case 9:
                initDialogue(dialogue9);
                currDialogue = dialogue9;
                break;
            case 10:
                initDialogue(dialogue10);
                currDialogue = dialogue10;
                break;
            case 11:
                initDialogue(dialogue11);
                currDialogue = dialogue11;
                break;
            case 12:
                initDialogue(dialogue12);
                currDialogue = dialogue12;
                break;
            case 13:
                initDialogue(dialogue13);
                currDialogue = dialogue13;
                break;
            case 14:
                initDialogue(dialogue14);
                currDialogue = dialogue14;
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
                case 6:
                    npc3.questGiven = true;
                    obj.StartQuest(obj.questObjs[4]);
                    break;
                case 8:
                    obj.StartQuest(obj.questObjs[5]);
                    break;
                case 9:
                    npc4.questGiven = true;
                    obj.StartQuest(obj.questObjs[6]);
                    break;
                case 11:
                    obj.StartQuest(obj.questObjs[7]);
                    break;
                case 12:
                    npc5.questGiven = true;
                    obj.StartQuest(obj.questObjs[8]);
                    break;
                case 14:
                    obj.StartQuest(obj.questObjs[9]);
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
