using UnityEngine;

public class Animation_ : MonoBehaviour
{
    [SerializeField] private string targetTag; // Tag to check for
    [SerializeField] private Sprite newSprite; // New sprite to assign

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object's tag matches the serialized target tag
        if (other.CompareTag(targetTag))
        {
            // Get the SpriteRenderer of the parent object
            SpriteRenderer spriteRenderer = other.GetComponentInParent<SpriteRenderer>();

            // Check if the SpriteRenderer exists to avoid null reference errors
            if (spriteRenderer != null)
            {
                // Assign the new sprite
                spriteRenderer.sprite = newSprite;
            }
        }
    }
}
