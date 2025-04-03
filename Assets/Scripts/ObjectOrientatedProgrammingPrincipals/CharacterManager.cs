using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Player playerData;
    Enemy enemyData;

    void Start()
    {
        playerData = new Player();
        enemyData = new Enemy();
        playerData.Name = "Player1";
        enemyData.Name = "Geoff";

        // Moves
        enemyData.Spawn();
        enemyData.Patrol();
        
        playerData.SetDamageValue(20);
        playerData.DealDamage();
        enemyData.TakeDamage(20);
        
        enemyData.Healing(20);
        playerData.UniqueAbilities();
        
        enemyData.SetDamageValue(20);
        enemyData.DealDamage();
        playerData.TakeDamage(20);
        
        playerData.Respawn();
    }
}