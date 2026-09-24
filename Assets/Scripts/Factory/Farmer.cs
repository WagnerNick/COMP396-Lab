using Core.FSM;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour, IEntity, IStateMachine, ITask
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
        HarvestState harvest = new HarvestState(renderer, agent);
        RestState rest = new RestState(renderer, agent);

        stateMachine.AddTransition(rest, harvest, new FuncPredicate(() => isHarvestReady));
        stateMachine.AddTransition(harvest, rest, new FuncPredicate(() => !isHarvestReady));

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
