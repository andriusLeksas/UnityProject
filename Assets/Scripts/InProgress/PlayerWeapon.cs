using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{
    int playerHealth = 10;
    float _nextFireTime;
    public AudioSource blasterShot;

    [SerializeField] float _delay = 0.25f;
    [SerializeField] BlasterShot _blasterShotPrefab;
    [SerializeField] LayerMask _aimLayerMask;
    [SerializeField] Transform _firePoint;

    List<Powerup> _powerups = new List<Powerup>();
    public void AddPowerup(Powerup powerup) => _powerups.Add(powerup);

    public void RemovePowerup(Powerup powerup) => _powerups.Remove(powerup);
    // Update is called once per frame

    void Update()
    {
        AimTowardMouse();
        if (ReadyToFire())
        {
            Fire();
        }
        
    }

    void AimTowardMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _aimLayerMask))
            {
                var destination = hitInfo.point;
                destination.y = transform.position.y;

                Vector3 direction = destination - transform.position;
                direction.Normalize();
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
    }

    bool ReadyToFire() => Time.time >= _nextFireTime;
    
    void Fire()
    {
        float delay = _delay;
        foreach (var powerup in _powerups)
            delay *= powerup.DelayMultiplier;

        _nextFireTime = Time.time + delay;
        BlasterShot shot = Instantiate(_blasterShotPrefab, _firePoint.position, 
            Quaternion.Euler(transform.forward + transform.right));
        shot.Launch(transform.forward);
        blasterShot.Play();

        if (_powerups.Any(t => t.SpreadShot))
        {
            shot = Instantiate(_blasterShotPrefab, _firePoint.position,
                Quaternion.Euler(transform.forward -transform.right));
            shot.Launch(transform.forward + transform.right);

            shot = Instantiate(_blasterShotPrefab, _firePoint.position,
                Quaternion.Euler(transform.forward -transform.right));
            shot.Launch(transform.forward -transform.right);

        }
    }
}
