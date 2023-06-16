using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public TextMeshProUGUI firstUpTitle, secondUpTitle, thirthUpTitle;
    public GameObject upgradeCanva;
    private static UpgradeManager instance;

    private UpgradeManager() { }

    public static UpgradeManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject();
                instance = singletonObject.AddComponent<UpgradeManager>();
                singletonObject.name = "UpgradeManager (Singleton)";
                DontDestroyOnLoad(singletonObject);
            }

            return instance;
        }
    }
    private void Awake()
    {
        upgradeCanva = GameObject.FindGameObjectWithTag("UpgradeCanva");
    }
    public void Update()
    {

    }
}
