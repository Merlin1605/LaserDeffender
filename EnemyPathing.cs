using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(wayPointIndex < wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex + 1].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
