using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable{
    void InteractWithUser();
}

public class Lamp : MonoBehaviour,Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWithUser(){
        EventClasses.Instance.suprise.Invoke();
    }
}
