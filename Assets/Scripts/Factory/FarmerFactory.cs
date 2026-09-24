using UnityEngine;

public class FarmerFactory : MonoBehaviour, IThemeFactory
{
    [SerializeField] private GameObject farmerPrefab;
    public IEntity CreateEntity()
    {
        Instantiate(farmerPrefab, gameObject.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        return null;
    }
    public IStateMachine CreateStateMachine()
    {
        Debug.Log("Farmer Factory");
        return null;
    }
    public ITask CreateTask()
    {
        Debug.Log("Farmer Factory");
        return null;
    }
}
