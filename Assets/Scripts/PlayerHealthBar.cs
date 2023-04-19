using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject player;

    void Update()
    {
        float healthPercent = player.GetComponent<playerStats>().GetHealthPercent();
        healthBarImage.fillAmount = healthPercent;
        Debug.Log(healthPercent);
        if (healthPercent <= 0.7)
        {
            healthBarImage.color = new Color(0.9333333f, 0.594713f, 0.00392154f);
        }
        if (healthPercent <= 0.4)
        {
            healthBarImage.color = Color.red;
        }
    }
}