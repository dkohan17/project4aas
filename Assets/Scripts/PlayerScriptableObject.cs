using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player", menuName ="Create Player")]

public class PlayerScriptableObject : ScriptableObject
{
<<<<<<< HEAD
    public int maxHealth;
    public int health;

    public int maxStamina;
    public int stamina;
=======
    private int maxHealth; //!!
    private int health; //!!

    private int maxStamina; //!!
    private int stamina; //!!
>>>>>>> main

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
