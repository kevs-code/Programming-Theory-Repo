using UnityEngine;

public class Player : BaseCharacter
{
    public void UniqueAbilities()
    {
        Debug.Log($"Player: {Name} does the conga!");
    }

    public void Jump()
    {
        Debug.Log($"Player: {Name} jumps!");
    }

    public override void TakeDamage(float damAmount)
    {
        base.TakeDamage(damAmount);
        Debug.Log($"Player: {Name} shouts Runaway, Runaway!");
    }
    
    public void Respawn()
    {
        Debug.Log($"Player: {Name} respawns!");
    }
}