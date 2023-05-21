using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewEnemyCard", menuName = "EnemyCards")]
public class EnemyCard : ScriptableObject
{
    public string cardName;
    public int arrivalStatistics;
    public int attack;
    public int health;
    public Sprite artwork;
}
