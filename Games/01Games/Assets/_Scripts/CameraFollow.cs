
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform piggy;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 goal = new Vector3(piggy.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, goal, Time.deltaTime * 10);
    }
}