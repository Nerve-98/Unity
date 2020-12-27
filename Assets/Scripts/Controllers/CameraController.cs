using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta;

    [SerializeField]
    GameObject _player;


    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform);
    }
}
