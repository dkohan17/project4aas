using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelToPickUp : MonoBehaviour
{
    public PickUpTool Tool;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Tool.CanPickUp != true)
        {
            Tool.CanPickUp = true;
            Tool.Model = transform.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && Tool.CanPickUp == true)
        {
            Tool.CanPickUp = false;
            if (Tool.Model == transform.gameObject)
            {
                Tool.Model = null;
            }
        }
    }
}
