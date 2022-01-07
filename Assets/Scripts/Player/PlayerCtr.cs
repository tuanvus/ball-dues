using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : SingletonMonoBehavier<PlayerCtr>
{
    #region  rotateGun
    [Header("RotateGun")]
    [SerializeField] private float rotationRate = 3.0f;
    private float m_previousX;
    private float m_previousY;
    private Camera m_camera;
    private bool m_rotating = false;

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
            var deltaX = 0;
            var deltaY = (Input.mousePosition.x - m_previousX) * rotationRate;
            transform.Rotate(deltaX, deltaY, 0, Space.World);
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
            m_rotating = false;
    }
    void ShootHandler()
    {
        if (Input.GetMouseButtonUp(0) && canShoot)
        {
            canShoot = false;
            StartCoroutine(m_shoot);

        }
    }

    IEnumerator Shoot()
    {
        Debug.LogWarning("vao =" + limitBall);
        int countShoot = 0;
        while (countShoot < limitBall)
        {
            countShoot++;
            var ball = Instantiate(prefabBullet, tranGun.position, Quaternion.identity);
            ball.SetDirection(tranGun.forward);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;

    }


}
