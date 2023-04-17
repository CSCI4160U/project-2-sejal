using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform enemyTransform;

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

    }
}