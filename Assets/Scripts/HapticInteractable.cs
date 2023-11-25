using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0, 1f)] public float intensity;
    public float duration = 0.1f;

    public void OnInteractableActivated(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}

public class HapticInteractable : MonoBehaviour
{
    public Haptic hapticOnTriggerActivated;
    public Haptic hapticOnHoverEntered;
    public Haptic hapticOnHoverExited;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.activated.AddListener(hapticOnTriggerActivated.OnInteractableActivated);
            interactable.hoverEntered.AddListener(hapticOnHoverEntered.OnInteractableActivated);
            interactable.hoverExited.AddListener(hapticOnHoverExited.OnInteractableActivated);
        }
    }

    
}
