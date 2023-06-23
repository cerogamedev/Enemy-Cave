using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using System;
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
    public Button button1;
    public Button button2;
    public Button button3;

    private List<Action> fonksiyonlar;

    private void Start()
    {
        UpgradeManager = GameObject.Find("UpgradeManager");
        spike = 0;

        fonksiyonlar = new List<Action>
        {
            WarriorUpgradeAttack1,
            WarriorUpgradeAttack2,
            WarriorUpgradeAttack3,
            WarriorUpgradeDefence1,
            WarriorUpgradeDefence2,
            WarriorUpgradeDefence3,
            WarriorUpgradeDefence4,
            WarriorUpgradeDefence5
            // Ek fonksiyonlarýnýzý buraya ekleyin
        };
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
        FindButtons();

        AssignRandomFunctionsToButtons();
        checkToShow = false;
    }
    void WarriorUpgradeAttack1()
    {
        this.gameObject.GetComponent<Card>().attackInt += 5;
        this.gameObject.GetComponent<Card>().healthInt += 5;
        Debug.Log("It worked");
    }
    void WarriorUpgradeAttack2()
    {
        this.gameObject.GetComponent<Card>().healthInt += this.gameObject.GetComponent<Card>().attackInt;
        Debug.Log("It worked");

    }
    void WarriorUpgradeAttack3()
    {
        this.gameObject.GetComponent<Card>().attackInt += 5;
        warriorUpgrade3 = true;
        Debug.Log("It worked");

    }
    void WarriorUpgradeDefence1()
    {
        Health.Instance.SetArmor(+10);
        Debug.Log("It worked");

    }
    void WarriorUpgradeDefence2()
    {
        Health.Instance.SetArmor(+5);
        warriorUpgradeDefence2 = true;
        warriorAllowDefence2 = true;
        Debug.Log("It worked");

    }
    void WarriorUpgradeDefence3()
    {
        warriorUpgradeDefence3 = true;
        Debug.Log("It worked");

    }
    void WarriorUpgradeDefence4()
    {
        this.gameObject.GetComponent<Card>().SetDefence(+5);
        warriorUpgradeDefence4 = true;
        warriorAllowDefence4 = true;
        Debug.Log("It worked");

    }
    void WarriorUpgradeDefence5()
    {
        warriorUpgradeDefence5 = true;
        Debug.Log("It worked");

    }

    void AssignRandomFunctionsToButtons()
    {
        List<Action> secilenFonksiyonlar = new List<Action>();

        while (secilenFonksiyonlar.Count < 3)
        {
            int randomIndex = UnityEngine.Random.Range(0, fonksiyonlar.Count);
            Action randomFonksiyon = fonksiyonlar[randomIndex];

            if (!secilenFonksiyonlar.Contains(randomFonksiyon))
            {
                secilenFonksiyonlar.Add(randomFonksiyon);
            }
        }
        button1.onClick.AddListener(() => secilenFonksiyonlar[0].Invoke());
        UpgradeManager.GetComponent<UpgradeManager>().firstUpTitle.text = secilenFonksiyonlar[0].Method.Name;

        button2.onClick.AddListener(() => secilenFonksiyonlar[1].Invoke());
        UpgradeManager.GetComponent<UpgradeManager>().secondUpTitle.text = secilenFonksiyonlar[1].Method.Name;

        button3.onClick.AddListener(() => secilenFonksiyonlar[2].Invoke());
        UpgradeManager.GetComponent<UpgradeManager>().thirthUpTitle.text = secilenFonksiyonlar[2].Method.Name;
    }
    void FindButtons()
    {
        button1 = UpgradeManager.GetComponent<UpgradeManager>().button1;
        button2 = UpgradeManager.GetComponent<UpgradeManager>().button2;
        button3 = UpgradeManager.GetComponent<UpgradeManager>().button3;
    }
}
