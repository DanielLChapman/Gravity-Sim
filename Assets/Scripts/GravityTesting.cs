using UnityEngine;

public class GravityTesting : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        // Find the Rigidbody on the child object

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on child object.");
            return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.parent);
    }
    

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.transform.parent);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.transform.parent);
    }
    
}
