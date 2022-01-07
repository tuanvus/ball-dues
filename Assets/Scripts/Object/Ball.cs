using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeBall
{
    player, enemy
}

public class Ball : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] TypeBall typeBall;
    [Header("Movement")]
    bool canMove = false;
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;


    Vector3 velocity, desiredVelocity;
    bool desiredJump;
    [SerializeField]
    Rect allowedArea = new Rect(-15f, -15f, 20f, 20f);
    [SerializeField, Range(0f, 1f)]
    float bounciness = 1f;


    void Start()
    {

    }
    public void SetDirection(Vector3 _dir)
    {
        velocity = _dir;
        canMove = true;
    }
    private void FixedUpdate()
    {
         if(!canMove ) return;
        desiredVelocity = velocity * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x =
            Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z =
            Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);


        Vector3 newPosition = transform.localPosition + velocity;
        transform.position+= velocity * Time.deltaTime;

    }
    public TypeBall GetTypeBall()
    {
        return typeBall;
    }

}
