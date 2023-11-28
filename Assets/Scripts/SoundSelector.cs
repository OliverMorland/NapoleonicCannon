using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoundSelector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip defaultSound;
    public AudioClip onSelectedSound;
    public AudioClip onMetalSound;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnInteractableSelected);
        }
    }

    private void OnInteractableSelected(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is XRBaseControllerInteractor)
        {
            audioSource.PlayOneShot(onSelectedSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
            audioSource.PlayOneShot(onMetalSound);
        }
        else
        {
            audioSource.PlayOneShot(defaultSound);
        }
    }
}
