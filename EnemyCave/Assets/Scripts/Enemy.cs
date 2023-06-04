using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public EnemyCard enemyCards;
    public Image ArtWork;
    public TextMeshProUGUI _health, _name, _dmgcountText;
    public int healthInt;
    public int _DamageCountdown;
    [HideInInspector] public int inGameDamageCountdown;
    void Start()
    {
        _health.text = enemyCards.health.ToString();
        healthInt = enemyCards.health;
        ArtWork.sprite = enemyCards.artwork;
        _name.text = enemyCards.name;
        _DamageCountdown = enemyCards.DamageCountdown;
        inGameDamageCountdown = _DamageCountdown;
    }

    void Update()
    {
        _health.text = healthInt.ToString();
        _dmgcountText.text = inGameDamageCountdown.ToString();

        if (healthInt <= 0)
            Destroy(this.gameObject);
    }
    public void SetHealth(int health)
    {
        healthInt += health;
    }
}
