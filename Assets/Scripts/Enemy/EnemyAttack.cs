using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : StateMachineBehaviour
{
    private PlayerMove _player;
    private NavMeshAgent _agent;
    private Health _playerHealth;
    private float _timer;
    private float _delayAttack = 1.1f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = FindObjectOfType<PlayerMove>();
        _playerHealth = FindObjectOfType<Health>();
        _agent = animator.GetComponent<NavMeshAgent>();

        _agent.isStopped = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;
        Vector3 direction = _player.transform.position - animator.transform.position;
        direction.Normalize();
        direction = new Vector3(direction.x, 0, direction.z);
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        animator.transform.rotation = targetRotation;

        float distance = Vector3.Distance(animator.transform.position, _player.transform.position);

        if (distance > 3)
        {
            _agent.isStopped = false;
            animator.SetBool("Attack", false);
        }
        else if (distance <= 3 && _timer >= _delayAttack)
        {
            _timer = 0;
            _playerHealth.TakeDamage(1);
        }
    }
}
