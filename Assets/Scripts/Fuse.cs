using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Fuse : MonoBehaviour, IIgniteable
{
    public float fuseTime;
    public Transform fuseStartPoint;
    public Transform fuseEndPoint;
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
    float startTime = 0;
    bool isIgnited = false;

    [ContextMenu("Light Fuse")]
    public void LightFuse()
    {
        StartCoroutine(LightFuseCoroutine());
    }

    IEnumerator LightFuseCoroutine()
    {
        particleSystem.Play();
        audioSource.Play();
        isIgnited = true;
        startTime = Time.time;
        float elapsedTime = 0;
        while (elapsedTime < fuseTime)
        {
            particleSystem.transform.position = Vector3.Lerp(fuseStartPoint.position, fuseEndPoint.position, (elapsedTime / fuseTime));
            elapsedTime = Time.time - startTime;
            yield return new WaitForEndOfFrame();
        }
        particleSystem.Stop();
        audioSource.Stop();
        isIgnited = false;
    }

    public void Ignite()
    {
        StartCoroutine(LightFuseCoroutine());
    }

    public bool IsIgnited()
    {
        return isIgnited;
    }
}
