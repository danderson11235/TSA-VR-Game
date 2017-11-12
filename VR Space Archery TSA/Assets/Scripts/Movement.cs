using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //VR Controller touch-pad variables
    //The number at the ends of the variables determine which
    //Controller is which, where '1' is left and '2' is right

    public GameObject Left_Controller;
    private SteamVR_TrackedObject trackedObject1;
    private SteamVR_Controller.Device device1;
    private SteamVR_TrackedController controller1;

    public GameObject Right_Controller;
    private SteamVR_TrackedObject trackedObject2;
    private SteamVR_Controller.Device device2;
    private SteamVR_TrackedController controller2;

    //Character Movement Mechanics
    public Vector3 velocity;
    public float Vert_Multiplier;
    public float Forw_Multiplier;
    public float Smooth_Stop_Multiplier;

    // Use this for initialization
    void Start () {
        velocity = new Vector3(0f, 0f, 0f);
        trackedObject1 = Left_Controller.GetComponent<SteamVR_TrackedObject>();
        controller1 = Left_Controller.GetComponent<SteamVR_TrackedController>();
        controller1.PadClicked += Controller1_PadClicked;

        trackedObject2 = Right_Controller.GetComponent<SteamVR_TrackedObject>();
        controller2 = Right_Controller.GetComponent<SteamVR_TrackedController>();
        controller2.PadClicked += Controller2_PadClicked;
    }

    // Update is called once per frame
    void Update() {
        device1 = SteamVR_Controller.Input((int)trackedObject1.index);
        device2 = SteamVR_Controller.Input((int)trackedObject2.index);
    }

    void Controller1_PadClicked(object sender, ClickedEventArgs e)
    {
        if (device1.GetAxis().x != 0 || device1.GetAxis().y != 0)
        {
            //Apply change in velocity in desired direction
        }
        else {
            //Slow down movement in the previous direction by a value
        }
    }

    void Controller2_PadClicked(object sender, ClickedEventArgs e)
    {
        if (device2.GetAxis().x != 0 || device2.GetAxis().y != 0)
        {
            //Apply change in velocity in desired direction
        }
        else
        {
            //Slow down movement in the previous direction by a value
        }
    }
}
