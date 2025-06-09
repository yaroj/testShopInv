using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	private bool isOpened = false;
	private List<Button> shopItems = new();
	[Range(1,8)]
	public int ColumnCount = 4;
	public float horizontalOffset = 200;
	public float verticalOffset = 200;
	public Vector3 initialPosition = Vector3.zero;

	public List<ItemData> data;

	public Button prefab;

	public GameObject ShopButton;
	public Button BuyButton;
	public TMPro.TMP_InputField Description;

	private void Start()
	{
		CloseShop();
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
			var t = item.transform;
			t.localPosition = GetLocalPosition(i);
			shopItems.Add(item);
		}

	}

	private Vector3 GetLocalPosition(int index)
	{
		return initialPosition +
			(index % ColumnCount) * horizontalOffset * Vector3.right +
			(index / ColumnCount) * verticalOffset * Vector3.up; 
	}
	private Button CreateItemUI(ItemData itemData)
	{
		var itemButton = Instantiate(prefab, transform);
		itemButton.image.sprite = itemData.icon;
		itemButton.name = itemData.itemName;
		var textComponent = itemButton.GetComponentInChildren<TMPro.TextMeshProUGUI>();
		textComponent.text = itemData.itemName;
		return itemButton;
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
