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
    public PlayersData data;
    public TMP_Text name;
    public TMP_Text dialogueText;

    private QuestOBJ obj; 

    private int currentDialogueNum = 0;
    private dOBJs currDialogue = null;

    [Header("Dialogue objects")]
    public dOBJs dialogue1;
    public dOBJs dialogue1pnt5;

    [Header("NPCS")]
    public NPC1 npc1;
    
    private void Start()
    {
        obj = FindObjectOfType<QuestOBJ>();
    }

    private void Update()
    {
        switch (data.dialogueNum)
        {
            case 0:
                initDialogue(dialogue1);
                currDialogue = dialogue1;

                break;
            case 1:
                initDialogue(dialogue1pnt5);
                currDialogue = dialogue1pnt5;
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
