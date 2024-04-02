using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Enemy_Hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove.isDead = true;
            EnemyAi.player_hit = true;
        }
        if (other.CompareTag("Tangerine"))
        {
            EnemyAi.m_tangerine = false;
        }
    }
}
