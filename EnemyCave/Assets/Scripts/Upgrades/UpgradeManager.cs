using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public TextMeshProUGUI firstUpTitle, secondUpTitle, thirthUpTitle;
    public GameObject upgradeCanva;
    public bool isShowCanva = false;

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
