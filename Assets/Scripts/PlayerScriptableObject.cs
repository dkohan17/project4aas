using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player", menuName ="Create Player")]

public class PlayerScriptableObject : ScriptableObject
{
    public int maxHealth;
    public int health;

    public int maxStamina;
    public int stamina;

    public int Health
    {
        get {return health;}
        set { health = value; }
    }

    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
}
