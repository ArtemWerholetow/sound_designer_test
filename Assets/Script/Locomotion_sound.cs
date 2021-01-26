using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion_sound : MonoBehaviour
{
    public AK.Wwise.Event footevent;
    public RaycastHit Rh;
    public string SwitchGroup = "Footstep_material";
    bool playersMoving;
    public float walkingSpeed;
    string material;

 
    

    private void Update()
    {
        if (Physics.Raycast(transform.position,Vector3.down,out Rh,0.3f))
        {
            material = Rh.collider.tag;
        }
        
            if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f|| Input.GetAxis("Vertical") <=-0.01f|| Input.GetAxis("Horizontal") <= -0.01f)
            {
                playersMoving = true;
            }
            else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
            {
                playersMoving = false;
            }
        
    }
    
    void CallFotstep()
    {
        if ( playersMoving ==true)
        {
            if (material=="marble")
            {
                AkSoundEngine.SetSwitch(SwitchGroup, "marble", gameObject);
                footevent.Post(gameObject);
            }
            if (material == "porch")
            {
                AkSoundEngine.SetSwitch(SwitchGroup, "porch", gameObject);
                footevent.Post(gameObject);
            }
            if (material == "stairs")
            {
                AkSoundEngine.SetSwitch(SwitchGroup, "stairs", gameObject);
                footevent.Post(gameObject);
            }
        }
        
    }
     void Start()
    {
        InvokeRepeating("CallFotstep", 0, walkingSpeed);
        
     }
    void OnDisable()
    {
        playersMoving = false;
    }
   
}
