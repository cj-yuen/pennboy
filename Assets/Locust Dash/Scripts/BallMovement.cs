using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementType {
    Test_JustForward,
    LeftRight,
}

public class BallMovement : MonoBehaviour
{
    MovementType my_movement = MovementType.LeftRight;
    MovementType[] possible_movement_types = { MovementType.Test_JustForward, MovementType.LeftRight };

    float SecondsBeforeAutoDestroyBall = 30f;
    private float FixedTimeWhenIWasSpawned = 0f;

    // Start is called before the first frame update
    void Start()
    {
        int dice = Random.Range(0, possible_movement_types.Length);
        my_movement = possible_movement_types[dice];
        FixedTimeWhenIWasSpawned = Time.fixedTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (my_movement == MovementType.Test_JustForward)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.z += 100f * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, 10f*Time.deltaTime);
        }
        else if (my_movement == MovementType.LeftRight)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.x = 10f * Mathf.Sin(Time.fixedTime) * Mathf.Sin(Time.fixedTime);
            transform.position = targetPosition;
        }

        if (Time.fixedTime - FixedTimeWhenIWasSpawned > SecondsBeforeAutoDestroyBall) {
            Destroy(gameObject);
        }
    }
}
