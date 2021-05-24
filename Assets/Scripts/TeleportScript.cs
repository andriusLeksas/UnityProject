using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] Transform spawn;
    public AudioSource teleportSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            other.transform.position = spawn.position;
            Debug.Log("Teleported");
            teleportSound.Play();
        }
    }
}
