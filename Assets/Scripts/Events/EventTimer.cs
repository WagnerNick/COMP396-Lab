using UnityEngine;

public class EventTimer : MonoBehaviour
{
    [SerializeField] private VoidEventChannel channelPos;
    [SerializeField] private Transform[] harvestLocations;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            channelPos.RaiseEvent();
            timer = 0f;
        }
    }
}
