using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardUpgrade : MonoBehaviour
{
    [HideInInspector] public bool StartUp = true;
    public bool startToUpgrade = false;
    void Start()
    {
        this.gameObject.GetComponent<WarriorUpgrades>().enabled = false;
        this.gameObject.GetComponent<ShamanUpgrades>().enabled = false;
        this.gameObject.GetComponent<RogueUpgrades>().enabled = false;
        
    }

    void Update()
    {
        if (GameManager.choose == "Warrior")
        {
            this.gameObject.GetComponent<WarriorUpgrades>().enabled = true;
        }
        if (GameManager.choose == "Shaman")
        {
            this.gameObject.GetComponent<ShamanUpgrades>().enabled = true;

        }
        if (GameManager.choose == "Rogue")
        {
            this.gameObject.GetComponent<RogueUpgrades>().enabled = true;

        }
        if (this.gameObject.GetComponent<DragAndDrop>().usingNumber==2 && StartUp == true)
        {
            StartCoroutine(StartUpgradeSystem());
        }
    }
    IEnumerator StartUpgradeSystem()
    {
        StartUp = false;
        startToUpgrade = true;
        yield return null;
    }
}
