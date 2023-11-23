using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject rightTeleportation;
    public InputActionProperty rightTeleportationAction;
    public InputActionProperty rightCancel;


    // Update is called once per frame
    void Update()
    {
        if (rightCancel.action.ReadValue<float>() == 0 && rightTeleportationAction.action.ReadValue<float>() > 0.1f)
        {
            rightTeleportation.gameObject.SetActive(true);
        }
        else
        {
            rightTeleportation.gameObject.SetActive(false);
        }
    }
}
