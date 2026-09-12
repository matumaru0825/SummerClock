using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    // 制限時間（秒）
    [SerializeField]
    private float timeLimit = 180f;

    // 残り時間
    private float remainingTime;

    // UIに表示するText
    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private GameObject gameOverPanel;
    // 時間切れになったか
    private bool timeUp = false;

    private void Start()
    {
        // 最初は制限時間からスタート
        remainingTime = timeLimit;

        UpdateTimerText();
    }

    private void Update()
    {
        if (timeUp)
        {
            return;
        }

        // 時間を減らす
        remainingTime -= Time.deltaTime;

        // 0秒以下にならないようにする
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            timeUp = true;

            UpdateTimerText();

            TimeUp();
            return;
        }

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        // 分
        int minutes = Mathf.FloorToInt(remainingTime / 60);

        // 秒
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // 02:59 のような表示にする
        timerText.text = string.Format(
            "{0:00}:{1:00}",
            minutes,
            seconds
        );
    }

    private void TimeUp()
    {
        Debug.Log("時間切れ！");

        gameOverPanel.SetActive(true);
    }
}