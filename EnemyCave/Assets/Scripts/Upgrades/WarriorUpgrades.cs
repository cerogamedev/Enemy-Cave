using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorUpgrades : MonoBehaviour
{
    [HideInInspector] public int random1, random2, random3;
    private GameObject UpgradeManager;
    private bool checkToShow =true;
    [HideInInspector] public bool warriorUpgrade3 = false;
    [HideInInspector] public bool warriorUpgradeDefence2 = false, warriorAllowDefence2 = false;
    [HideInInspector] public bool warriorUpgradeDefence3 = false;
    [HideInInspector] public bool warriorUpgradeDefence4 = false, warriorAllowDefence4 = false;
    [HideInInspector] public bool warriorUpgradeDefence5 = false;


    public static int spike;
    
    private void Awake()
    {
        RandomNumberCreate();

    }
    private void Start()
    {
        UpgradeManager = GameObject.Find("UpgradeManager");
        spike = 0;
    }
    private void Update()
    {

        if (this.gameObject.GetComponent<DragAndDrop>().usingNumber == 2 && checkToShow)
        {
            ShowCheck();
        }
    }
    void ShowCheck()
    {
        UpgradeManager.GetComponent<UpgradeManager>().isShowCanva = true;
        UpgradeManager.GetComponent<UpgradeManager>().firstUpTitle.text = random1.ToString();
        UpgradeManager.GetComponent<UpgradeManager>().secondUpTitle.text = random2.ToString();
        UpgradeManager.GetComponent<UpgradeManager>().thirthUpTitle.text = random3.ToString();

        checkToShow = false;
    }
    void RandomNumberCreate()
    {
        random1 = Random.Range(0, 3);
        random2 = Random.Range(0, 3);
        while (random1==random2)
        {
            random2 = Random.Range(0, 3);
        }

        random3 = Random.Range(0, 3);
        while (random3 == random2 || random3 == random1)
        {
            random3 = Random.Range(0, 3);
        }
    }
    void WarriorUpgradeAttack1()
    {
        this.gameObject.GetComponent<Card>().attackInt += 5;
        this.gameObject.GetComponent<Card>().healthInt += 5;
    }
    void WarriorUpgradeAttack2()
    {
        this.gameObject.GetComponent<Card>().healthInt += this.gameObject.GetComponent<Card>().attackInt;
    }
    void WarriorUpgradeAttack3()
    {
        this.gameObject.GetComponent<Card>().attackInt += 5;
        warriorUpgrade3 = true;
    }
    void WarriorUpgradeDefence1()
    {
        Health.Instance.SetArmor(+10);
    }
    void WarriorUpgradeDefence2()
    {
        Health.Instance.SetArmor(+5);
        warriorUpgradeDefence2 = true;
        warriorAllowDefence2 = true;
    }
    void WarriorUpgradeDefence3()
    {
        warriorUpgradeDefence3 = true;
    }
    void WarriorUpgradeDefence4()
    {
        this.gameObject.GetComponent<Card>().SetDefence(+5);
        warriorUpgradeDefence4 = true;
        warriorAllowDefence4 = true;
    }
    void WarriorUpgradeDefence5()
    {
        warriorUpgradeDefence5 = true;
    }
}
