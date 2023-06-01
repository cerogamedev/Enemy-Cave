using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public EnemyCard enemyCards;
    public Image ArtWork;
    public TextMeshProUGUI _health, _name;
    public int healthInt;
    void Start()
    {
        _health.text = enemyCards.health.ToString();
        healthInt = enemyCards.health;
        ArtWork.sprite = enemyCards.artwork;
        _name.text = enemyCards.name;

    }

    void Update()
    {
        _health.text = healthInt.ToString();

        if (healthInt <= 0)
            Destroy(this.gameObject);
    }
    public void SetHealth(int health)
    {
        healthInt += health;
    }
}
