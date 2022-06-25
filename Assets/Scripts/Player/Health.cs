using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numFlashes;
    private SpriteRenderer sprietRen;

    private void Awake()
    {
        currentHealth = startingHealth;
        sprietRen = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        Debug.Log(currentHealth);
        if (currentHealth > 0)
        {
            // player hurt
            StartCoroutine(invunerability());
        }
        else
        {
            // player dead
            Debug.Log("Player is Dead");
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator invunerability()
    {
        // player on layer 6 and enemy on 8
        // Physics2D.IgnoreLayerCollision(6, 8, true);

        //invunerable duration
        for (int i = 0; i < numFlashes; i++)
        {
            sprietRen.color = new Color(255, 255, 255, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / numFlashes * 2);
            sprietRen.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / numFlashes * 2);
        }

        //Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
