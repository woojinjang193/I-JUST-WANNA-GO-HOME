using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Prefab")]
    public GameObject itemPrefab;

    [Header("Item Info")]
    public Sprite icon;
    public string itemName;

    [Header("Item Type")]
    public ItemType types;

    [Header("Description")]
    public string description;

    //[Header("Actions")]
    //public List<ItemAction> actions;
}
