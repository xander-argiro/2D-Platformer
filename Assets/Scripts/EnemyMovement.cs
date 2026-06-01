using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float MOVE_SPEED = 2f;
    public float MOVE_DISTANCE = 4f;

    Vector3 startingPosition;
    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * direction * MOVE_SPEED * Time.deltaTime;

        float distanceFromStart = Mathf.Abs(transform.position.x - startingPosition.x);
        if (distanceFromStart >= MOVE_DISTANCE)
        {
            direction *= -1;
        }
    }
}
