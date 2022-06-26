using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private float damage;


    // Triggered when another box collider2D enters 
    // Other in this case should be teh player
    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<Health>().TakeDamage(damage);
    }
}
