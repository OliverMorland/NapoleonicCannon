using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringChamber : MonoBehaviour
{
    [SerializeField] Transform cartridgeSnapPoint;

    private void OnTriggerEnter(Collider other)
    {
        Cartridge cartridge = other.GetComponent<Cartridge>();
        if (cartridge != null)
        {
            cartridge.transform.position = cartridgeSnapPoint.position;
            Rigidbody rigidBody = cartridge.GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
        }
    }
}
