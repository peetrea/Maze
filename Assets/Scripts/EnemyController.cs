using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float raycastDistance = 0.1f;
    public LayerMask obstacleLayer;

    private Vector3 currentDirection;
    private float timeToChangeDirection = 10.0f; // Schimbă direcția la fiecare 2 secunde
    private float timer = 0.0f;

    private void Start()
    {
        // Inițializăm direcția curentă cu o valoare aleatoare
        currentDirection = Random.insideUnitSphere;
        currentDirection.y = 0;
        currentDirection.Normalize();
    }

    private void Update()
    {
        // Contorizăm timpul pentru a schimba direcția la intervale regulate
        timer += Time.deltaTime;

        if (timer >= timeToChangeDirection)
        {
            // Schimbăm direcția la fiecare interval de timp
            ChangeDirection();
            timer = 0.0f;
        }

        // Mișcăm inamicul în direcția curentă
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // Detectăm obstacole cu raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, currentDirection, out hit, raycastDistance, obstacleLayer))
        {
            // Dacă detectăm un obstacol în față, schimbăm direcția
            ChangeDirection();
            // float distanceToObstacle = hit.distance;
            // Debug.Log("Distanța până la obstacol: " + distanceToObstacle);
        }
    }

    private void ChangeDirection()
    {
        // Schimbăm direcția la o valoare aleatoare
        currentDirection = Random.insideUnitSphere;
        currentDirection.y = 0;
        currentDirection.Normalize();
    }
}
