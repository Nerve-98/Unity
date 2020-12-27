using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject} !");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name} !");
    }


    void Start()
    {
        
    }

    void Update()
    {
        /*
        Vector3 look = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);


        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Raycast {hit.collider.gameObject.name}!");
        }
        */
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);


            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            //int mask = (1 << 8) | (1 << 9);


            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask))
            {

                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");

            }
        }

    }
}
