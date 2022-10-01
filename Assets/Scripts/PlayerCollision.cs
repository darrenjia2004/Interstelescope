using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private int health = 4;
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
            TakeDamage();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health <= 0) return;
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            TakeDamage();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
    private void Die()
    {
        Destroy(engine);
        Destroy(engineEffect);
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void TakeDamage()
    {
        Debug.Log("damage");
        health--;
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
