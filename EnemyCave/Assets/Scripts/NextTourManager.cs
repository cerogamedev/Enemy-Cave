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

    public bool isFinished = false;

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
        if (DragAndDrop.nextTourCounter <= 0)
            NextTourButton.SetActive(true);
        else
            NextTourButton.SetActive(false);
        GetCardFromDeckUpdateVers();
    }
    
    public void NextTour()
    {
        StartCoroutine(RunFunctions());

    }
    private System.Collections.IEnumerator RunFunctions()
    {
        yield return StartCoroutine(TotalTourDamage());

        yield return StartCoroutine(PlayincardToPlayedCard());

        yield return StartCoroutine(WarriorDefence2Upgrade());

        yield return StartCoroutine(RandomEnemyCardCreate());

        yield return StartCoroutine(GetCardsFromDeck());
    }
    private System.Collections.IEnumerator PlayincardToPlayedCard()
    {
        GameObject[] card = GameObject.FindGameObjectsWithTag("PlayinCard");

        for (int i = 0; i < card.Length; i++)
        {
            card[i].SetActive(false);
            card[i].transform.tag = "PlayedCard";
        }
        DragAndDrop.nextTourCounter = 2;
        yield return null;
    }
    private System.Collections.IEnumerator GetCardsFromDeck()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Hand");

        HandRect = new RectTransform[taggedObjects.Length];


        for (int i = 0; i < 4; i++)
        {
            GameObject[] _card = GameObject.FindGameObjectsWithTag("InsideDeck");
            int RandomCardNumber = Random.Range(0, _card.Length);
            HandRect[i] = taggedObjects[i].GetComponent<RectTransform>();
            _card[RandomCardNumber].transform.tag = "PlayinCard";

            float step = 1250f * Time.deltaTime;
            _card[RandomCardNumber].transform.position = Vector3.MoveTowards(_card[RandomCardNumber].transform.position, taggedObjects[i].transform.position, step);

            if (_card[RandomCardNumber].transform.position.x == taggedObjects[i].transform.position.x)
            {
                _card[RandomCardNumber].transform.SetParent(HandRect[i]);
            }
            
        }
        yield return null;
    }
    void GetCardFromDeckUpdateVers()
    {
        GameObject[] _playingcard = GameObject.FindGameObjectsWithTag("PlayinCard");
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Hand");
        HandRect = new RectTransform[taggedObjects.Length];

        float step = 1250f * Time.deltaTime;
        for(int i = 0; i<_playingcard.Length; i++)
        {
            if (_playingcard[i].GetComponent<DragAndDrop>().beginDrag == false)
            {
                _playingcard[i].transform.position = Vector3.MoveTowards(_playingcard[i].transform.position, taggedObjects[i].transform.position, step);

            }
        }


    }


    private System.Collections.IEnumerator RandomEnemyCardCreate()
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


        yield return null;
    }

    private System.Collections.IEnumerator TotalTourDamage()
    {

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyCard");
        for (int i = 0; i < taggedObjects.Length; i++)
        {
            taggedObjects[i].GetComponent<Enemy>().inGameDamageCountdown -= 1;
            if (taggedObjects[i].GetComponent<Enemy>().inGameDamageCountdown == 0)
            {
                taggedObjects[i].GetComponent<Enemy>().SetHealth(-WarriorUpgrades.spike);
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
        yield return null;
    }
    private System.Collections.IEnumerator WarriorDefence2Upgrade()
    {
        GameObject[] _playedCard = GameObject.FindGameObjectsWithTag("PlayedCard");
        for (int i=0; i<_playedCard.Length;i++)
        {
            if (_playedCard[i].GetComponent<WarriorUpgrades>().warriorUpgradeDefence2 && Health.Instance.GetArmor()>0)
            {
                Health.Instance.SetArmor(+2);
                _playedCard[i].GetComponent<WarriorUpgrades>().warriorUpgradeDefence2 = false;
            }
        }
        yield return null;
    }
    private System.Collections.IEnumerator WarriorDefence4Upgrade()
    {
        GameObject[] _playedCard = GameObject.FindGameObjectsWithTag("PlayedCard");
        for (int i = 0; i < _playedCard.Length; i++)
        {
            if (_playedCard[i].GetComponent<WarriorUpgrades>().warriorUpgradeDefence4)
            {
                Health.Instance.SetHealth(+3);
                _playedCard[i].GetComponent<WarriorUpgrades>().warriorUpgradeDefence4 = false;
            }
        }
        yield return null;
    }
}
