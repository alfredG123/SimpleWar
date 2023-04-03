using UnityEngine;

public class Minion : MonoBehaviour
{
    private float _speed = 5f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    // Move the current minion
    private void Move()
    {
        Vector3 direction;

        // Determine the direction
        if (this.tag == "Ally")
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }

        // Move the minion toward to target direction
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }
}
