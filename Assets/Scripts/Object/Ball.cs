using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeBall
{
    PLAYER,
    ENEMY
}

public class Ball : MonoBehaviour
{
    [SerializeField] NodeBall _NodeBall;

    public List<int> doorList = new List<int>();

    [Header("Movement")] private float _angle = 1f;
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 10f;
    private bool _canMove = false;


    private Vector3 _velocity;
    private Vector3 _desiredVelocity;


    private void FixedUpdate()
    {
        if (!_canMove) return;
        if (MapCtr.Instance.CheckWallLeft(transform.position))
        {
            _velocity = new Vector3(Mathf.Abs(_velocity.x), _velocity.y, _velocity.z);
        }

        if (MapCtr.Instance.CheckWallRight(transform.position))
        {
            _velocity = new Vector3(-_velocity.x, _velocity.y, _velocity.z);
        }

        if (MapCtr.Instance.CheckDistanceDoor(transform.position))
        {
        }

        _desiredVelocity = _velocity * _maxSpeed;

        transform.position += _desiredVelocity * Time.deltaTime;
    }

    public bool HasCollisionDoor(int idDoor)
    {
        return doorList.Contains(idDoor);
    }

    public void AddID_Door(int id)
    {
        doorList.Add(id);
    }

    public Vector3 GetVelocity()
    {
        return _velocity;
    }

    public void SetDirectionWithSpawn(int i)
    {
        Debug.Log("_velocity  x="+_velocity.x + " x "+Mathf.Sin((_angle * Mathf.PI) / 180f));
        Debug.Log("_velocity z="+_velocity.z + " z "+Mathf.Cos(((_angle/2) * Mathf.PI) / 180f));
        if (i % 2 == 0)
        {
            float angleX = _velocity.x + Mathf.Sin((_angle * Mathf.PI) / 180f);
            float angleZ = _velocity.z + Mathf.Cos((_angle * Mathf.PI) / 180f);
            Vector3 ve = ( transform.position).normalized;
            _velocity = ve;

        }
        else
        {
           

            float angleX = _velocity.x - Mathf.Sin(((_angle/2) * Mathf.PI) / 180f);
            float angleZ = _velocity.z - Mathf.Cos(((_angle/2) * Mathf.PI) / 180f);
            Vector3 ve = ( transform.position).normalized;
            _velocity = ve;

        }
        _canMove = true;
    }

    public void SetDirection(Vector3 _dir)
    {
        _velocity = _dir;
        _canMove = true;
    }

    public NodeBall GetTypeBall()
    {
        return _NodeBall;
    }
}