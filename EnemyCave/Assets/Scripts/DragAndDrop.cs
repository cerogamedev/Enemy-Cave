using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static int nextTourCounter = 2;

    private RectTransform dragTransform;
    private Vector2 initialPosition;
    public RectTransform [] imageRect;

    public Canvas canvas;
    public Camera mainCamera;
    public int usingNumber = 0;

    [HideInInspector] public Transform parentAfterDrug;
    private void Awake()
    {
        
        dragTransform = GetComponent<RectTransform>();
        initialPosition = dragTransform.anchoredPosition;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Close");

        imageRect = new RectTransform[taggedObjects.Length];

        for (int i = 0; i < taggedObjects.Length; i++)
        {
            imageRect[i] = taggedObjects[i].GetComponent<RectTransform>();
        }

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
        for (int i = 0; i < imageRect.Length; i++)
        {
            RectTransform currentObject = imageRect[i];

            // Objeleri iþleme
            Vector2 localMousePosition = imageRect[i].InverseTransformPoint(Input.mousePosition);
            if (imageRect[i].rect.Contains(localMousePosition))
            {
                Debug.Log(gameObject.name + " Inside " + currentObject.name);
                this.gameObject.tag = "PlayedCard";
                usingNumber += 1;
                nextTourCounter -= 1;

                //enemy cards destroy here -->> change it
                //Object.Destroy(currentObject.transform.GetChild(0).gameObject);
                currentObject.transform.GetChild(0).GetComponent<Enemy>().SetHealth(-this.gameObject.GetComponent<Card>().GetAttack());
                if (2*currentObject.transform.GetChild(0).GetComponent<Enemy>().healthInt <= this.gameObject.GetComponent<Card>().attackInt)
                {
                    currentObject.transform.tag = "Slot";
                }
                Health.Instance.SetArmor(this.gameObject.GetComponent<Card>().healthInt);
            }
        }
        // Reset to initial position if not dropped on a valid target
        if (!eventData.pointerEnter)
        {
            dragTransform.anchoredPosition = initialPosition;
        }
        transform.SetParent(parentAfterDrug);
    }

}
