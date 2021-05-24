using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public float playerHealth = 10f;
    public Image fillimage;
    private Slider slider;
    public GameEnd gameEnd;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
