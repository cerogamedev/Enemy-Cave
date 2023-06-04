using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public CardController card;
    public Image ArtWork;
    public TextMeshProUGUI _health, _attack, _name;
    public int healthInt, attackInt;
    void Start()
    {

    }

    void Update()
    {
        _health.text = healthInt.ToString();
        _attack.text = attackInt.ToString();
        ArtWork.sprite = card.artwork;
        _name.text = card.cardName;
        healthInt = card.health;
        attackInt = card.attack;
    }
    public int GetAttack()
    {
        return attackInt;
    }
    public int GetDeffence()
    {
        return healthInt;
    }
}
