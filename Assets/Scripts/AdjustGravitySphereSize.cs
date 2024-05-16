using UnityEngine;

public class AdjustGravitySphere : MonoBehaviour
{
    public Transform centralSphere;
    public Transform gravitySphere;
    public float gravitationalConstant = 6.67430e-11f;
    public float negligibleGravityThreshold = 1e-6f;

    void Start()
    {
        if (centralSphere == null || gravitySphere == null)
        {
            Debug.LogError("CentralSphere or GravitySphere is not assigned.");
            return;
        }

        AdjustSphereSize();
    }

    void AdjustSphereSize()
    {
        float mass = centralSphere.GetComponent<Rigidbody>().mass;
        float approximateRadius = Mathf.Sqrt(gravitationalConstant * mass / negligibleGravityThreshold);
        gravitySphere.localScale = new Vector3(approximateRadius * 2, approximateRadius * 2, approximateRadius * 2); // Diameter, not radius

        // Ensure the gravity sphere is centered on the central sphere
        gravitySphere.position = centralSphere.position;
    }

    void Update()
    {
        // Keep the gravity sphere centered on the central sphere
        gravitySphere.position = centralSphere.position;
    }
}
