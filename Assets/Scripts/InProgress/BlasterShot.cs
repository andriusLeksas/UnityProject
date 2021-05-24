using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShot : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    // Start is called before the first frame update
    public void Launch(Vector3 direction)
    {
        direction.Normalize();
        transform.up = direction;
        GetComponent<Rigidbody>().velocity = direction * _speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void Start()
    {
       Destroy(gameObject, 6f);
    }
}
