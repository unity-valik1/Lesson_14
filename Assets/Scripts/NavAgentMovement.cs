using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    private float originalSpeed;
    private float slowSpeed = 2;

    public LayerMask layerMaskSwamp;
    public LayerMask layerMaskDoor;
    public float distans;

    Door door;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        door = FindObjectOfType<Door>();

        cam = Camera.main;
        originalSpeed = agent.speed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        SpeedAndDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
    }
    void SpeedAndDoor()
    {
        Ray ray = new Ray(transform.position, -transform.up);

        Debug.DrawRay(transform.position, -transform.up, Color.red);
        NavMeshHit hit;
        agent.Raycast(agent.transform.position, out hit);
        if (Physics.Raycast(ray, distans, layerMaskSwamp))
        {
            agent.speed = slowSpeed;
        }
        else
        {
            agent.speed = originalSpeed;
        }
        if (Physics.Raycast(ray, distans, layerMaskDoor))
        {
            door.DoorUp();
        }
        else
        {
            door.DoorDown();
        }
    }
}
