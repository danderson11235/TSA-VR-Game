using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private bool isAttached = false;

    private bool isFired = false;

    private void OnTriggerStay(Collider other)
    {
        AttachArrow();
    }
    private void OnTriggerEnter(Collider other)
    {
        AttachArrow();
    }

    private void Update()
    {
        if (isFired)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }

    public void Fired()
    {
        isFired = true;
    }

    //Only when holding the trigger button down will you lock into aim mode
    private void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
        if (!isAttached && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowManager.Instance.AttachArrowToBow();
            isAttached = true;
        }
    }
}
