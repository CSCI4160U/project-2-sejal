using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


[Serializable]
public class qOBJs
{
    public string qTitle;
    public string qObj1;
    public string qObj2;

}
public class QuestOBJ : MonoBehaviour
{
    public GameObject questOBJ;
    public TMP_Text questTitle, questObjective1, questObjective2;

    public qOBJs[] questObjs;

    void Start()
    {
        questOBJ.SetActive(false);
    }

    public void StartQuest(qOBJs tempqOBJ)
    {
        questTitle.text = tempqOBJ.qTitle;
        questObjective1.text = tempqOBJ.qObj1;
        questObjective2.text = tempqOBJ.qObj2;
        questOBJ.SetActive(true);
    }
    public void CloseQuest()
    {
        questOBJ.SetActive(false);
    }
}
