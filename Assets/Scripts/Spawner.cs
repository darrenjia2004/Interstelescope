using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject nebulaOne;
    [SerializeField] GameObject nebulaTwo;
    [SerializeField] GameObject starOne;
    [SerializeField] GameObject starTwo;
    [SerializeField] GameObject starThree;
    [SerializeField] GameObject cruiser;
    [SerializeField] GameObject frigate;
    [SerializeField] GameObject scout;
    private float timeSinceEnemySpawn;
    public float spawnFrequency;
    [SerializeField] private GameObject gameCamera;
    private Transform cameraTransform;
    public float spawnFrequencyMin;
    public int cruiserThreshold;
    public int frigateThreshold;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = gameCamera.GetComponent<Transform>();
        int nebulaTwoCount = Random.Range(3, 8);
        int nebulaOneCount = Random.Range(3, 8);
        int starOneCount = Random.Range(20, 30);
        int starTwoCount = Random.Range(20, 30);
        int starThreeCount = Random.Range(20, 30);
        float nebulaOneRadius = nebulaTwo.GetComponent<Collider2D>().bounds.extents.x;
        float nebulaTwoRadius = nebulaTwo.GetComponent<Collider2D>().bounds.extents.x;
        float starOneRadius = starOne.GetComponent<Collider2D>().bounds.extents.x;
        float starTwoRadius = starTwo.GetComponent<Collider2D>().bounds.extents.x;
        float starThreeRadius = starThree.GetComponent<Collider2D>().bounds.extents.x;
        for (int i = 0; i < nebulaTwoCount; i++)
        {
            float x = Random.Range(-27f, 27f);
            float y = Random.Range(-15f, 15f);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, nebulaTwoRadius, LayerMask.GetMask("Nebula"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(nebulaTwo, new Vector3(x, y, 0), Quaternion.identity);
            }
                
        }
        for (int i = 0; i < nebulaOneCount; i++)
        {
            float x = Random.Range(-27f, 27f);
            float y = Random.Range(-15f, 15f);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, nebulaOneRadius, LayerMask.GetMask("Nebula"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(nebulaOne, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < starOneCount; i++)
        {
            float x = Random.Range(-27f, 27f);
            float y = Random.Range(-15f, 15f);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, starOneRadius, LayerMask.GetMask("Star"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(starOne, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < starTwoCount; i++)
        {
            float x = Random.Range(-27f, 27f);
            float y = Random.Range(-15f, 15f);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, starTwoRadius, LayerMask.GetMask("Star"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(starTwo, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        for (int i = 0; i < starThreeCount; i++)
        {
            float x = Random.Range(-27f, 27f);
            float y = Random.Range(-15f, 15f);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(spawnPoint, starThreeRadius, LayerMask.GetMask("Star"));
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy == false)
            {
                Instantiate(starThree, new Vector3(x, y, 0), Quaternion.identity);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeSinceEnemySpawn += Time.deltaTime;
        if (timeSinceEnemySpawn > spawnFrequency)
        {
            float x;
            float y;
            do
            {
                x = Random.Range(-27f, 27f);
                y = Random.Range(-15f, 15f);
            } while (((x < cameraTransform.position.x+9) && (x>cameraTransform.position.x-9)) && ((y < cameraTransform.position.y + 5) && (y > cameraTransform.position.y - 5)));
            float enemyType = Random.Range(0f, 100f);
            if (enemyType > cruiserThreshold)
            {
                Instantiate(cruiser, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (enemyType > frigateThreshold)
            {
                Instantiate(frigate, new Vector3(x, y, 0), Quaternion.identity);
                cruiserThreshold--;
            }
            else
            {
                Instantiate(scout, new Vector3(x, y, 0), Quaternion.identity);
                frigateThreshold--;
            }
            spawnFrequency -= 0.1f;
            if (spawnFrequency < spawnFrequencyMin) spawnFrequency = spawnFrequencyMin;
            timeSinceEnemySpawn = 0f;
        }
    }
}
