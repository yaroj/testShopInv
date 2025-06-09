using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private int coins;
	public bool TakeCoins(int count)
	{
		if(coins >= count)
		{
			coins -= count;
			return true;
		}
		return false;

	}


}
