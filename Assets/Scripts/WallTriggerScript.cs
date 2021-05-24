using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject Door;
    // Start is called before the first frame update
    bool opened = false;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!opened)
            {           
                Door.SetActive(false);
                opened = true;
            }         
            else if (opened) {               
                Door.SetActive(true);
                opened = false;
            }
           
        }
    }
}
