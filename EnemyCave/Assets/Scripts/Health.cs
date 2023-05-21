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

    [SerializeField] TextMeshProUGUI healthText;
    public int mainHealth;
    void Start()
    {
        mainHealth = 30;
    }

    void Update()
    {
        healthText.text = mainHealth.ToString();
    }
    public int GetHealth()
    {
        return mainHealth;
    }
    public void SetHealth(int health)
    {
        mainHealth += health;
    }
}
