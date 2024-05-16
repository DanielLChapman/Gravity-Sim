using UnityEngine;

public class GravityInfluence : MonoBehaviour
{
    public Rigidbody rb;

    private string tag = "MainBody";
    private UniqueIdentifier uniqueIdentifier;

    void Start()
    {
        // Find the Rigidbody on the child object

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on child object.");
            return;
        }
        uniqueIdentifier = GetComponentInParent<UniqueIdentifier>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius * transform.localScale.x);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("GravitySphere"))
            {
                GameObject child = null;
                UniqueIdentifier otherUniqueIdentifier = collider.GetComponentInParent<UniqueIdentifier>();
                if (otherUniqueIdentifier != null && otherUniqueIdentifier.uniqueID != uniqueIdentifier.uniqueID) {

                    foreach(Transform transform in collider.transform.parent.transform) {
                        if(transform.CompareTag(tag)) {
                            child = transform.gameObject;
                            break;
                        }
                    }

                    GravityField otherField = null;
                    if (child) {
                        otherField = child.GetComponent<GravityField>();
                    }
                    otherField.AddInfluencedObject(rb);
                }
        
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GravitySphere"))
        {
            GameObject child = null;
            UniqueIdentifier otherUniqueIdentifier = other.GetComponentInParent<UniqueIdentifier>();
            if (!otherUniqueIdentifier || otherUniqueIdentifier == transform.GetComponentInParent<UniqueIdentifier>()) {
                return;
            }
 
            foreach(Transform transform in other.transform.parent.transform) {
                if(transform.CompareTag(tag)) {
                    child = transform.gameObject;
                    break;
                }
            }

            GravityField otherField = null;
            if (child) {
                otherField = child.GetComponent<GravityField>();
            }
            otherField.AddInfluencedObject(rb);
        }
    }


    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("GravitySphere"))
        {
             GameObject child = null;
            UniqueIdentifier otherUniqueIdentifier = other.GetComponentInParent<UniqueIdentifier>();
            if (!otherUniqueIdentifier || otherUniqueIdentifier == transform.GetComponentInParent<UniqueIdentifier>()) {
                return;
            }
 
            foreach(Transform transform in other.transform.parent.transform) {
                if(transform.CompareTag(tag)) {
                    child = transform.gameObject;
                    break;
                }
            }

            GravityField otherField = null;
            if (child) {
                otherField = child.GetComponent<GravityField>();
            }
            otherField.RemoveInfluencedObject(rb);
        }
    }
}
