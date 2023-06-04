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


        for (int i = 0; i < 4; i++)
        {
            GameObject[] _card = GameObject.FindGameObjectsWithTag("InsideDeck");
            int RandomCardNumber = Random.Range(0, _card.Length);
            HandRect[i] = taggedObjects[i].GetComponent<RectTransform>();
            _card[RandomCardNumber].transform.SetParent(HandRect[i]);
            _card[RandomCardNumber].transform.tag = "PlayinCard";
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
            taggedObjects[i].GetComponent<Enemy>().inGameDamageCountdown -= 1;
            if (taggedObjects[i].GetComponent<Enemy>().inGameDamageCountdown == 0)
            {
                int damage = taggedObjects[i].GetComponent<Enemy>().healthInt;
                taggedObjects[i].GetComponent<Enemy>().inGameDamageCountdown = taggedObjects[i].GetComponent<Enemy>()._DamageCountdown;
                for (int j = 0; j < damage; j++)
                {
                    if (Health.Instance.mainArmor == 0)
                    {
                        Health.Instance.SetHealth(-1);
                    }
                    else
                    {
                        Health.Instance.SetArmor(-1);
                    }
                }
            }

        }
    }
}
