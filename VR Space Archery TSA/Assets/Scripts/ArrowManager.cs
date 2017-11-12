using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public static ArrowManager Instance;
    public SteamVR_TrackedObject trackedObj;

    public GameObject arrowPrefab;
    public GameObject stringAttachPoint;
    public GameObject arrowStartPoint;
    public GameObject stringStartPoint;

    private GameObject currentArrow;

    private bool isAttached = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AttachArrow();
        PullString();
	}

    private void AttachArrow()
    {
        if (currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }

    private void PullString()
    {
        if (isAttached)
        {
            float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5f * dist, 0f, 0f);

            var device = SteamVR_Controller.Input((int)trackedObj.index);
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;

        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.GetComponent<Arrow>().Fired ();

        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 15f * dist;
        r.useGravity = true;

        currentArrow.GetComponent<Collider>().isTrigger = false;

        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        currentArrow = null;
        isAttached = false;
    }

    public void AttachArrowToBow()
    {
        currentArrow.transform.parent = null;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isAttached = true;
    }
}
