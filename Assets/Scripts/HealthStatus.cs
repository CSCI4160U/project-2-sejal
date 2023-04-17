using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatus : MonoBehaviour
{
    public Transform enemyTransform;
    public Image healthBarImage;

    void Start() 
    {
        enemyTransform = this.transform.parent.transform.parent.transform;
    }
    void Update()
    {

        Vector3 eHeadPos = enemyTransform.position + Vector3.up * 2f;
        Vector3 healthBarPosition = Camera.main.WorldToScreenPoint(eHeadPos);
        healthBarPosition.z = 0f;

        GetComponent<RectTransform>().position = healthBarPosition;


        float healthPercent = enemyTransform.GetComponent<Enemy>().GetHealthPercent();
        healthBarImage.fillAmount = healthPercent;
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