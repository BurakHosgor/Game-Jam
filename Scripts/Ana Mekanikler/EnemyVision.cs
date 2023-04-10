using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyVision : MonoBehaviour
{
    public float speed = 5;
    public float waitTime = .3f;

    public static event System.Action OnGuardHasSpottedPlayer;

    public Light2D spotLight;
    public float viewDistance;
    private float viewAngle;
    public LayerMask viewMask;
    public float timeToSpotPlayer = .5f;

    private float playerVisibleTimer;

    private Color originalSpotLightColor;

    private Transform player;

    public Transform pathHolder;

    private Vector3 currentDirection = Vector3.right;

    

    private void Start()
    {
        originalSpotLightColor = spotLight.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotLight.pointLightInnerAngle;

        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, waypoints[i].y, transform.position.z);
        }

        StartCoroutine(FollowPath(waypoints));
    }

    void Update()
    {
        
        if (CanSeePlayer())
        {
            playerVisibleTimer += Time.deltaTime;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
        }

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotLight.color = Color.Lerp(originalSpotLightColor, Color.red, playerVisibleTimer / timeToSpotPlayer);
        if (playerVisibleTimer >= timeToSpotPlayer)
        {
            if (OnGuardHasSpottedPlayer != null)
            {
                OnGuardHasSpottedPlayer();
            }
        }
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer=(player.position - transform.position).normalized;
            float angleBetweenGuardandPlayer= Vector3.Angle(transform.position, dirToPlayer);
            if (angleBetweenGuardandPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
                
            }
        }
        return false;
    }

    private IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);

                currentDirection = (targetWaypoint - transform.position).normalized;
            }

            Flip(currentDirection);
            yield return null;
        }
    }

    private void Flip(Vector3 direction)
    {
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(6, 6, 1);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(-6, 6, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,transform.forward*viewDistance);
    }
}
