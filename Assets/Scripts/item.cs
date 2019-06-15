using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    Rigidbody rb;
    public float force=10;
    Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Player=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InteractWithUser(){
        EventClasses.Instance.suprise.Invoke();
        rb.AddForce(
            Vector3.Normalize(transform.position-Player.position)*force,
            ForceMode.VelocityChange);
    }
}
