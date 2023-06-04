using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorUpgrades : MonoBehaviour
{
    IEnumerator WarriorAttackUpgrade1()
    {
        this.gameObject.GetComponent<Card>().healthInt += 5;
        this.gameObject.GetComponent<Card>().attackInt += 5;

        yield return null;
    }
    IEnumerator WarriorAttackUpgrade2()
    {
        this.gameObject.GetComponent<Card>().attackInt = Health.Instance.mainArmor;
        yield return null;
    }
    IEnumerator WarriorAttackUpgrade3()
    {
        this.gameObject.GetComponent<Card>().healthInt += 5;
        yield return null;
    }
}
