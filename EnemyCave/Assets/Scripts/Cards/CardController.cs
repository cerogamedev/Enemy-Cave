using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards")]
public class CardController : ScriptableObject
{
    public string cardName;
    public int attack;
    public int health;
    public Sprite artwork;

}
