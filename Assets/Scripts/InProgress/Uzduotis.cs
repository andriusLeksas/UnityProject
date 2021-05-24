using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzduotis : MonoBehaviour
{

    bool move = false;

    void Update()
    {
        if(move == true)
        {
            this.gameObject.transform.Translate(0, 1 * Time.deltaTime,0); ;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player")) {
            GetComponent<Renderer>().material.color = new Color(0,255,0);
            move = true;
            Debug.Log(move);
        }        
    }

}
