using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour 
{
    public Transform transformToFollow;
    NavMeshAgent agent;
    public bool stationary = true;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Follow the player
        if(stationary == false)
        {
            anim.SetBool("isWalking", true);
            agent.SetDestination(transformToFollow.transform.position);
        }

        if(agent.velocity == new Vector3(0, 0, 0))
        {
            anim.SetBool("isWalking", false);
        }else
        {
            anim.SetBool("isWalking", true);
        }

        
    }

    public void StartFollow()
    {
        stationary = false;
    }
}
