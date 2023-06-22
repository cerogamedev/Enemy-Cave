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

    public bool beginDrag = false;

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
        beginDrag = true;
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
                    if (this.gameObject.GetComponent<WarriorUpgrades>().warriorUpgrade3)
                        Health.Instance.SetHealth(+3);
                }
                Health.Instance.SetArmor(this.gameObject.GetComponent<Card>().healthInt);
                if (this.gameObject.GetComponent<WarriorUpgrades>().warriorAllowDefence2)
                {
                    this.gameObject.GetComponent<WarriorUpgrades>().warriorUpgradeDefence2 = true;
                }
                if (this.gameObject.GetComponent<WarriorUpgrades>().warriorAllowDefence4)
                {
                    this.gameObject.GetComponent<WarriorUpgrades>().warriorUpgradeDefence4 = true;
                }
                if (this.gameObject.GetComponent<WarriorUpgrades>().warriorUpgradeDefence5)
                {
                    WarriorUpgrades.spike += 2;
                }
                if (this.gameObject.GetComponent<WarriorUpgrades>().warriorUpgradeDefence3)
                {
                    nextTourCounter -= 1;
                    GameObject[] _playinCards = GameObject.FindGameObjectsWithTag("PlayinCard");
                    for (int j =0;j<_playinCards.Length;j++)
                    {
                        if (_playinCards[i].GetComponent<Card>().isDefence)
                        {
                            _playinCards[i].tag = "PlayedCard";
                        }
                    }
                }
            }
        }

        // Reset to initial position if not dropped on a valid target
        if (!eventData.pointerEnter)
        {
            dragTransform.anchoredPosition = initialPosition;
        }
        transform.SetParent(parentAfterDrug);
        beginDrag = false;
    }

}
