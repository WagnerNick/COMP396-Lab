using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class FollowState : BaseState
    {
        private GameObject followTarget;

        public FollowState(MeshRenderer renderer, NavMeshAgent agent) : base(renderer, agent) { }

        public override void Enter()
        {
            // Set the color and find the target, also ensure the agent is not stopped
            base.Enter();
            meshRenderer.material.color = Color.red;
            followTarget = GameObject.FindWithTag("FollowTarget");
            agent.isStopped = false;
        }

        public override void Update()
        {
            // If a target exists then follow it
            base.Update();
            if (followTarget != null && agent != null)
            {
                agent.SetDestination(followTarget.transform.position);
            }
        }
        public override void Exit()
        {
            // Clear the target
            base.Exit();
            followTarget = null;
        }
    }
}