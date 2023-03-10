using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private bool _isInside = false;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed*Time.deltaTime);        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
