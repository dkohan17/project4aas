using UnityEngine;
using UnityEngine.UI;

public class ShopTabs : MonoBehaviour
{
    public GameObject upgradesPanel;
    public GameObject weaponsPanel;


    public Button upgradesButton;
    public Button weaponsButton;

    public Color activeColor;
    public Color normalColor;


    private void Start()
    {
        ShowUpgrades();
    }

    public void ShowUpgrades()
    {
        upgradesPanel.SetActive(true);
        weaponsPanel.SetActive(false);

    }

    public void ShowWeapons()
    {
        upgradesPanel.SetActive(false);
        weaponsPanel.SetActive(true);

    }
}
