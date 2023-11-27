using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cartridge : MonoBehaviour, IIgniteable
{
    public AudioSource audioSource;
    public AudioClip burnSound;
    public AudioClip explosionSound;
    public MeshRenderer cartridgeMeshRenderer;
    public float preExplosionDelay = 0.5f;
    public float gameObjectSelfDestructDelay = 1f;
    Collider collider;
    bool isIgnited = false;
    public UnityEvent OnExplosion;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    public void Ignite()
    {
        isIgnited = true;
        StartCoroutine(ExplosionCoroutine());
    }

    IEnumerator ExplosionCoroutine()
    {
        audioSource.clip = burnSound;
        audioSource.Play();
        yield return new WaitForSeconds(preExplosionDelay);
        audioSource.Stop();
        audioSource.PlayOneShot(explosionSound);
        OnExplosion.Invoke();
        cartridgeMeshRenderer.enabled = false;
        collider.enabled = false;
        yield return new WaitForSeconds(gameObjectSelfDestructDelay);
        Destroy(this.gameObject);
    }

    public bool IsIgnited()
    {
        return isIgnited;
    }
}
