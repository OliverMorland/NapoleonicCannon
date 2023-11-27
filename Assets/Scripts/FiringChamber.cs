using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringChamber : MonoBehaviour
{
    [SerializeField] Transform cartridgeSnapPoint;
    [SerializeField] Transform cannonOpeningPoint;
    [SerializeField] float strength = 100f;
    Rigidbody projectile;


    private void OnTriggerEnter(Collider other)
    {
        Cartridge cartridge = other.GetComponent<Cartridge>();
        if (cartridge != null)
        {
            cartridge.transform.position = cartridgeSnapPoint.position;
            Rigidbody rigidBody = cartridge.GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
            cartridge.OnExplosion.RemoveListener(OnCartridgeExploded);
            cartridge.OnExplosion.AddListener(OnCartridgeExploded);
        }
        else
        {
            Rigidbody newprojectile = other.GetComponent<Rigidbody>();
            if (newprojectile != null)
            {
                Debug.Log("Registered projectile: " + newprojectile.name);
                projectile = newprojectile;
            }
        }
    }

    void OnCartridgeExploded()
    {
        Debug.Log("On Cartridge exploded firing projectile");
        FireProjectile();
    }

    [ContextMenu("Fire Projectile")]
    void FireProjectile()
    {
        if (projectile != null)
        {
            Vector3 dir = (cannonOpeningPoint.position - cartridgeSnapPoint.position).normalized;
            projectile.AddForce(dir * strength, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FireProjectile();
        }
    }
}
