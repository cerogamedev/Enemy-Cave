using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform dragTransform;
    private Vector2 initialPosition;
    private Transform mousePos;
    public Image image;

    [HideInInspector] public Transform parentAfterDrug;
    private void Awake()
    {
        dragTransform = GetComponent<RectTransform>();
        initialPosition = dragTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrug = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)
    {
        dragTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop");
        Vector2 mousePos = Input.mousePosition;
        Debug.Log(mousePos.x);
        Debug.Log(mousePos.y);
        // Reset to initial position if not dropped on a valid target
        if (!eventData.pointerEnter)
        {
            dragTransform.anchoredPosition = initialPosition;
        }
        transform.SetParent(parentAfterDrug);
    }
}
