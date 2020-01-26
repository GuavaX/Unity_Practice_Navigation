using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    public GameObject[] target;

    private Animator ani;
    private NavMeshAgent nav;
    private Transform traTargetNow;

    private float stopDistance = 0.1f;
    private int lastNumber;

    private void Start()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 10;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int number = Random.Range(0, 5);

            while (lastNumber == number)
            {
                number = Random.Range(0, 5);
            }

            lastNumber = number;

            traTargetNow = target[number].GetComponent<Transform>();

            Move();
            nav.SetDestination(traTargetNow.position);            
        }

        if (nav.remainingDistance < stopDistance)
        {
            Wait();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        ani.SetBool("跑步開關", true);
    }

    private void Wait()
    {
        ani.SetBool("跑步開關", false);
    }

}
