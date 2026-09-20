using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class PatrolState : BaseState
    {
        public PatrolState(MeshRenderer renderer, NavMeshAgent agent) : base(renderer, agent) { }

        public override void Enter()
        {
            base.Enter();
            meshRenderer.material.color = Color.yellow;
        }
    }
}