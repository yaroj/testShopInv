using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
	public Item(ItemData item, int quantity)
	{
		data = item;
		this.quantity = quantity;
	}
	public ItemData data;
	public int quantity;
}
