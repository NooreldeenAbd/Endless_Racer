using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    [SerializeField] public float scoreMultiplier;
    private float score = 0;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        float scoreDisplay = Mathf.Round(score);
        scoreText.text = $"{scoreDisplay} m";
    }
}
