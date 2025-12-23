using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayerScript : MonoBehaviour
{
    //Transform
    public Transform Enemy;
    public Transform Player;

    //Scripts
    public WalkEnemyScript WalkEnemyScript;

    //Data
    public float speed;
    public float rotationSpeed;
    public bool spotted = false;


    private void Start()
    {
        Enemy = transform.parent;
        WalkEnemyScript = Enemy.GetComponent<WalkEnemyScript>();
        speed = WalkEnemyScript.speed;
        rotationSpeed = WalkEnemyScript.rotationSpeed;
    }

    private void Update()
    {
        if (spotted)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Enemy.rotation = Quaternion.Lerp(
                    Enemy.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            Enemy.position = Vector3.MoveTowards(
                Enemy.position,
                Player.position,
                speed * Time.deltaTime
            );
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WalkEnemyScript.currentPoint = 0;
            WalkEnemyScript.enabled = false;
            Debug.Log("Walk script was turned off");
            spotted = true;
        }
    }
}
