using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    private float _duration = 8f;
    [SerializeField] float _delayMultiplier = 0.5f;
    private float _cooldoawn = 5f;
    [SerializeField] bool _spreadShot = false;

    public AudioSource noiceSound;

    [SerializeField] Transform[] _spawnPoints;
    public float DelayMultiplier => _delayMultiplier;

    public bool SpreadShot => _spreadShot;

    void OnTriggerEnter(Collider other)
    {
        
        var playerWeapon = other.GetComponent<PlayerWeapon>();
        if (playerWeapon)
        {            
            playerWeapon.AddPowerup(this);
            StartCoroutine(DisableAfterDelay(playerWeapon));
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            noiceSound.Play();
        }
    }

    IEnumerator DisableAfterDelay(PlayerWeapon playerWeapon)
    {
        yield return new WaitForSeconds(_duration);
        playerWeapon.RemovePowerup(this);
        yield return new WaitForSeconds(_cooldoawn);

        int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        //transform.position = _spawnPoints[randomIndex].position;
        GetComponent<Collider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
    }
}
