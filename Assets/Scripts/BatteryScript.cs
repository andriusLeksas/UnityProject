using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] float intensity = 1f;
    [SerializeField] Light myLight;
    // Update is called once per frame
    [SerializeField] float duration = 10.0f;
    [SerializeField] TMP_Text battery;
    void start()
    {
        myLight = this.gameObject.GetComponent<Light>();
    }
    void Update()
    {

            if (duration >= 0.0f)
        {
            myLight.intensity = Time.time * duration;
            duration = duration - 0.01f;
            battery.SetText("Battery: " + (duration * 10.0f).ToString());
            
        }
    }

    void onCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            duration = 10.0f;
            Debug.Log("picked up battery added extra time");
            Destroy(other.gameObject);
        }
    }
}
