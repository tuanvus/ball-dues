using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeBall
{
    player, enemy
}

public class Ball : MonoBehaviour
{
    public List<int> listIdDoor;
    [SerializeField] TypeBall typeBall;
    [Header("Movement")]
    float angle = 5f;

    bool canMove = false;
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]

    Vector3 velocity, desiredVelocity;
    void Start()
    {
    }
    public void SetDirectionWithSpawn(int i)
    {
        if (i % 2 == 0)
        {
            float projectileDirXPosition = velocity.x * Mathf.Cos((i / 2 * angle * Mathf.PI) / 180) - velocity.z * Mathf.Sin((i / 2 * angle * Mathf.PI) / 180);
            float projectileDirYPosition = velocity.x * Mathf.Sin((i / 2 * angle * Mathf.PI) / 180) + velocity.z * Mathf.Cos((i / 2 * angle * Mathf.PI) / 180);
            Vector3 ballnew1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            velocity = new Vector3(projectileDirXPosition, 0.1f, projectileDirYPosition);
        }
        else
        {
            float projectileDirXPosition = velocity.x * Mathf.Cos((-(i - 1) / 2 * angle * Mathf.PI) / 180) - velocity.z * Mathf.Sin((-(i - 1) / 2 * angle * Mathf.PI) / 180);
            float projectileDirYPosition = velocity.x * Mathf.Sin((-(i - 1) / 2 * angle * Mathf.PI) / 180) + velocity.z * Mathf.Cos((-(i - 1) / 2 * angle * Mathf.PI) / 180);
            Vector3 ballnew1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            velocity = new Vector3(projectileDirXPosition, 0.1f, projectileDirYPosition);
        }
        canMove = true;

    }
    public void SetDirection(Vector3 _dir)
    {
        velocity = _dir;
        canMove = true;
    }
    private void FixedUpdate()
    {
        if (!canMove) return;
        if (MapCtr.Instance.CheckWallLeft(transform.position))
        {
            velocity = new Vector3(Mathf.Abs(velocity.x), velocity.y, velocity.z);
        }
        if (MapCtr.Instance.CheckWallRight(transform.position))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);

        }
        desiredVelocity = velocity * maxSpeed;

        transform.position += desiredVelocity * Time.deltaTime;

    }
    public TypeBall GetTypeBall()
    {
        return typeBall;
    }

}
