using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private int score = -1;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManager_OnCubeSpawned;
    }
    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSpawned;
    }

    private void GameManager_OnCubeSpawned()
    {
        score++;
        if(score>=0)
            text.text = "Score: " + score;
    }
}
