using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCtr : SingletonMonoBehavier<PlayerCtr>
{

    #region  rotateGun
    [Header("RotateGun")]
    [SerializeField] float limitAngleY;
    [SerializeField] private float rotationRate = 3.0f;
    float m_previousX;
    float m_previousY;
    float AngleOrigin = -120;
    float deltaX;
    float deltaY;

    Camera m_camera;
    bool m_rotating = false;
    bool canRotation = true;

    #endregion

    #region  ShootBall
    [Header("ShootBall")]
    public int currentBall = 1;
    [SerializeField] int limitBall;

    [SerializeField] Transform tranGun;
    [SerializeField] Ball prefabBullet;
    IEnumerator m_shoot;

    bool canShoot = true;

    float timeDelay = 0.2f;
    float timeShoot = 0;

    int ballCount = 0;
    #endregion
    void Start()
    {
        m_camera = Camera.main;
        AngleOrigin = transform.eulerAngles.y;
    }
    public void SetCurrentBall()
    {
        currentBall++;
        if (currentBall >= limitBall)
        {
            canShoot = true;
            ballCount = 0;

        }
    }




    void Update()
    {
        RotateGun();
        ShootHandler();
    }
    void RotateGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_rotating = true;
            m_previousY = Input.mousePosition.y;
        }
        // get the user touch input
        if (Input.GetMouseButton(0))
        {
            deltaX = 0;
            deltaY = (Input.mousePosition.x - m_previousX) * rotationRate;
            var v3 = new Vector3(0, AngleOrigin + deltaY, 0);

            // transform.Rotate(deltaX, deltaY, 0, Space.World);
            //}
            if (v3.y < -55)
            {
                v3.y = -55;
            }
            else if (v3.y > 55)
            {
                v3.y = 55;

            }

            AngleOrigin = v3.y;
            transform.eulerAngles = v3;
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;

        }
        if (Input.GetMouseButtonUp(0))
            m_rotating = false;

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Y " + deltaY + " x " + deltaX);

        }

    }
    void ShootHandler()
    {
        if (Input.GetMouseButtonUp(0) && canShoot)
        {
            Debug.Log("vaoooo shot");
            canShoot = false;

        }
        if (ballCount < limitBall && !canShoot)
        {
            timeShoot += Time.deltaTime;
            if (timeShoot >= timeDelay)
            {
                timeShoot = 0;
                ballCount++;
                var ball = CreatorCtr.Instance.CreatorBall(tranGun.position);
                ball.SetDirection(tranGun.forward);
            }

        }

    }


}
