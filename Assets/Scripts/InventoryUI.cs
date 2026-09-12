using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private TextMeshProUGUI woodText;

    [SerializeField]
    private TextMeshProUGUI clockPartText;

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // 木材の所持数を表示
        woodText.text = " × " + player.woodCount;

        // 時計の部品の所持数を表示
        clockPartText.text = " × " + player.clockPartCount;
    }
}