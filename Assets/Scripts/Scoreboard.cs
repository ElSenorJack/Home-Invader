using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score; //se non si specifica un valore esso parte da 0
    TMP_Text scoreText; //TextMeshPro per Scrivere nell'UI

    private void Start()
    {
        scoreText = GetComponent < TMP_Text >();
        scoreText.text = "Start";
    }
    public void IncreaseScore(int ScoreAmount)
    {
        score += ScoreAmount;
        scoreText.text = score.ToString();
    }
}
