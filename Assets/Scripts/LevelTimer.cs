using System;
using TMPro;
using UnityEngine;


// Kernighan Mitchell
public class LevelTimer : MonoBehaviour {
    [SerializeField] float seconds = 30f;
    float timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] PlayerBehaviour playerBehaviour;

    private void Start() {
        timer = seconds;
    }

    // Update is called once per frame
    void Update() {
        if (timer < 0) {
            timerText.text = "TIME UP";
            playerBehaviour.die();
            timer = seconds;
        } else {
            timer -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Round(timer).ToString();
        }
    }
}
