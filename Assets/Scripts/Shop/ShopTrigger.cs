using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject player;

    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInside = true;
            OpenShop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInside = false;
            CloseShop();
        }
    }

    public void OpenShop()
    {
        shopUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
    }
}
