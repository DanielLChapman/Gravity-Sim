using UnityEngine;

public class UniqueIdentifier : MonoBehaviour
{
    public string uniqueID;

    void Awake()
    {
        uniqueID = System.Guid.NewGuid().ToString();
    }
}
