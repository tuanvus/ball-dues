using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstanceCtr : MonoBehaviour, ICollision
{
    [SerializeField] private Collider _Collider;
    [SerializeField] private LayerMask _TargetLayerMask;
    private bool _isBall = false;
    private bool _hitDetect;
    private RaycastHit _Hit;
    private Collider[] _hitColliders;
    private Ball _ball;

    void Start()
    {
        _Collider = GetComponent<Collider>();
    }

    private void Update()
    {
        CheckDistanceBall();
    }

    void CheckDistanceBall()
    {
        //Output the name of the Collider your Box hit
        _hitColliders = Physics.OverlapBox(transform.position, new Vector3(1,1,1*5), Quaternion.identity, _TargetLayerMask);
        HandObject();
    }

    public void HandObject()
    {
        Debug.Log("log v =" + _hitColliders.Length);

        for (int i = 0; i < _hitColliders.Length; i++)
        {
            _ball = _hitColliders[i].GetComponent<Ball>();
            
        }
    }

    private void OnDrawGizmos()
    {
        
            Gizmos.color = Color.green;

        Gizmos.DrawCube(transform.position, new Vector3(1,1,1*5));
        //Gizmos.DrawCube(transform.position,transform.localScale);
    }
}