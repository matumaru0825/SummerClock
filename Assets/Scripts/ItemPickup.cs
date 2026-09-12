using UnityEngine;
using UnityEngine.InputSystem;
public class ItemPickup : MonoBehaviour
{
    private bool canPickup = false;
    private PlayerController player;
    private void Update()
    {
        if (canPickup && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Pickup();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = true;
            player = other.GetComponent<PlayerController>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
            player = null;
        }
    }
    private void Pickup()
    {
        if (player != null)
        {
            player.AddWood();
            Destroy(gameObject);
        }
    }
}