using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    // unnecessary
    Player playerData;
    //Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb=GetComponent<Rigidbody>();//Getting an existing reference
        //rb=GetComponentInChildren<Rigidbody>();
        //rb=GetComponentInParent<Rigidbody>();
        playerData = new Player();//Creating a new reference
        playerData.Name = "Player1";

        playerData.TakeDamage(20);
        playerData.Attack();
    }

    // Update is called once per frame
    void Update()
    {

    }
}