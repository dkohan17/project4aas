using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SlotEquipScript : MonoBehaviour
{
    public bool IsEquipped = false;
    public bool OtherSlotEquipped = false;
    public int SlotId;
    public KeyCode SlotKey;
    public GameObject Inventory;

    private void Start()
    {
        switch(SlotId)
        {
            case 1:
                SlotKey = KeyCode.Alpha1;
                break;
            case 2:
                SlotKey = KeyCode.Alpha2;
                break;
            case 3:
                SlotKey = KeyCode.Alpha3;
                break;
            case 4:
                SlotKey = KeyCode.Alpha4;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(SlotKey))
        {
            CheckOtherSlots();
        }
    }

    public void CheckOtherSlots()
    {
        Debug.Log("Checking");
        foreach (Transform child in Inventory.transform)
        {
            if (child.name == transform.name) { }
            else if (child.GetComponent<SlotEquipScript>().IsEquipped)
            {
                child.GetComponent<SlotEquipScript>().IsEquipped = false;
                foreach (Transform child2 in child)
                {
                    Debug.Log(child.name);
                    child2.GetComponent<MeshRenderer>().enabled = false;
                    foreach (var script in child2.GetComponents<MonoBehaviour>())
                    {
                        script.enabled = false;
                    }
                    Debug.Log(child.gameObject.activeSelf);
                }
            }
            Debug.Log("Foreach...");
        }

        if (!IsEquipped)
        {
            IsEquipped = true;
            foreach (Transform child in transform)
            {
                child.GetComponent<MeshRenderer>().enabled = true;
                foreach (var script in child.GetComponents<MonoBehaviour>())
                {
                    script.enabled = true;
                }
            }
        }
        else if (IsEquipped)
        {
            IsEquipped = false;
            foreach (Transform child in transform)
            {
                Debug.Log(child.name);
                child.GetComponent<MeshRenderer>().enabled = false;
                foreach (var script in child.GetComponents<MonoBehaviour>())
                {
                    script.enabled = false;
                }
                Debug.Log(child.gameObject.activeSelf);
            }
            foreach (Transform child in Inventory.transform)
            {
                child.GetComponent<SlotEquipScript>().OtherSlotEquipped = false;
            }
        }
    }
}
