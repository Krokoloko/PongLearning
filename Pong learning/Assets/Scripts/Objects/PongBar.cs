using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBar : MonoBehaviour {

    public enum Movement {Up, Down , None};

    public Movement moving;
    public float moveSpeed;
    public float range;

    private Rigidbody2D _rb;
    private GameObject _ball;

    private Vector3 origin;

    public void MoveUp()
    {
        if (origin.y + range/2 >= transform.position.y)
        {
            moving = Movement.Up;
            gameObject.transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
        }
    }

    public void MoveDown()
    {
        if (origin.y - range/2 <= transform.position.y)
        {
            moving = Movement.Down;
            gameObject.transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
        }
    }
}
