using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {
    private Vector3 _direction;
    private Vector3 _origin;

    private GameObject[] _collisions;

    public bool canMove;

    public float maxVerticalRange;
    public float maxHorizontalRange;
    public float speed;

    public Action OnDeath;

    public void MakeDirectionInversed()
    {
        _direction = -_direction;
    }

    private void HeadTo()
    {
        transform.position += _direction*speed*Time.deltaTime;
    }

    private void Reverse()
    {
        Vector3 newDirection = _direction;
        if (maxVerticalRange/2+_origin.y <= transform.position.y || -(maxVerticalRange/2)+_origin.y >= transform.position.y)
        {
            Debug.Log("Reversing");
            newDirection.y = -_direction.y;
        }
        
        _direction = newDirection;
    }

	void Start () {
        maxVerticalRange = transform.position.y + maxVerticalRange;
        maxHorizontalRange = transform.position.x + maxHorizontalRange;
        _direction = new Vector3(UnityEngine.Random.Range(0.1f, 0.9f), UnityEngine.Random.Range(0.1f, 0.9f));
        _collisions = new GameObject[2];
        _collisions[0] = GameObject.FindGameObjectWithTag("Player");
        _collisions[1] = GameObject.FindGameObjectWithTag("Cpu");
        Debug.Log(_direction);
	}
	
	void Update () {
        if (canMove)
        {
            HeadTo();
        }
        Reverse();
        if (transform.position.x >= maxHorizontalRange/2 || transform.position.x <= -maxHorizontalRange/2)
        {
            Debug.Log("Dead");
            if (OnDeath != null)
            {
                OnDeath();
            }
            else
            {
                Debug.Log("Trying to assigning it.");
                OnDeath += GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>().SpawnBall;
            }
        }
        for (int i = 0; i < _collisions.Length; i++)
        {
            if (OnCollision(_collisions[i]))
            {
                Vector3 newDirection = _direction;

                switch (_collisions[i].GetComponent<PongBar>().moving)
                {
                    case PongBar.Movement.Down:
                        newDirection.y = -Math.Abs(_direction.y);
                        break;
                    case PongBar.Movement.Up:
                        newDirection.y = Math.Abs(_direction.y);
                        break;
                    case PongBar.Movement.None:
                        newDirection.y = -_direction.y;
                        break;
                }
                Debug.Log("Speeding up");
                speed += 0.05f;
                _direction = newDirection;
                _direction.x = -_direction.x;
                HeadTo();
            }
        }
            
	}

    private bool VerticalCollision(GameObject obj)
    {
        //Vertical aspect of the object
        if (obj.GetComponent<SpriteRenderer>().size.y / 2 + obj.transform.position.y >= gameObject.transform.position.y - (gameObject.GetComponent<SpriteRenderer>().size.y/2)
            && obj.transform.position.y - (obj.GetComponent<SpriteRenderer>().size.y / 2) <= gameObject.transform.position.y + (gameObject.GetComponent<SpriteRenderer>().size.y / 2))
        {
            return true;
        }
        return false;
    }

    private bool OnCollision(GameObject obj)
    {
        //Horizontal aspect of the object
        if (obj.GetComponent<SpriteRenderer>().size.x / 2 + obj.transform.position.x >= gameObject.transform.position.x - (gameObject.GetComponent<SpriteRenderer>().size.x/2) 
            && obj.transform.position.x - obj.GetComponent<SpriteRenderer>().size.x / 2 <= gameObject.transform.position.x + (gameObject.GetComponent<SpriteRenderer>().size.x / 2))
        {
            Debug.Log("horizontal range is true");
            if (VerticalCollision(obj))
            {
                Debug.Log("vertical range is true");
                return true;
            }
        }
        return false;
    }
}
