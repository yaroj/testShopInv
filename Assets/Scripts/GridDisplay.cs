using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridDisplay : MonoBehaviour
{


	[Range(1, 8)]
	public int ColumnCount = 4;
	public float horizontalOffset = 200;
	public float verticalOffset = 200;
	public Vector3 initialPosition = Vector3.zero;

	protected virtual Vector3 GetLocalPosition(int index)
	{
		return initialPosition +
			(index % ColumnCount) * horizontalOffset * Vector3.right +
			(index / ColumnCount) * verticalOffset * Vector3.up;
	}

	protected virtual void PlaceButtonsInGrid(List<Button> buttons)
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].transform.localPosition = GetLocalPosition(i);
		}
	}
}
