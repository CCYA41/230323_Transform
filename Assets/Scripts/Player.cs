using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerCtrl playerCtrl = null;

    private Electronics electronics = null;

    private void Awake()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        playerCtrl.SetMLBDelegate(OnMLBDown);
        playerCtrl.SetMRBDelegate(OnMRBDwon);
    }
    private void OnTriggerEnter(Collider _other)
    {
        //if(_other.gameObject.tag == "Electronics") { }
        if (_other.gameObject.CompareTag("Electronics"))
        {
            electronics = _other.GetComponent<Electronics>();
            //Debug.Log("Get Electronics");
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.CompareTag("Electronics"))
        {
            electronics = null;
            //Debug.Log("Release Electronics");
        }
    }
    public void OnMLBDown()
    {
        if (electronics)
        {
            if (electronics.GetIsPowerOn())
                electronics.PowerOff();
            else
                electronics.PowerOn();
        }
        // Debug.Log("On Mouse Left Button");
    }
    public void OnMRBDwon()
    {
        if (electronics)
        {
            electronics.Use();
        }
        // Debug.Log("On Mouse Right Button");
    }
}
