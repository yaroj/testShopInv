using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
	private bool isOpened = false;
	private List<Button> shopItems = new();
	private TMP_Text buyText;
	public List<ItemData> data;

	public Button prefab;

	public GameObject ShopButton;
	public Button BuyButton;

	public TMP_InputField Description;
	[Range(1, 8)]
	public int ColumnCount = 4;
	public float horizontalOffset = 200;
	public float verticalOffset = 200;
	public Vector3 initialPosition = Vector3.zero;
	private void Start()
	{
		CloseShop();
		buyText = BuyButton.GetComponentInChildren<TMP_Text>();
	}

	public void ToggleVisibility()
	{
		isOpened = !isOpened;

		if (isOpened)
		{
			OpenShop();
		}
		else
		{
			CloseShop();
		}

	}

	private void OpenShop()
	{
		BuyButton.gameObject.SetActive(true);
		Description.gameObject.SetActive(true);
		for (int i = 0; i < data.Count; i++)
		{
			ItemData itemData = data[i];
			var item = CreateItemUI(itemData);
			shopItems.Add(item);
		}
		GridDisplay.PlaceButtonsInGrid(shopItems);
	}
	private Button CreateItemUI(ItemData itemData)
	{
		var itemButton = Instantiate(prefab, transform);
		itemButton.image.sprite = itemData.icon;
		itemButton.name = itemData.itemName;
		var textComponent = itemButton.GetComponentInChildren<TextMeshProUGUI>();
		textComponent.text = itemData.itemName;
		itemButton.onClick.AddListener(() => UpdateBuyingItem(itemData));
		return itemButton;
	}

	private void UpdateBuyingItem(ItemData itemData)
	{
		Description.text = itemData.description;
		buyText.text = "BUY " + itemData.price;
		BuyButton.onClick.RemoveAllListeners();
		BuyButton.onClick.AddListener(() => BuyItem(itemData));
	}

	private void BuyItem(ItemData itemData)
	{
		if (Inventory.Instance.TakeCoins(itemData.price))
		{
			Inventory.Instance.AddItem(itemData);
		}
		else {
			print("not enough money");
		}
	}

	private void CloseShop()
	{
		BuyButton.gameObject.SetActive(false);
		Description.gameObject.SetActive(false);
		foreach (var item in shopItems)
		{
			Destroy(item.gameObject);
		}
		shopItems.Clear();
	}
}
