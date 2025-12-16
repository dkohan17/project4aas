using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpTool : MonoBehaviour
{
    private KeyCode KeyToPickUp;
    private GameObject PickUp;
    private GameObject PickUpClone;
    public GameObject Model = null;
    public GameObject weaponHolder;
    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public Transform slot4;
    private int i;

    public bool CanPickUp = false;

    void Start()
    {
        KeyToPickUp = KeyCode.E;
        PickUp = transform.gameObject;

    }

    void Update()
    {
        if (PickUp != null)
        {
            if (CanPickUp)
            {
                if (Input.GetKeyUp(KeyToPickUp))
                {
                    i = 0;
                    foreach (Transform item in slot1)
                    {
                        i = 0;
                        i += 1;
                    }
                    i++;
                    if (i == 1)
                    {
                        PickUpClone = Instantiate(PickUp, slot1);
                        Destroy(Model);
                        CanPickUp = false;
                    }
                    else
                    {
                        i = 0;
                        foreach (Transform item in slot2)
                        {
                            i = 0;
                            i += 1;
                        }
                        i++;
                        if (i == 1)
                        {
                            PickUpClone = Instantiate(PickUp, slot2);
                            Destroy(Model);
                            CanPickUp = false;
                        }
                        else
                        {
                            i = 0;
                            foreach (Transform item in slot3)
                            {
                                i = 0;
                                i += 1;
                            }
                            i++;
                            if (i == 1)
                            {
                                PickUpClone = Instantiate(PickUp, slot3);
                                Destroy(Model);
                                CanPickUp = false;
                            }
                            else
                            {
                                i = 0;
                                foreach (Transform item in slot4)
                                {
                                    i = 0;
                                    i += 1;
                                }
                                i++;
                                if (i == 1)
                                {
                                    PickUpClone = Instantiate(PickUp, slot4);
                                    Destroy(Model);
                                    CanPickUp = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
