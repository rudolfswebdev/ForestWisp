using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour 
{
    public Transform transformToFollow;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Follow the player
        agent.SetDestination(transformToFollow.transform.position);
    }
}
