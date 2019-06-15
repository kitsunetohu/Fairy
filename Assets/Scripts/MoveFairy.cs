using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFairy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (OVRInput.GetDown(OVRInput.Button.One)) {
            pos.z += 1f;
        } else if (OVRInput.GetDown(OVRInput.Button.Two)){
            pos.z += -1f;
        } else if (OVRInput.GetDown(OVRInput.Button.Three)){
            pos.x += 1f;
        } else if (OVRInput.GetDown(OVRInput.Button.Four)){
            pos.x += -1f;
        }
        transform.position = pos;
    }
}
