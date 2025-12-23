using System.Collections;
using UnityEngine;

public class BloodPool : MonoBehaviour
{
    public int InitialSize = 2;
    public GameObject bloodPrefab;

    private void Start()
    {
        if (InitialSize > 0)
        {
            for (int i = 0; i < InitialSize; i++)
            {
                var Clone = Instantiate(bloodPrefab, transform);
                Clone.SetActive(false);
            }
        }
    }

    public void CreateBlood()
    {
        var Clone = Instantiate(bloodPrefab, transform);
        Clone.SetActive(false);
    }

    public void MoveBlood(Transform child, Transform Parent, Vector3 position, Vector3 normal)
    {
        child.SetParent(Parent);
        child.gameObject.SetActive(true);
        child.SetPositionAndRotation(position, Quaternion.LookRotation(normal));
    }

    public void GetBlood(Vector3 position, Vector3 normal, Transform Parent)
    {
        var BloodCount = 0;
        foreach (Transform child in transform)
        {
            BloodCount++;
        }
        if (BloodCount > 0)
        {
            foreach (Transform child in transform)
            {
                MoveBlood(child, Parent, position, normal);
                break;
            }
        }
        else
        {
            CreateBlood();
            foreach (Transform child in transform)
            {
                MoveBlood(child, Parent, position, normal);
                break;
            }
        }
    }

    public void returnBlood(GameObject Blood)
    {
        Blood.SetActive(false);
        Blood.transform.SetParent(transform);
    }
}
