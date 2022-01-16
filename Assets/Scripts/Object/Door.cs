using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour, ICollision
{
    private const float MAX_DISTANCE = 5F;

    public List<Color> colorDoorList;
    public TextMeshPro textIDDoor;
    public int id;


    [SerializeField] private LayerMask _TargetLayerMask;
    private bool _isBall = false;
    private bool _hitDetect;
    private RaycastHit _Hit;
    private Collider[] _hitColliders;

    private Ball _ball;

    private void Start()
    {
        //textIDDoor = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        CheckDistanceBall();
    }

    void CheckDistanceBall()
    {
        _hitDetect = Physics.BoxCast(transform.position, Vector3.one,
            transform.forward, out _Hit, transform.rotation, MAX_DISTANCE);

        if (_hitDetect)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + _Hit.collider.name);
            _hitColliders = Physics.OverlapBox(transform.position, Vector3.one * MAX_DISTANCE, Quaternion.identity,
                _TargetLayerMask);
            HandObject();
        }
    }

//    void HandObject()
//    {
//    
//    }

    public void HandObject()
    {
        Debug.Log("ko vao " + _hitColliders.Length);
        for (int i = 0; i < _hitColliders.Length; i++)
        {
            _ball = _hitColliders[i].GetComponent<Ball>();
            if (!_ball.HasCollisionDoor(id))
            {
                Debug.Log("log v =" + _ball.GetVelocity());
                _ball.AddID_Door(id);
                var newball = CreatorCtr.Instance.CreatorBallHell(_ball.transform.position, i, id);

                // newball.SetDirection(ball.transform.forward);
            }
        }
    }
}