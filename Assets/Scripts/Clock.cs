using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Clock : MonoBehaviour
{
    // Playerが時計の近くにいるか
    private bool canRepair = false;

    // Player
    private PlayerController player;

    // 時計の針
    [SerializeField]
    private Transform hourHand;

    [SerializeField]
    private Transform minuteHand;

    [SerializeField]
    private GameObject summerBackground;

    [SerializeField]
    private GameObject autumnBackground;

    [SerializeField]
    private GameObject clearPanel;

    // クリアしたか
    private bool isRepaired = false;

    private void Update()
    {
        // 時計の近くにいて、Eを押した
        if (canRepair &&
            Keyboard.current.eKey.wasPressedThisFrame &&
            !isRepaired)
        {
            RepairClock();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Playerが時計の範囲に入った
        if (other.CompareTag("Player"))
        {
            canRepair = true;

            player = other.GetComponent<PlayerController>();

            Debug.Log("時計を修理できます！");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Playerが時計から離れた
        if (other.CompareTag("Player"))
        {
            canRepair = false;

            player = null;
        }
    }

    private void RepairClock()
    {
        // Playerがいない
        if (player == null)
        {
            return;
        }

        // 時計の部品が1個以上あるか
        if (player.clockPartCount >= 1)
        {
            // 部品を1個消費
            player.clockPartCount--;

            Debug.Log("時計の部品を使いました！");

            // 修理済みにする
            isRepaired = true;

            // 時計を動かす
            StartCoroutine(MoveClockHands());

            // クリア処理
            StartCoroutine(ClearGame());
        }
        else
        {
            Debug.Log("時計の部品がありません！");
        }
    }

    private IEnumerator MoveClockHands()
    {
        float duration = 2f;
        float elapsed = 0f;

        float startHour = hourHand.localEulerAngles.z;
        float startMinute = minuteHand.localEulerAngles.z;

        float targetHour = startHour - 90f;
        float targetMinute = startMinute - 720f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / duration;

            hourHand.localRotation =
                Quaternion.Euler(
                    0f,
                    0f,
                    Mathf.Lerp(startHour, targetHour, t)
                );

            minuteHand.localRotation =
                Quaternion.Euler(
                    0f,
                    0f,
                    Mathf.Lerp(startMinute, targetMinute, t)
                );

            yield return null;
        }
    }

    private IEnumerator ClearGame()
    {
        // 時計が動くのを少し見せる
        yield return new WaitForSeconds(2.5f);

        summerBackground.SetActive(false);

        autumnBackground.SetActive(true);

        Debug.Log("CLEAR!");

        // ここでクリア画面を表示する
        clearPanel.SetActive(true);
    }
    
}