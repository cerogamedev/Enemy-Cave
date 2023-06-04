using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    private static Health instance;

    public static Health Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Health>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<Health>();
                    singletonObject.name = "Health";
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }

    [SerializeField] TextMeshProUGUI healthText, armorText;
    public int mainHealth, mainArmor;
    void Start()
    {
        mainHealth = 30;
        mainArmor = 5;
    }

    void Update()
    {
        healthText.text = mainHealth.ToString();
        armorText.text = mainArmor.ToString();
    }
    public int GetHealth()
    {
        return mainHealth;
    }
    public void SetHealth(int health)
    {
        mainHealth += health;
    }

    public int GetArmor()
    {
        return mainArmor;
    }
    public void SetArmor(int armor)
    {
        mainArmor += armor;
    }
}
