using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invicibleFlashDelay = 0.2f;
    public float invicibilityTime = 3f;

    public HealthBar healthBar;

    public bool isInvincible = false;
    public SpriteRenderer playerGraphics;

    public AudioClip hitSound;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PlayerHealth.");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(80);
        }
    }
    public void HealPlayer(int healAmount)
    {
        if ((currentHealth + healAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        { 
            currentHealth += healAmount;
        }
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Death();
                return;
            }
            isInvincible = true;
            StartCoroutine(InvisibleFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public void Death()
    {
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death"); //Reference to the animator
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic; //No interactions after death
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnCharacterDeath();
    }
    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvisibleFlash()  // Coroutine that flash the player while invisible
    {
        while(isInvincible)
        {
            playerGraphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibleFlashDelay);
            playerGraphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibleFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTime);
        isInvincible = false;
    }
}
