using UnityEngine;

public class Powerup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Debug.Log("Powerup picked up!");
    }
}
