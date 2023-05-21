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
        _health.text = card.health.ToString();
        _attack.text = card.attack.ToString();
        ArtWork.sprite = card.artwork;
        _name.text = card.name;
        healthInt = card.health;
        attackInt = card.attack;
        if (healthInt <= 0)
            Destroy(this.gameObject);
    }
    public int GetAttack()
    {
        return attackInt;
    }
}
