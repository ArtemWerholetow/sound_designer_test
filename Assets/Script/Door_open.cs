using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{
    public Animator anim;
    bool Dooropen = false;
    bool playerInTrigger = false;



    public AK.Wwise.Event open;
    public AK.Wwise.Event close;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerInTrigger = false;

    }
    void DoorControl(string direction)
    {
        anim.SetTrigger(direction);
    }
    // bad code solution
    private void FixedUpdate()
    {
        if (playerInTrigger && !Dooropen && Input.GetMouseButtonDown(0))
        {
            Dooropen = true;
            DoorControl("Open");
        }
        if (playerInTrigger && Dooropen && Input.GetMouseButtonDown(1))
        {
            Dooropen = false;
            DoorControl("Close");
        }
    }
    void PlayOpenSound()
    {
        open.Post(gameObject);
    }
    void PlayCloseSound()
    {
        close.Post(gameObject);
    }
}
