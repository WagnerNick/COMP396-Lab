using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class GuardState : BaseState
    {
        private GameObject followTarget;

        public GuardState(MeshRenderer renderer, NavMeshAgent agent) : base(renderer, agent) { }

        public override void Enter()
        {
            // Get into a guarding position
            base.Enter();
            meshRenderer.material.color = Color.black;
        }

        public override void Update()
        {
            // Rotate to face the player if they are within a certain range
            base.Update();
        }
        public override void Exit()
        {
            // Exit the guarding position
            base.Exit();
        }
    }
}