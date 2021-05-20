﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("GameOver");
        }
    }
}
