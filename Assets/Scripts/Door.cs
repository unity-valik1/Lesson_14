using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public GameObject door;

    Vector3 startPosDoor; 
    void Start()
    {
        startPosDoor = door.transform.position;
    }
    public void DoorUp()
    {
        door.transform.position = new Vector3(startPosDoor.x, 7, startPosDoor.z);
    }  
    public void DoorDown()
    {
        door.transform.position = startPosDoor;
    }
}
