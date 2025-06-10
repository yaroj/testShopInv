using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private UIState currentUIState;
	public void ToggleShop()
	{
		if (currentUIState == UIState.Shop)
		{
			Shop.Instance.CloseShop();
			currentUIState = UIState.None;
		}
		else
		{
			CloseEverything();
			Shop.Instance.OpenShop();
			currentUIState = UIState.Shop;
		}
	}

	public void ToggleInventory()
	{
		if (currentUIState == UIState.Inventory)
		{
			Inventory.Instance.CloseInventory();
			currentUIState = UIState.None;
		}
		else
		{
			CloseEverything();
			Inventory.Instance.OpenInventory();
			currentUIState = UIState.Inventory;
		}
	}

	private void CloseEverything()
	{
		Shop.Instance.CloseShop();
		Inventory.Instance.CloseInventory();
	}
}
enum UIState
{
	None,
	Inventory,
	Shop
}