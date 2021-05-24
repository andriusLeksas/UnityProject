using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static event Action Died;
    public AudioSource zombieSound;

    NavMeshAgent _navMeshAgent;
    NavMeshObstacle _navMesh;
    [SerializeField] float _attackRange = 1f;
    [SerializeField] int _health = 2;
    int _currentHealth;
    bool Alive => _currentHealth > 0;
    Slider slider;
    //public Transform other;
    Rigidbody rb;

    Animator _animator;
    private bool canAttack = true;

    void Awake()
    {
        slider = FindObjectOfType<Slider>();
        _currentHealth = _health;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        //_navMesh = GetComponent<NavMeshObstacle>();
    }

    void OnCollisionEnter(Collision collision)
    {
        var blasterShot = collision.collider.GetComponent<BlasterShot>();
        if(blasterShot!= null)
        {
            _currentHealth--;
            if(_currentHealth <= 0)
                Die();
                  
        }           
    }

    void Die()
    {
        GetComponent<Collider>().enabled = false;     
        _navMeshAgent.enabled = false;
        _animator.SetTrigger("Died");
        Died?.Invoke();
        Destroy(gameObject, 5f);        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Alive)
            return;

        var player = FindObjectOfType<PlayerMovement>();
        //if(_navMeshAgent.enabled)
        _navMeshAgent.SetDestination(player.transform.position);     
        
        //_navMeshAgent.SetDestination(transform.position);
        //if (Vector3.Distance(player.transform.position, transform.position) < 7)
        //{
            //rb.isKinematic = true;
            //_navMeshAgent.SetDestination(player.transform.position);   
        //}

        if (Vector3.Distance(transform.position, player.transform.position) < _attackRange && canAttack)
        {
            Attack();
            zombieSound.Play();
            StartCoroutine(wait());
        }            
    }

    private IEnumerator wait()
    {
        canAttack = false;
        // process pre-yield
        yield return new WaitForSeconds(1.0f);
        // process post-yield
        canAttack = true;
    }
    void Attack()
    {       
        _animator.SetTrigger("Attack");
        Debug.Log("Working AttackHit");
        slider.value -= 0.1f;
        if (!Alive)
            _navMeshAgent.enabled = false;      
    }
}
