using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(Collider col) 
    {
        Debug.Log("Player Hit");
        if (col.gameObject.CompareTag("Enemy")) 
        {
            
            health -= 10f;
        }
    }
}
