using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtr : MonoBehaviour
{
    private const int LIMIT_ANGLE_Y = 55;

    public PlayerCtr playerCtr;
    
    [Header("RotateGun")] 
    [SerializeField] private float _rotationRate = 3.0f;
    private float _previousX;
    private float _previousY;
    private float _angleOrigin = -120;
    private float _deltaX;
    private float _deltaY;

    private  Camera _camera;
    private  bool _rotating = false;
    private bool _canRotation = true;

    void Start()
    {
        _camera = Camera.main;
        _angleOrigin = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        ShootBall();
    }
    
    void RotateGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rotating = true;
            _previousY = Input.mousePosition.y;
        }
        // get the user touch input
        if (Input.GetMouseButton(0))
        {
            _deltaX = 0;
            _deltaY = (Input.mousePosition.x - _previousX) * _rotationRate;
            var nextAngle = new Vector3(0, _angleOrigin + _deltaY, 0);

            // transform.Rotate(deltaX, deltaY, 0, Space.World);
            //}
            if (nextAngle.y < -LIMIT_ANGLE_Y)
            {
                nextAngle.y = -LIMIT_ANGLE_Y;
            }
            else if (nextAngle.y > LIMIT_ANGLE_Y)
            {
                nextAngle.y = LIMIT_ANGLE_Y;

            }

            _angleOrigin = nextAngle.y;
            transform.eulerAngles = nextAngle;
            _previousX = Input.mousePosition.x;
            _previousY = Input.mousePosition.y;

        }
        if (Input.GetMouseButtonUp(0))
            _rotating = false;

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Y " + _deltaY + " x " + _deltaX);

        }

    }

    void ShootBall()
    {
        if (playerCtr.CanShoot() && Input.GetMouseButtonUp(0))
        {
            playerCtr.ShootHandler();
        }
    }
}