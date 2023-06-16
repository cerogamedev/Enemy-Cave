using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WarriorUpgrades : MonoBehaviour
{
    private List<UnityAction> functionList = new List<UnityAction>();
    private List<UnityAction> UIfunctionList = new List<UnityAction>();

    public bool upgradeDone = false;
    public int spikeInt = 0;

    List<int> numbers = new List<int>();


    public int randomIndx0, randomIndx1, randomIndx2;
    private void Start()
    {
        if (this.gameObject.GetComponent<Card>().isDefence)
        {
            
        }
        else if (this.gameObject.GetComponent<Card>().isAttack)
        {
            functionList.Add(WarriorAttackUpgrade1);
            functionList.Add(WarriorAttackUpgrade2);
            functionList.Add(WarriorAttackUpgrade3);

            UIfunctionList.Add(UIWarriorAttackUpgrade1);
            UIfunctionList.Add(UIWarriorAttackUpgrade2);
            UIfunctionList.Add(UIWarriorAttackUpgrade3);
        }
        Select3RandomFunc();
    }
    public void Select3RandomFunc()
    {
        while (numbers.Count < 3)
        {
            int randomNumber = Random.Range(0, functionList.Count);

            if (!numbers.Contains(randomNumber))
            {
                numbers.Add(randomNumber);
            }
        }

        randomIndx0 = numbers[0];
        randomIndx1 = numbers[1];
        randomIndx2 = numbers[2];
    }
    public void Update()
    {
        if (upgradeDone)
        {
            UpgradeManager.Instance.firstUpTitle.text = "";
            UpgradeManager.Instance.secondUpTitle.text = "";
            UpgradeManager.Instance.thirthUpTitle.text = "";
            UpgradeManager.Instance.upgradeCanva.SetActive(false);
            this.GetComponent<DragAndDrop>().usingNumber += 1;
        }
        else if (this.gameObject.GetComponent<DragAndDrop>().usingNumber == 2)
        {
            UpgradeManager.Instance.upgradeCanva.SetActive(true);
            UIfunctionList[randomIndx0].Invoke();
            UIfunctionList[randomIndx1].Invoke();
            UIfunctionList[randomIndx2].Invoke();
        }
    }
    public void MainWarriorUpgrade1()
    {
        functionList[randomIndx0].Invoke();

        upgradeDone = true;
    }
    public void MainWarriorUpgrade2()
    {
        functionList[randomIndx1].Invoke();

        upgradeDone = true;

    }
    public void MainWarriorUpgrade3()
    {
        functionList[randomIndx2].Invoke();

        upgradeDone = true;

    }
    public void WarriorAttackUpgrade1()
    {
        this.gameObject.GetComponent<Card>().healthInt += 5;
        this.gameObject.GetComponent<Card>().attackInt += 5;

    }
    public void WarriorAttackUpgrade2()
    {
        this.gameObject.GetComponent<Card>().attackInt = Health.Instance.mainArmor;
    }
    public void  WarriorAttackUpgrade3()
    {
        this.gameObject.GetComponent<Card>().healthInt += 5;
    }
    public void UIWarriorAttackUpgrade1()
    {
        UpgradeManager.Instance.firstUpTitle.text = "+5 for defence and attack";
    }
    public void UIWarriorAttackUpgrade2()
    {
        UpgradeManager.Instance.secondUpTitle.text = "Earn as many attacks as each armor";

    }
    public void UIWarriorAttackUpgrade3()
    {
        UpgradeManager.Instance.thirthUpTitle.text = "+5 for defence";
    }
}
