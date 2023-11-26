using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igniter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IIgniteable igniteable = other.GetComponent<IIgniteable>();
        if (igniteable != null)
        {
            Debug.Log("Igniting " + other.gameObject.name);
            if (!igniteable.IsIgnited())
            {
                igniteable.Ignite();
            }
        }
    }
}