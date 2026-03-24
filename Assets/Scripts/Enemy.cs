using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _direction;


    public void Init(Vector3 direction)
    {
        _direction = direction;
    }
}
