using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private float damage;


    // Triggered when another box collider2D enters 
    // Other in this case should be teh player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<Health>().TakeDamage(damage);
    }
}
