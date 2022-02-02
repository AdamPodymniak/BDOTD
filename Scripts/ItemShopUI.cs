using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemShopUI : MonoBehaviour
{
    public EquipManager equipManager;
    Transform shopItemTemplate;
    Transform container;
    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ItemShopTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        CreateItemButton(ShopItemList.ItemType.HealthPotion, ShopItemList.GetName(ShopItemList.ItemType.HealthPotion), ShopItemList.GetCost(ShopItemList.ItemType.HealthPotion), 0);
        CreateItemButton(ShopItemList.ItemType.ModSlot, ShopItemList.GetName(ShopItemList.ItemType.ModSlot), ShopItemList.GetCost(ShopItemList.ItemType.ModSlot), 1);
        CreateItemButton(ShopItemList.ItemType.UpgradeItem, ShopItemList.GetName(ShopItemList.ItemType.UpgradeItem), ShopItemList.GetCost(ShopItemList.ItemType.UpgradeItem), 2);
        CreateItemButton(ShopItemList.ItemType.SizePillP, ShopItemList.GetName(ShopItemList.ItemType.SizePillP), ShopItemList.GetCost(ShopItemList.ItemType.SizePillP), 3);
        CreateItemButton(ShopItemList.ItemType.SizePillM, ShopItemList.GetName(ShopItemList.ItemType.SizePillP), ShopItemList.GetCost(ShopItemList.ItemType.SizePillP), 4);
        Hide();
    }
    private void CreateItemButton(ShopItemList.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 70f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("Image").Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Image").Find("ItemCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.gameObject.SetActive(true);
        Button shopBtn = shopItemTransform.Find("Image").GetComponent<Button>();
        shopBtn.onClick.AddListener(() => BuyItem(itemType));
    }
    public void BuyItem(ShopItemList.ItemType itemType)
    {
        if(itemType == ShopItemList.ItemType.HealthPotion && PlayerCoins.instance.numOfCoins >= ShopItemList.GetCost(itemType))
        {
            if (HealthPotionNum.instance.numOfPotions < HealthPotionNum.instance.maxNumOfPotions)
            {
                HealthPotionNum.instance.numOfPotions++;
                PlayerCoins.instance.numOfCoins -= ShopItemList.GetCost(itemType);
            }
        }else if(itemType == ShopItemList.ItemType.ModSlot && PlayerCoins.instance.numOfCoins >= ShopItemList.GetCost(itemType))
        {
            equipManager.numOfSlots++;
            PlayerCoins.instance.numOfCoins -= ShopItemList.GetCost(itemType);
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
