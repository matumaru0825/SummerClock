using UnityEngine;
using UnityEngine.InputSystem;
public class WorkBench : MonoBehaviour
{
    private bool canUse = false;
    private PlayerController player;
    private void Update()
    {
        // 作業台を使える状態でEを押した
        if (canUse && Keyboard.current.eKey.wasPressedThisFrame)
        {
            CreateClockPart();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Playerが作業台の範囲に入った
        if (other.CompareTag("Player"))
        {
            canUse = true;
            player = other.GetComponent<PlayerController>();
            Debug.Log("作業台を使えるようになった！");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Playerが作業台から離れた
        if (other.CompareTag("Player"))
        {
            canUse = false;
            player = null;
            Debug.Log("作業台から離れた");
        }
    }
    private void CreateClockPart()
    {
        // Playerが見つかっていない場合
        if (player == null)
        {
            return;
        }
        // 木材が3個以上あるか確認
        if (player.woodCount >= 3)
        {
            // 木材を3個使う
            player.UseWoodForClockPart();
            // 時計の部品を1個追加
            player.AddClockPart();
            Debug.Log("時計の部品を作成しました！");
        }
        else
        {
            Debug.Log("木材が足りません！ 木材が3個必要です。");
        }
    }
}