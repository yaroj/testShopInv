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

	public static Vector3 GetLocalPosition(int index, Vector3 initialPosition,  int ColumnCount = 4,  float horizontalOffset = 200,
	float verticalOffset = 200)
	{
		return initialPosition +
			(index % ColumnCount) * horizontalOffset * Vector3.right +
			(index / ColumnCount) * verticalOffset * Vector3.down;
	}

	public static void PlaceButtonsInGrid(List<Button> buttons, Vector3 initialPosition, int ColumnCount = 4, float horizontalOffset = 200,
	float verticalOffset = 200)
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].transform.localPosition = GetLocalPosition(i, initialPosition, ColumnCount, horizontalOffset, verticalOffset);
		}
	}
}
