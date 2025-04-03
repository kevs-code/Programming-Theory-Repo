using UnityEngine;

public class BaseCharacter : IDamage
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private int _health = 100;
    public int Health
    {
        get { return _health; }
        set { _health = Mathf.Max(0, value); }
    }

    private float _attackValue = 5.5f;

    public float AttackValue
    {
        get { return _attackValue; }
        set { _attackValue = Mathf.Max(0, value); }
    }

    public void DealDamage()
    {
        Debug.Log(Name + " only deals " + AttackValue + " damage.");
    }

    public virtual void TakeDamage(float damAmount)
    {
        Debug.Log(Name + " took " + damAmount + " damage.");
    }

    public void SetDamageValue(float value)
    {
        Debug.Log($"{Name} sets their imaginary damage float or perhaps AttackValue to {value}");
    }

    public void Healing(int healthAmount)
    {
        Debug.Log($"{Name} heals unclamped Health {Health} += {healthAmount}");
    }
}