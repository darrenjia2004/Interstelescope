using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public int health = 4;
    [SerializeField] GameObject engine;
    [SerializeField] GameObject engineEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(1);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health <= 0) return;
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            int min = collision.gameObject.GetComponent<AsteroidCollision>().health;
            if (health < min)
            {
                min = health;
            }
            collision.gameObject.GetComponent<AsteroidCollision>().TakeDamage(min);
            TakeDamage(min);
            
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            int min = collision.gameObject.GetComponent<EnemyCollision>().health;
            if (health < min)
            {
                min = health;
            }
            collision.gameObject.GetComponent<EnemyCollision>().TakeDamage(min);
            TakeDamage(min);
            
        }
    }
    private void Die()
    {
        Destroy(engine);
        Destroy(engineEffect);
        
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        rb.simulated = false;
        

    }
    public void TakeDamage(int damage)
    {
        Debug.Log("damage");
        health-=damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StopCoroutine(ChangeSprite());
            StartCoroutine(ChangeSprite());
        }
    }
    private IEnumerator ChangeSprite()
    {
        spriteRenderer.color = new Color(1f, 0, 0);
        anim.SetInteger("health", health);
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = new Color(1f, 1f, 1f);
        

    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
