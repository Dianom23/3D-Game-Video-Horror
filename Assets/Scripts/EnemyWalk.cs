using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : StateMachineBehaviour
{
    private PlayerMove _player;
    private NavMeshAgent _agent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = FindObjectOfType<PlayerMove>();
        _agent = animator.GetComponent<NavMeshAgent>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, _player.transform.position);
        _agent.SetDestination(_player.transform.position);

        if (distance > 10)
            animator.SetBool("Walk", false);
    }
}
