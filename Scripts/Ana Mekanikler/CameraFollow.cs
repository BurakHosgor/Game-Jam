using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
// Start is called before the first frame update
{
    public float followSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float xOffset = 1f;



    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x+xOffset, target.position.y+yOffset, -5f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }


}


