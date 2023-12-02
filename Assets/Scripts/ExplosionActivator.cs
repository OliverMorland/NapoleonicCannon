using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExplosionActivator : MonoBehaviour
{
    [SerializeField] VisualEffect explosionEffectPrefab;
    [SerializeField] float speedThresholdForExplosion = 2f;
    [SerializeField] float reparentingDelay = 4f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " Collided with " + collision.gameObject.name);
        if (collision.relativeVelocity.sqrMagnitude > speedThresholdForExplosion)
        {
            Debug.Log("Collision speed merits an explosion effect");
            VisualEffect newExplosionEffect = Instantiate(explosionEffectPrefab);
            newExplosionEffect.transform.position = collision.transform.position;
            Vector3 explosionDir = collision.relativeVelocity.normalized * -1f;
            newExplosionEffect.transform.LookAt(newExplosionEffect.transform.position + explosionDir);
            newExplosionEffect.Play();
        }
    }
}
