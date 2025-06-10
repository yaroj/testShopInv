using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : GridDisplay
{
	public Button prefab;
	public TMPro.TMP_Text CoinsText;

	private bool isOpened = false;

	private Dictionary<string, Item> items = new();
	private List<Button> shownItems = new();
	[SerializeField]
	private int coins;


	public static Inventory Instance { get; private set; }


	private void Awake()
	{
		Instance = this;
	}

	public int Coins
	{
		get { return coins; }
		set
		{
			coins = value;
			if (CoinsText != null)
			{
				print(Coins);
				CoinsText.text = coins.ToString();
			}
		}
	}

	public void AddItem(ItemData item)
	{
		if (items.TryGetValue(item.name, out Item currentValue))
		{
			currentValue.quantity++;
		}
		else
		{
			items.Add(item.name, new Item(item, 1));
		}
	}

	private void Start()
	{
		CloseInventory();
	}

	public bool TakeCoins(int count)
	{
		if (coins >= count)
		{
			Coins -= count;
			return true;
		}
		return false;

	}

	public void ToggleVisibility()
	{
		isOpened = !isOpened;

		if (isOpened)
		{
			OpenInventory();
		}
		else
		{
			CloseInventory();
		}

	}

	private void OpenInventory()
	{
		shownItems.Clear();
		print(items.Count);
		foreach (KeyValuePair<string, Item> itemEntry in items)
		{
			Item item = itemEntry.Value;
			Button itemButton = Instantiate(prefab, transform);
			itemButton.name = item.data.name;
			itemButton.image.sprite = item.data.icon;
			shownItems.Add(itemButton);
		}



		PlaceButtonsInGrid(shownItems);
	}
	private void CloseInventory()
	{
		foreach (var button in shownItems)
		{
			Destroy(button.gameObject);
		}
		shownItems.Clear();
	}
}
