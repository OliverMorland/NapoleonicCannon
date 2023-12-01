using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionActivator : MonoBehaviour
{
    [SerializeField] VisualEffect explosionEffect;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float speedThresholdForExplosion = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        if (rigidBody.velocity.sqrMagnitude > speedThresholdForExplosion)
        {
            OrientateExplosionEffect();
            explosionEffect.Play();
        }
    }

    void OrientateExplosionEffect()
    {
        Vector3 velocityDir = rigidBody.velocity.normalized;
        Vector3 reverseDir = velocityDir * -1f;
        explosionEffect.transform.LookAt(explosionEffect.transform.position + reverseDir);
    }
}
