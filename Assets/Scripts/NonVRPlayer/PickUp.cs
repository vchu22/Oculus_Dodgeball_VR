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
    private bool throwing = false;
    private CameraMove cameraMove;
    private float ballThrowingForce;

    private Vector3 origMousePosition;
    private bool settingProjectile;

    private void Awake()
    {
        cameraMove = transform.GetComponent<CameraMove>();
        ballThrowingForce = 50f;
        settingProjectile = false;
    }

    // Update is called once per frame
    private void Update()
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
        }
        else
        {
            currentHitDistance = maxDistance;
            if (pickedUpBall)
            {
                // Click left mouse button to set projectile
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Setting projectile");
                    setProjectile();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    releaseBall();
                }
            }

            // Click right mouse button to drop the ball
            if (Input.GetMouseButton(1) && !throwing)
            {
                releaseBall();
            }
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

    private void setProjectile()
    {
        if (!settingProjectile)
        {
            origMousePosition = Input.mousePosition;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            settingProjectile = true;
        }
        throwing = true;
        cameraMove.enabled = false;
    }
    private void releaseBall()
    {
        if (throwing)
        {
            if (settingProjectile)
            {
                Debug.Log("Throw");
                float offset = origMousePosition.y - Input.mousePosition.y;
                Debug.Log("Force multiplier: " + offset);
                pickedUpBall.GetComponent<Rigidbody>().AddForce(this.transform.forward * (ballThrowingForce + offset * 0.2f));
            }
            else
            {
                pickedUpBall.GetComponent<Rigidbody>().AddForce(this.transform.forward * ballThrowingForce);
            }
            cameraMove.enabled = true;
            throwing = false;
            settingProjectile = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        pickedUpBall.GetComponent<Rigidbody>().useGravity = true;
        pickedUpBall.GetComponent<SphereCollider>().enabled = true;
        pickedUpBall.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        pickedUpBall.transform.parent = null;
        pickedUpBall = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
