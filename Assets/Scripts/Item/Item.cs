using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum ItemType
{
    None = 0,
    Consumable = 1 << 0,
    Usable = 1 << 1,
    Combinable = 1 << 2,
    Giftable = 1 << 3,
}