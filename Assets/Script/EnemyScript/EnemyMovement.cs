using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public GameObject playerCam;
    public LayerMask Player, Ground;
    public Animator animator;
    public AudioSource laughing;
        public GameObject jumpCam;

    public Vector3 walkPoints;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    Death dead;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
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
        agent.speed = 3.5f;
        animator.SetBool("Walk", true);
        animator.SetBool("Run", false);
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
        agent.speed = 10f;
        animator.SetBool("Run", true);
        animator.SetBool("Walk", false);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        laughing.Play();
        jumpCam.SetActive(true);
        playerCam.SetActive(false);

        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Dead");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
