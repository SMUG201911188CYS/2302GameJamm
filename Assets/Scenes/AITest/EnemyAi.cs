using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent nav;
    
    public Transform[] waypoints;

    public bool m_patrol = true;

    public static bool m_tangerine = false;

    public bool m_walksound = false;

    public static bool m_scream = false;
    
    public int m_cur = 0;

    public static Transform target;

    public static bool player_hit = false;
    

    void Move()
    {

        if (m_patrol&&PlayerMove.isWalk == false &&m_tangerine == false &&m_scream == false) // patrol 조건문
        {
            nav.speed = 5f;
            nav.SetDestination(waypoints[m_cur].position);
            if (!nav.pathPending && nav.remainingDistance < nav.stoppingDistance)
            {
                m_cur = (m_cur + 1) % waypoints.Length;
                nav.SetDestination(waypoints[m_cur].position);
            }
        }else if (m_tangerine && target != null && m_scream == false) // tangerine 조건문
        {
            Debug.Log("Tangerine Find");
            nav.speed = 15f;
            nav.SetDestination(target.position);
            if (!nav.pathPending && nav.remainingDistance < nav.stoppingDistance) //도착 시 탈출
            {
                m_tangerine = false;
            }
        }else if (m_scream) // 소리 지르면 사망
        {
            nav.speed = 30f;
            Debug.Log("Scream Find");
            nav.SetDestination(target.position);
            if (!nav.pathPending && nav.remainingDistance < nav.stoppingDistance)
            {
                m_scream = false;
            }
        }else if (m_tangerine == false && m_scream == false && m_walksound ) // 플레이어 발견
        {
            Debug.Log("Walk Find");
            Debug.Log("ISWALK :" + PlayerMove.isWalk);
            Debug.Log("ISDEAD :" + PlayerMove.isDead);
            if (PlayerMove.isWalk)
            {
                nav.speed = 5f;
                Debug.Log("WalkSound Find");
                nav.SetDestination(target.position);
            }
            if (!nav.pathPending && nav.remainingDistance < nav.stoppingDistance)
            {
                
                m_walksound = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tangerine"))
        {
            target = other.transform;
            m_tangerine = true;
        }
        
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            m_walksound = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && PlayerMove.isWalk && m_scream == false  && m_tangerine == false )
        { 
            m_walksound = true;
            target = other.transform;
            nav.SetDestination(other.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tangerine"))
        {
            m_tangerine = false;
        }else if (other.CompareTag("Player"))
        {
            m_walksound = false;
        }
    }

    void Start()
    {
        Debug.Log("Test start");
        nav.speed = 5f;
        nav.SetDestination(waypoints[0].position);
       
    }

   
    void Update()
    {
        Move();
        if (player_hit)
        {
            Destroy(gameObject);
        }
    }

    
}
