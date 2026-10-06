using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]
[RequireComponent(typeof(NavMeshAgent))]
public class CqsWanderAI : MonoBehaviour
{
    [Header("NavMeshAgent")]
    [Space]
    [Header("Socials")]
    [Header("Discord - https://discord.gg/4xQuzQPmxq")]
    [Header("Youtube - @CqsTuts")]
    [Space]

    [Header("Made By Cqs")]
    public NavMeshAgent NavMeshAgent;

    [Header("Wander Settings")]
    public float WanderRadius = 10.0f;
    public float WanderTimer = 5.0f;

    [Header("Detection Settings")]
    public float ChaseRadius = 10.0f;

    [Header("Movement Settings")]
    public float WanderSpeed = 4.0f;
    public float ChaseSpeed = 6.0f;

    [Header("Target Tag")]
    public string TargetTag = "TargetTag";

    private GameObject target;
    private Vector3 WanderPoint;
    private bool IsWandering;

    void Start()
    {
        InitializeComponents();
        Wander();
    }

    void Update()
    {
        FindClosestTargetWithTag(TargetTag);

        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if (distanceToTarget <= ChaseRadius)
            {
                ChaseTarget();
            }
            else if (!IsWandering)
            {
                Wander();
            }
        }
        else if (!IsWandering)
        {
            Wander();
        }
    }

    void InitializeComponents()
    {
        NavMeshAgent.speed = WanderSpeed;
        IsWandering = false;
    }

    void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * WanderRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, WanderRadius, NavMesh.AllAreas);
        WanderPoint = navHit.position;
        NavMeshAgent.SetDestination(WanderPoint);
        NavMeshAgent.speed = WanderSpeed;
        IsWandering = true;
        Invoke("ResetWander", WanderTimer);
    }

    void ChaseTarget()
    {
        NavMeshAgent.speed = ChaseSpeed;
        NavMeshAgent.SetDestination(target.transform.position);
    }

    void ResetWander()
    {
        IsWandering = false;
    }

    void FindClosestTargetWithTag(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;

        foreach (GameObject potentialTarget in targets)
        {
            float distance = Vector3.Distance(transform.position, potentialTarget.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = potentialTarget;
            }
        }

        target = closestTarget;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(WanderPoint, 0.5f);
    }
}
