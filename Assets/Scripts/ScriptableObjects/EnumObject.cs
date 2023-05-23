using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnumObject", menuName = "ScriptableObjects/Enum", order = 1)]
public class EnumObject : ScriptableObject
{
    public List<string> names;
}
