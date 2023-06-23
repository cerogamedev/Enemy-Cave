using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public TextMeshProUGUI firstUpTitle, secondUpTitle, thirthUpTitle;
    public GameObject upgradeCanva;
    public bool isShowCanva = false;
    public Button button1;
    public Button button2;
    public Button button3;
    private void Awake()
    {

    }
    public void Update()
    {
        if (isShowCanva)
        {
            upgradeCanva.SetActive(true);
        }
        else
        {
            if (upgradeCanva == null)
            {
                upgradeCanva = GameObject.FindGameObjectWithTag("UpgradeCanva");
                return;
            }
            else
                upgradeCanva.SetActive(false);
        }
    }

}
