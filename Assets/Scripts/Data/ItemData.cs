using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Shop/Item Data")]
public class ItemData : ScriptableObject
{
	public Sprite icon;
	public string itemName;
	public string description;
	public int price;
}