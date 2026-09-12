using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 moveInput;

    public int woodCount = 0;

    public int clockPartCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            moveInput.y += 1;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            moveInput.y -= 1;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            moveInput.x -= 1;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            moveInput.x += 1;
        }

        moveInput = moveInput.normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + moveInput * moveSpeed * Time.fixedDeltaTime
        );
    }

    public void AddWood()
    {
        woodCount++;

        Debug.Log("木材を拾った！現在の木材数" + woodCount);
    }

    public void AddClockPart()
    {
        clockPartCount++;

        Debug.Log("部品を拾った！現在の部品数" + clockPartCount);
    }

    public void UseWoodForClockPart()
    {
        woodCount -= 3;

        Debug.Log("木材を使った！残り" + woodCount);
    }
}