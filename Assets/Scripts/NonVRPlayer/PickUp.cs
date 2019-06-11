using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private float sphereRadius;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material defaultMaterial;

    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance;
    private GameObject selectedBall;
    private GameObject pickedUpBall;

    // Update is called once per frame
    void Update()
    {
        if (selectedBall != null)
        {
            selectedBall.GetComponent<Renderer>().material = defaultMaterial;
            selectedBall = null;
        }
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal) && hit.transform.gameObject.CompareTag("Ball") && !pickedUpBall)
        {
            selectedBall = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            Renderer selection = selectedBall.GetComponent<Renderer>();
            if (selection != null)
            {
                selection.material = highlightedMaterial;
            }

            // Click left mouse button pick up a ball
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                pickupBall();
            }
        } else {
            currentHitDistance = maxDistance;
        }

    }

    private void pickupBall()
    {
        selectedBall.GetComponent<Rigidbody>().useGravity = false;
        selectedBall.GetComponent<SphereCollider>().enabled = false;
        selectedBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        selectedBall.transform.SetParent(transform);
        selectedBall.transform.localPosition = new Vector3(0, -0.3f, 0.7f);
        pickedUpBall = selectedBall;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
