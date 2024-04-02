using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tangerine_hit : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CreateAndDestroy());
        
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit tangerine");
            EnemyAi.m_tangerine = false;
            Debug.Log("m_tangerine :" + EnemyAi.m_tangerine);
            Destroy(gameObject);
        }
    }

    IEnumerator CreateAndDestroy()
    {
        yield return new WaitForSeconds(3f);
        EnemyAi.target = null;
        EnemyAi.m_tangerine = false;
        Destroy(gameObject);
    }
}
