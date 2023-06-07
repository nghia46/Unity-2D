using UnityEngine;

public class DragAndSnap : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isDragging = false;
    private float snapThreshold = 0.5f;

    private void OnMouseDown()
    {
        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Snap to nearest grid position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, snapThreshold);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("GridCell"))
            {
                transform.position = collider.transform.position;
                return;
            }
        }

        // Snap back to original position if no valid grid cell found
        transform.position = originalPosition;
    }
}
