using Codice.Client.Common.GameUI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

namespace Core.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCStateMachine : MonoBehaviour
    {
        StateMachine stateMachine;
        [SerializeField] private VoidEventChannel harvestEvent;
        [SerializeField] private bool isHarvestReady;

        private void Awake()
        {
            // Creation of the state machine
            stateMachine = new StateMachine();
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            // Create instances for concrete stateNodes
            PatrolState patrol = new PatrolState(renderer, agent);
            HarvestState harvest = new HarvestState(renderer, agent);
            RestState rest = new RestState(renderer, agent);
            FollowState follow = new FollowState(renderer, agent);
            GuardState guard = new GuardState(renderer, agent);

            stateMachine.AddTransition(rest, harvest, new FuncPredicate(() => isHarvestReady));
            stateMachine.AddTransition(rest, patrol, new FuncPredicate(() => Keyboard.current.pKey.wasPressedThisFrame));
            stateMachine.AddTransition(rest, follow, new FuncPredicate(() => Keyboard.current.fKey.wasPressedThisFrame));
            stateMachine.AddTransition(rest, guard, new FuncPredicate(() => Keyboard.current.gKey.wasPressedThisFrame));

            stateMachine.AddTransition(harvest, rest, new FuncPredicate(() => !isHarvestReady));
            stateMachine.AddTransition(patrol, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));
            stateMachine.AddTransition(follow, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));
            stateMachine.AddTransition(guard, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));

            stateMachine.SetState(rest);

            harvestEvent.OnEventRaised += TransitionToHarvest;
        }

        private void Update()
        {
            stateMachine.Update();
        }

        private void OnDisable()
        {
            harvestEvent.OnEventRaised -= TransitionToHarvest;
        }

        private void TransitionToHarvest()
        {
            isHarvestReady = !isHarvestReady;
        }
    }
}