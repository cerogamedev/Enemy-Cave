using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTourManager : MonoBehaviour
{
    public static int tourNumb;
    public RectTransform[] imageRect;
    public RectTransform[] HandRect;

    public GameObject EnemyCard;
    public GameObject Card;

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
        PlayedCards();
        if (DragAndDrop.nextTourCounter == 0)
            NextTourButton.SetActive(true);
        else
            NextTourButton.SetActive(false);


    }
    public void NextTour()
    {
        DragAndDrop.nextTourCounter = 4;
        tourNumb += 1;
        TotalTourDamage();
        RandomEnemyCardCreate();
        GetCardsFromDeck();

    }
    void GetCardsFromDeck()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Hand");

        HandRect = new RectTransform[taggedObjects.Length];

        for (int i = 0; i < taggedObjects.Length; i++)
        {
            HandRect[i] = taggedObjects[i].GetComponent<RectTransform>();
            Instantiate(Card, HandRect[i].transform);

        }

    }
    void RandomEnemyCardCreate()
    {
        int RandomTotal = 0;
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyCard");
        for (int i = 0; i < taggedObjects.Length; i++)
        {
            RandomTotal += taggedObjects[i].GetComponent<Enemy>().attackInt;
            
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
    void PlayedCards()
    {
        GameObject[] playedCards = GameObject.FindGameObjectsWithTag("PlayedCard");
        //grave götür sakla

    }
    void TotalTourDamage()
    {

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyCard");
        for (int i = 0; i < taggedObjects.Length; i++)
        {
            int damage = taggedObjects[i].GetComponent<Enemy>().attackInt;
            Health.Instance.SetHealth(-damage);
        }
    }
}
