using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public EnemyCard enemyCards;
    public Image ArtWork;
    public TextMeshProUGUI _health, _attack, _name;
    public int healthInt, attackInt;
    void Start()
    {
        _health.text = enemyCards.health.ToString();
        _attack.text = enemyCards.attack.ToString();
        healthInt = enemyCards.health;
        attackInt = enemyCards.attack;
        ArtWork.sprite = enemyCards.artwork;
        _name.text = enemyCards.name;

    }

    void Update()
    {
        _health.text = healthInt.ToString();
        _attack.text = attackInt.ToString();

        if (healthInt <= 0)
            Destroy(this.gameObject);
    }
    public void SetHealth(int health)
    {
        healthInt += health;
    }
}
