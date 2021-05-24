using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text _scoreText;
    int _score;

    void Start()
    {
        Enemy.Died += Mummy_Died;
    }

    void Mummy_Died()
    {
        _score+=10;
        _scoreText.SetText("Kills: " + _score.ToString());
    }

}
