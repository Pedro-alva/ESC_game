using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBox : MonoBehaviour
{
    Vector2 hitboxOffset;
    public Collider2D interactCollider;

    private void Start(){
        hitboxOffset = transform.localPosition;
    }

    public void InteractRight(){
        interactCollider.enabled = true;
        transform.localPosition = hitboxOffset;
    }

    public void InteractLeft(){
        interactCollider.enabled = true;
        transform.localPosition = new Vector3(hitboxOffset.x * -1, hitboxOffset.y);
    }

    public void StopInteract(){
        interactCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D interactable){
        if(interactable.tag == "NPC"){

        }
        //interact
    }
}
