using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _speed = 5f;
    float jumpPower = 100f;
    Animator _animator;
    [SerializeField] GameObject pl;
    public AudioSource moveSound;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //Shorthand for writing Vector3(0, 1, 0).


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal == 0 || vertical== 0)
        {
            moveSound.Play();
        }
        _animator.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
        _animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement *= Time.deltaTime * _speed;
        transform.Translate(movement, Space.World);
        //dampTime and deltaTime are used to smooth the transition between animations 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }


    }

}
