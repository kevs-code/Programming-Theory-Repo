using UnityEngine;

public class Enemy : BaseCharacter
{
    public void Patrol()
    {
        Debug.Log($"Enemy: {Name} is patrolling!");
    }

    public void Spawn()
    {
        Debug.Log($"Enemy: {Name} is spawning!");
    }
}