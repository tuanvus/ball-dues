using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCtr : SingletonMonoBehavier<PlayerCtr>
{
    public Text text;


    #region  rotateGun
    [Header("RotateGun")]
    [SerializeField] float limitAngleY;
    [SerializeField] private float rotationRate = 3.0f;
    float m_previousX;
    float m_previousY;

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
    #endregion
    void Start()
    {
        m_shoot = Shoot();
        m_camera = Camera.main;

    }
    public void SetCurrentBall()
    {
        currentBall++;
        if (currentBall >= limitBall)
        {
            canShoot = true; ;
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
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }
        // get the user touch input
        if (Input.GetMouseButton(0))
        {
            deltaX = 0;
            deltaY = (Input.mousePosition.x - m_previousX) * rotationRate;
            transform.Rotate(deltaX, deltaY, 0, Space.World);
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
            //}

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
            canShoot = false;
            StartCoroutine(m_shoot);

        }
        if (Input.GetMouseButtonUp(0))
        {
            // var ball = Instantiate(prefabBullet, tranGun.position, Quaternion.identity);
            // ball.SetDirection(tranGun.forward);
            // Debug.Log("tranGun.forward " + tranGun.forward);
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Debug.LogWarning("vao =" + limitBall);
        int countShoot = 0;
        // while (countShoot < limitBall)
        // {
        for (int i = 0; i < 5; ++i)
        {
            var ball = Instantiate(prefabBullet, tranGun.position, Quaternion.identity);
            ball.SetDirection(tranGun.forward);
            ball.SetDirectionWithSpawn(i);

        }
        yield return new WaitForSeconds(0.2f);

        // }
        // yield return null;

    }


}
