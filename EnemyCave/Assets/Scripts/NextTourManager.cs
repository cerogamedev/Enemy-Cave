using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTourManager : MonoBehaviour
{
    public static int tourNumb;
    public RectTransform[] imageRect;
    public RectTransform[] HandRect;

    public GameObject EnemyCard;

    public GameObject NextTourButton;

    void Start()
    {
        tourNumb = 0;
        NextTourButton.SetActive(false);
    }

    void Update()
    {        
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Slot");

        imageRect = new RectTransform[taggedObjects.Length];

        for (int i = 0; i < taggedObjects.Length; i++)
        {
            imageRect[i] = taggedObjects[i].GetComponent<RectTransform>();
        }
        if (DragAndDrop.nextTourCounter == 0)
            NextTourButton.SetActive(true);
        else
            NextTourButton.SetActive(false);


    }
    public void NextTour()
    {
        GameObject[] card = GameObject.FindGameObjectsWithTag("PlayinCard");

        for (int i = 0; i < card.Length; i++)
        {
            card[i].SetActive(false);
            card[i].transform.tag = "PlayedCard";
        }
        DragAndDrop.nextTourCounter = 2;
        TotalTourDamage();
        RandomEnemyCardCreate();
        GetCardsFromDeck();

    }
    void GetCardsFromDeck()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Hand");

        HandRect = new RectTransform[taggedObjects.Length];

        GameObject[] card = GameObject.FindGameObjectsWithTag("InsideDeck");

        for (int i = 0; i < 4; i++)
        {
            HandRect[i] = taggedObjects[i].GetComponent<RectTransform>();
            card[i].transform.tag = "PlayinCard";
            card[i].transform.SetParent(HandRect[i]);
        }
    }
    void RandomEnemyCardCreate()
    {
        int RandomTotal = 0;
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyCard");
        for (int i = 0; i < taggedObjects.Length; i++)
        {
            RandomTotal += taggedObjects[i].GetComponent<Enemy>().healthInt;
            
        }
        if (imageRect.Length > 0)
        {
            int randomnumber = Random.Range(0, imageRect.Length);
            Instantiate(EnemyCard, imageRect[randomnumber].transform);
            imageRect[randomnumber].transform.tag = "Close";
        }
        else
            return;
    }

    void TotalTourDamage()
    {

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyCard");
        for (int i = 0; i < taggedObjects.Length; i++)
        {
            int damage = taggedObjects[i].GetComponent<Enemy>().healthInt;
            Health.Instance.SetHealth(-damage);
        }
    }
}
