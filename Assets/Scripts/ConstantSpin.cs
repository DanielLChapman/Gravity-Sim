using UnityEngine;

public class ConstantSpin : MonoBehaviour
{
    public float spinRate = 30f; // Spin rate in degrees per second

    void Start()
    {
        // Optional: Freeze position constraints if you only want rotation
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    void FixedUpdate()
    {
        // Apply rotation
        transform.Rotate(Vector3.up, spinRate * Time.deltaTime);
    }
}
