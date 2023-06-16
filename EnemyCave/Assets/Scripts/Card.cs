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

    public bool isDefence, isAttack;
    void Start()
    {
        healthInt = card.health;
        attackInt = card.attack;
        if (healthInt > 0)
        {
            isDefence = true;
            isAttack = false;
        }
        else if (attackInt > 0)
        {
            isAttack = true;
            isDefence = false;
        }
    }

    void Update()
    {
        _health.text = "H: " + healthInt.ToString();
        _attack.text = "A: "+ attackInt.ToString();
        ArtWork.sprite = card.artwork;
        _name.text = card.cardName;
    }
    public int GetAttack()
    {
        return attackInt;
    }
    public void SetAttack(int attack)
    {
        attackInt += attack;
    }
    public int GetDeffence()
    {
        return healthInt;
    }
    public void SetDefence(int defence)
    {
        healthInt += defence;
    }
}
