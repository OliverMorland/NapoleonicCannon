using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 3f;
    public Canvas gameMenu;
    public InputActionProperty showButton; 

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            gameMenu.enabled = (!gameMenu.enabled);
            gameMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        gameMenu.transform.LookAt(head);
        gameMenu.transform.forward *= -1f;
    }
}
