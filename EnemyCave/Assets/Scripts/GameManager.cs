using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] playedCard = GameObject.FindGameObjectsWithTag("PlayedCard");
        GameObject Grave = GameObject.FindGameObjectWithTag("Grave");
        for (int i = 0; i < playedCard.Length; i++)
        {
            playedCard[i].transform.position = Grave.transform.position;
            playedCard[i].transform.SetParent(Grave.transform);
            playedCard[i].GetComponent<DragAndDrop>().enabled = false;
        }
        CantPlay();
        GoToDeck();
    }
    void CantPlay()
    {
        GameObject Grave = GameObject.FindGameObjectWithTag("Grave");

        GameObject[] playinCard = GameObject.FindGameObjectsWithTag("PlayinCard");
        if (DragAndDrop.nextTourCounter == 0)
        {
            for (int i = 0; i < playinCard.Length; i++)
            {
                playinCard[i].transform.position = Grave.transform.position;
                playinCard[i].transform.SetParent(Grave.transform);
                playinCard[i].GetComponent<DragAndDrop>().enabled = false;
                playinCard[i].transform.tag = "PlayedCard";
            }
        }
        else if (DragAndDrop.nextTourCounter != 0)
        {
            for (int i = 0; i < playinCard.Length; i++)
            {
                playinCard[i].GetComponent<DragAndDrop>().enabled = true;
            }
        }

        GameObject[] insideDeck = GameObject.FindGameObjectsWithTag("InsideDeck");
        for (int i = 0; i < insideDeck.Length; i++)
        {
            insideDeck[i].GetComponent<DragAndDrop>().enabled = false;
        }

    }
    void GoToDeck()
    {
        GameObject[] insideGrave = GameObject.FindGameObjectsWithTag("PlayedCard");
        GameObject deck = GameObject.FindGameObjectWithTag("Deck");
        if (insideGrave.Length == 20)
        {
            for (int i = 0; i < insideGrave.Length; i++)
            {
                insideGrave[i].transform.tag = "InsideDeck";
                insideGrave[i].transform.position = deck.transform.position;
                insideGrave[i].transform.SetParent(deck.transform);
            }
        }
    }
    //write a card upgrade per tour 1/2 upgrade point and 1 uprade per card. look the upgrade system
}
