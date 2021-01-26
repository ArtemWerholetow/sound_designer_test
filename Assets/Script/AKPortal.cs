using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKPortal : MonoBehaviour
{
    public GameObject portal;
    AkRoomPortal akportal;
    private void Start()
    {
        akportal = portal.GetComponent<AkRoomPortal>();
    }
    public void PortalOpen()
    {
        akportal.Open();
    }
    public void PortalClose()
    {
        akportal.Close();
    }
}
