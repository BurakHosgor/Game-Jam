using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 3f;
    public bool movingUp = true;

    private Vector2 startingPosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (movingUp)
        {
            rb.velocity = new Vector2(0, speed);

            if (transform.position.y >= startingPosition.y + distance)
            {
                movingUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(0, -speed);

            if (transform.position.y <= startingPosition.y - distance)
            {
                movingUp = true;
            }
        }
    }
}

