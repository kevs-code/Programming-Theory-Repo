using UnityEngine;

/*
public interface IDamageable
{
    void TakeDamage(int damage);
    void Defence();
}
*/

public class BaseCharacter : IDamageable
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int health = 100;
    public int Health
    {
        get { return health; }
        set { health = Mathf.Max(0, value); }
    }


    public virtual void TakeDamage(int damage)
    {
        Debug.Log(Name + " took " + damage + " damage.");
    }

    public void Defence()
    {
    }
}