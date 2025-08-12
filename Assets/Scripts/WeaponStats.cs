using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/Weapon")]
public class WeaponStats : ScriptableObject
{
    public string weaponName;
    public int damage;
}
