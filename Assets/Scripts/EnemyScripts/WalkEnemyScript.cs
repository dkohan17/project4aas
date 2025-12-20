using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemyScript : MonoBehaviour
{
    //Scripts
    public EnemyStateAliveOrDeadScript StateAliveOrDead;


    //List
    public Transform[] points;


    //Float
    public float speed = 3.5f;
    public float waitTime = 5f;
    public float rotationSpeed = 5f;


    //Int
    public int currentPoint = 0;


    //Bool
    private bool isWaiting = false;


    private void Start()
    {
        StateAliveOrDead = transform.GetComponent<EnemyStateAliveOrDeadScript>();
    }


    private void Update()
    {
        if (StateAliveOrDead.GetState() == "Alive")
        {
            if (points.Length == 0 || isWaiting) return;

            Vector3 targetPos = points[currentPoint].position;

            Vector3 direction = (targetPos - transform.position).normalized;

            if (direction.magnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                points[currentPoint].position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.05f)
            {
                StartCoroutine(WaitAndMoveNext());
            }
        }
    }

    IEnumerator WaitAndMoveNext()
    {
        isWaiting = true;
        waitTime = Random.Range(12f, 18f);
        yield return new WaitForSeconds(waitTime);

        currentPoint++;
        if (currentPoint >= points.Length)
            currentPoint = 0;

        isWaiting = false;
    }
}
