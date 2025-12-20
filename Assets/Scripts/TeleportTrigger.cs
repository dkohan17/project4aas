using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform teleportPoint;
    public GameObject player;
    public GameObject teleportUI;

    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInside = true;
            teleportUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInside = false;
            teleportUI.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Teleport()
    {
        player.transform.position = teleportPoint.position;
        player.transform.rotation = teleportPoint.rotation;
        teleportUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CancelTeleport()
    {
        teleportUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
