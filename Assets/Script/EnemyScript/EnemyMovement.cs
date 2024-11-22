using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public int health = 50;
    public int damage = 1;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Player, Ground;
    public GameObject shootingPos;

    public Vector3 walkPoints;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttck;
    bool alreadyAttack;
    public GameObject projectile;

    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (!playerInsightRange && !playerInAttackRange) Patrolling();
        if (playerInsightRange && !playerInAttackRange) ChasePlayer();
        if (playerInsightRange && playerInAttackRange) AttackPlayer();
    }
    private void Patrolling()
    {
        if (!walkPointSet) { SearchWalkPoint(); }
        if (walkPointSet) agent.SetDestination(walkPoints);

        Vector3 distanceToWalkPoint = transform.position - walkPoints;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoints = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoints, -transform.up, 2f, Ground))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttack)
        {
            Rigidbody rb = Instantiate(projectile, shootingPos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(shootingPos.transform.forward * 40f, ForceMode.Impulse);
            rb.AddForce(shootingPos.transform.up * 3f, ForceMode.Impulse);
            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttck);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }

    public void TakeDamage(int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
