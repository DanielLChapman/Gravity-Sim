using UnityEngine;
using System.Collections.Generic;

public class GravityField : MonoBehaviour
{
    public float gravitationalConstant = 6.67430e-11f;
    public float negligibleGravityThreshold = 1e-6f;

    private List<Rigidbody> influencedObjects = new List<Rigidbody>();

    void FixedUpdate()
    {
        AttractObjects();
    }

    public void AddInfluencedObject(Rigidbody obj)
    {
        if (obj != null && !influencedObjects.Contains(obj))
        {
            influencedObjects.Add(obj);
            Debug.Log("Current object: " + transform.parent);
            Debug.Log("Added influenced object: " + obj.name);
        }
    }

    public void RemoveInfluencedObject(Rigidbody obj)
    {
        if (obj != null && influencedObjects.Contains(obj))
        {
            influencedObjects.Remove(obj);
            Debug.Log("Current object: " + transform.parent);
            Debug.Log("Removed influenced object: " + obj.name);
        }
    }

    void AttractObjects()
    {
        foreach (Rigidbody rb in influencedObjects)
        {
            
            if (rb != null && rb != GetComponent<Rigidbody>())
            {
                Vector3 direction = transform.position - rb.position;
                float distance = direction.magnitude;

                if (distance == 0f) continue; // Prevent division by zero

                float forceMagnitude = gravitationalConstant * (rb.mass * GetComponent<Rigidbody>().mass) / Mathf.Pow(distance, 2);

                

                // Apply gravity only if the force magnitude is above the negligible threshold
                if (forceMagnitude >= negligibleGravityThreshold)
                {
                    Vector3 force = direction.normalized * forceMagnitude * 10;
                    rb.AddForce(force);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            float mass = GetComponent<Rigidbody>().mass;
            float approximateRadius = Mathf.Sqrt(gravitationalConstant * mass / negligibleGravityThreshold);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, approximateRadius);
        }
    }
}
