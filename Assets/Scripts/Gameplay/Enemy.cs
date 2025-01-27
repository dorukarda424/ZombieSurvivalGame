using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public bool enemyDirection = true;
    public float speed;
    public GameObject Player;
    protected float zombieHealth;
    UITextUpdate ScoreText;
    Animator enemyAnimator;
    [SerializeField]
    GameObject experience;
    private Player playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ScoreText = Object.FindAnyObjectByType<UITextUpdate>();
    }
    void Start()
    {
        Player = GameObject.Find("player");
        zombieHealth = ConfigurationData.ZombieHealth;
        enemyAnimator = GetComponent<Animator>();
        playerScript = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerScript.isDead)
        {
            FollowPlayer();

            if (Vector2.Distance(transform.position, Player.transform.position) > ConfigurationData.MaxZombieDistance)
            {
                ChangeZombieLocation();
            }

            if (transform.position.x > Player.transform.position.x)
            {
                if (enemyDirection)
                {
                    InverseZombie(false);
                }



            }
            else if (transform.position.x < Player.transform.position.x)
            {
                if (!enemyDirection)
                {
                    InverseZombie(true);
                }


            }
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            zombieHealth -= ConfigurationData.BulletDamage;
            enemyAnimator.SetBool("isDamaged", true);
            if (zombieHealth <= 0)
            {
                ScoreText.AddScore(ConfigurationData.EnemyPoint);
                Instantiate(experience, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("grenade"))
        {
            ScoreText.AddScore(ConfigurationData.EnemyPoint);
            Instantiate(experience, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        enemyAnimator.SetTrigger("isDamaged");
    }
    public void Initialize(GameObject player)
    {
        Player = player;
    }
    void ChangeZombieLocation()
    {
        int randomDirection = Random.Range(0, 2);
        if (randomDirection == 0)
        {
            List<float> myList = new List<float>() { DataManager.Instance.lowerBound.y - ConfigurationData.EnemySpawnerVerticalPadding, DataManager.Instance.upperBound.y + ConfigurationData.EnemySpawnerVerticalPadding };
            int randomPosition = Random.Range(0, myList.Count);
            transform.position = new Vector2(Random.Range(DataManager.Instance.lowerBound.x, DataManager.Instance.upperBound.x), myList[randomPosition]);
        }
        else
        {
            List<float> myList = new List<float>() { DataManager.Instance.lowerBound.x - ConfigurationData.EnemySpawnerHorizontalPadding, DataManager.Instance.upperBound.x + ConfigurationData.EnemySpawnerHorizontalPadding };
            int randomPosition = Random.Range(0, myList.Count);
            transform.position = new Vector2(myList[randomPosition], Random.Range(DataManager.Instance.lowerBound.y, DataManager.Instance.upperBound.y));
        }
    }
    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, (ConfigurationData.ZombieSpeed * Time.deltaTime));
    }
    void InverseZombie(bool enemyDirection2)
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        enemyDirection = enemyDirection2;
    }
}
