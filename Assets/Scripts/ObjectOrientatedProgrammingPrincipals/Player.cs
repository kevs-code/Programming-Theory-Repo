using UnityEngine;

public class Player : BaseCharacter
{
    public void UniqueAbilities()
    {
        Debug.Log("The Player does the conga!");
    }

    public override void TakeDamage(float damAmount)
    {
        base.TakeDamage(damAmount);
        Debug.Log("Player shouts Runaway, Runaway!");
    }
    
    public void Respawn()
    {
        Debug.Log("The Player respawns!");
    }
}
