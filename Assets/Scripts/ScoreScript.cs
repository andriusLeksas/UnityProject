using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public AudioSource pickUp;
    AudioClip cl;
    [SerializeField] TMP_Text _scoreText;
    int _score;
    [SerializeField] ParticleSystem ParticleSystemPrefab;

    void start()
    {
        pickUp = GetComponent<AudioSource>();
    }
    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(ParticleSystemPrefab, contact.point, Quaternion.identity);
            }
            pickUp.Play();
            //Destroy(collision.gameObject);
            Debug.Log("Player picked PowerUp");
            add_Score();
        }

    }

    void add_Score()
    {
        _score++;
        _scoreText.SetText("Score: " + _score.ToString());
    }

}