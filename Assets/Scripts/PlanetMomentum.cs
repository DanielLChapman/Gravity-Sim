using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMomentum : MonoBehaviour
{
     public Transform centralObject;
    public float gravitationalConstant = 6.67430e-7f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null || centralObject == null)
        {
            Debug.LogError("No Rigidbody or centralObject assigned.");
            return;
        }

        // Calculate the initial velocity for a circular orbit
        Vector3 direction = (centralObject.position - transform.position).normalized;
        float distance = Vector3.Distance(centralObject.position, transform.position);
        float centralMass = centralObject.GetComponent<Rigidbody>().mass;
        float orbitalVelocity = Mathf.Sqrt(gravitationalConstant * centralMass / distance);

        // Set the initial velocity perpendicular to the direction to the central object
        Vector3 perpendicularDirection = Vector3.Cross(direction, Vector3.up).normalized;
        rb.velocity = perpendicularDirection * orbitalVelocity * 2;

        // Optionally, add any initial angular velocity if needed
        rb.angularVelocity = Vector3.zero;
    }
}
