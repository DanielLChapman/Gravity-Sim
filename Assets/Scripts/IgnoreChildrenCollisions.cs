using UnityEngine;

public class IgnoreChildCollisions : MonoBehaviour
{
    void Start()
    {
        // Get all colliders attached to child objects
        Collider[] colliders = GetComponentsInChildren<Collider>();


        // Loop through each pair of colliders
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i + 1; j < colliders.Length; j++)
            {
                // Ignore collisions between the colliders
                Physics.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }
}
