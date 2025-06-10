using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
	public Button prefab;
	public TMP_Text CoinsText;

	private bool isOpened = false;

	private Dictionary<string, Item> items = new();
	private List<Button> shownItems = new();
	[SerializeField]
	private int coins;

	[Range(1, 8)]
	public int ColumnCount = 4;
	public float horizontalOffset = 200;
	public float verticalOffset = 200;
	public Vector3 initialPosition = Vector3.zero;
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
		Coins = coins;
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

	public void OpenInventory()
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
			var textComponent = itemButton.GetComponentInChildren<TextMeshProUGUI>();
			textComponent.text = item.quantity + " " + item.data.itemName;
		}



		GridDisplay.PlaceButtonsInGrid(shownItems, initialPosition, ColumnCount, horizontalOffset, verticalOffset);
	}
	public void CloseInventory()
	{
		foreach (var button in shownItems)
		{
			Destroy(button.gameObject);
		}
		shownItems.Clear();
	}
}
/* 
 * Create a small Shop + Inventory System in Unity.
The player should be able to:
View a list of items available for purchase (with name, icon, description, and price)
Purchase an item
View the items collected in their personal inventory
📦 Requirements
The shop items must be easy to configure and reusable
The system should be structured in a way that allows different item types or behaviors to be added in the future
The UI must be clear, functional, and visually pleasant (not necessarily artistic, but well-organized)
There should be a basic logic to switch between different game states or views (e.g., Shop / Inventory / Purchase feedback)
🧠 What We're Evaluating
Skill
What We Look For
Project structure
Clear separation between logic, data, and presentation
Scalability and flexibility
Can new item types or logic be easily added?
UI and visual design
Is the UI intuitive, visually organized, and readable?
Code architecture
Clean, modular design showing understanding of states, data-driven logic, etc.
Version Control
Demonstrates ability to structure commits, write clear messages, and use GitHub professionally
Polish and finish
Does it feel complete? Are there signs of testing, iteration, and care?
 */
