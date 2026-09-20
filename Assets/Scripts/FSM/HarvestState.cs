using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class HarvestState : BaseState
    {
        private GameObject havestingPlot;

        public HarvestState(MeshRenderer renderer, NavMeshAgent agent) : base(renderer, agent) { }

        public override void Enter()
        {
            base.Enter();
            meshRenderer.material.color = Color.green;
            havestingPlot = GameObject.FindWithTag("HarvestingPlot");
            agent.SetDestination(havestingPlot.transform.position);
            agent.isStopped = false;
        }

        public override void Update()
        {
            base.Update();
        }
        public override void Exit()
        {
            base.Exit();
            havestingPlot = null;
        }
    }
}