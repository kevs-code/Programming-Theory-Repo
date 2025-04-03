using UnityEngine;

public class Enemy : BaseCharacter
{
    public void Patrol()
    {
        Debug.Log("Enemy is patrolling!");
    }

    public void Spawn()
    {
        Debug.Log("Enemy is spawning!");
    }
}