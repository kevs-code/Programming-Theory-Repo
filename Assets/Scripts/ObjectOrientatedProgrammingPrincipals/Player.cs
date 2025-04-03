using UnityEngine;

public class Player : BaseCharacter, IPlayerDamage
{


    public void Attack()
    {
        Debug.Log("Player Attacking!");

    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);//Execute the base functionality of this function

        Debug.Log("The Player is chasing the Enemy!");
    }

    public void PlayerTripleAttack()
    {

    }
}
