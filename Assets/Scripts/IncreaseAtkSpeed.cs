using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IncreaseAtkSpeed : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Player picked attack speed powerup");
        }

    }

}
