using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Events/VoidEventChannel")]
public class VoidEventChannel : ScriptableObject
{
    public event UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}



public class PlayerEventChannel : GenericEventChannel<Player>
{ }

public class Player
{
    public string Name;
    public int level;
    public float currHealth;
    public float maxHealth;
}
