using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    // bool _moveToDest = false;
    Vector3 _destPos;


    void Start()
    {
        //Manager.input.KeyAction -= OnKeyBoard;
        //Manager.input.KeyAction += OnKeyBoard;
        Manager.input.MouseAction -= OnMouseClicked;
        Manager.input.MouseAction += OnMouseClicked;

    }





    public enum PlayerState
    {
        Die,
        Moving,
        Idle
    }

    PlayerState _state = PlayerState.Idle;

    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.01f)
        {
            //_moveToDest = false;
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        // animation
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {

        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }

    void Update()
    {
        /*
        if(_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;
            if(dir.magnitude < 0.01f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }
        */


        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

        /*
        if(_moveToDest)
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);

            anim.Play("WAIT_RUN");

        }
        else
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            anim.Play("WAIT_RUN");

        }
        */


    }
    /*
    void OnKeyBoard()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        _moveToDest = false;

    }
    */
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);


        LayerMask mask = LayerMask.GetMask("Wall");
        //int mask = (1 << 8) | (1 << 9);

        
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
            //Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");

        }
        
    }

}
