using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRay : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject camera;

    private Collider preCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
		{
			pointer.transform.position = hit.point;
		}
		else
		{
			pointer.transform.position = ray.GetPoint(3.0f);
		}
        if (OVRInput.GetDown(OVRInput.Button.One) && hit.collider.tag == "point"){
            hit.collider.gameObject.SetActive(false);
            camera.transform.position = hit.point;
            preCollider.gameObject.SetActive(true);
            preCollider = hit.collider;
        }
    }
}
