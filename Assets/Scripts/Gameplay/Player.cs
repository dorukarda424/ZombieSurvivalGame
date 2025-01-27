using System;
using System.Net.Sockets;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    protected ExperienceSystem experienceSystem;
    public bool playerDirection = true;
    public Transform childObject;
    public float bulletX;
    public float bulletY;
    public float grenadeX;
    public float grenadeY;
    public float normalizedBulletX;
    public float normalizedBulletY;
    public float bulletTime;
    public GameObject Bullets;
    public GameObject Grenade;
    public Rigidbody2D rb;
    public object bulletReload;
    public Timer bulletReloadTimer;
    public Timer grenadeReloadTimer;
    public Timer playerDashCooldown;
    public Timer playerInvisibilityFrameTimer;
    bool shootBullet;
    bool shootGrenade;
    Animator playerAnimator;
    public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        experienceSystem = UnityEngine.Object.FindAnyObjectByType<ExperienceSystem>();
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bulletReloadTimer= gameObject.AddComponent<Timer>();
        bulletReloadTimer.Initialize(ConfigurationData.BulletReloadTime, ConfigurationData.IsBulletReloadDestroyable);
        grenadeReloadTimer = gameObject.AddComponent<Timer>();
        grenadeReloadTimer.Initialize(ConfigurationData.GrenadeReloadTime, ConfigurationData.IsBulletReloadDestroyable);
        playerDashCooldown = gameObject.AddComponent<Timer>();
        playerDashCooldown.Initialize(ConfigurationData.PlayerDashCooldown, ConfigurationData.PlayerDashDestroyable);
        playerInvisibilityFrameTimer = gameObject.AddComponent<Timer>();
        playerInvisibilityFrameTimer.Initialize(ConfigurationData.PlayerInvisibilityFrameCooldown, ConfigurationData.PlayerInvisibilityFrameDestroyable);
        //animator = GetComponent<Animator>();
        //animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Vector3 gunMousePosition = Input.mousePosition;
            Vector3 gunWorldPosition = Camera.main.ScreenToWorldPoint(gunMousePosition);
            Vector3 gunDirection = gunWorldPosition - (Vector3)transform.position;
            float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;


            if (transform.position.x > gunWorldPosition.x)
            {
                if (playerDirection)
                {
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1;
                    transform.localScale = localScale;
                    playerDirection = false;
                }



            }
            else if (transform.position.x < gunWorldPosition.x)
            {
                if (!playerDirection)
                {
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1;
                    transform.localScale = localScale;
                    playerDirection = true;
                }


            }


            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalMovement = Input.GetAxisRaw("Vertical");
            Vector2 playerMovement = new(horizontalMovement, verticalMovement);
            if (!playerInvisibilityFrameTimer.IsCooldown && playerAnimator.GetBool("IsInvincible"))
            {
                playerAnimator.SetBool("IsInvincible", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !playerDashCooldown.IsCooldown)
            {
                playerInvisibilityFrameTimer.StartCooldown();
                playerAnimator.SetBool("IsInvincible", true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(gunWorldPosition.x, gunWorldPosition.y), ConfigurationData.PlayerDashSpeed * Time.deltaTime);
                playerDashCooldown.StartCooldown();
            }
            else if (horizontalMovement == 0 && verticalMovement == 0)
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position = (Vector2)transform.position + playerMovement.normalized * ConfigurationData.PlayerSpeed * Time.deltaTime;

            }

            if (Input.GetButtonDown("Fire1"))
            {
                shootBullet = true;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                shootBullet = false;
            }







            if (shootBullet && !bulletReloadTimer.IsCooldown)
            {
                ShootBullet(worldPosition, angle);
                AudioManager.Instance.PlaySound(AudioManager.SoundType.SHOT, 0.3f);

            }
            if (Input.GetMouseButtonDown(1) && !grenadeReloadTimer.IsCooldown)
            {

                ShootGrenade(worldPosition, angle);
            }
        }
    }
    public float Normalize(float value)
    {

        return (value) * 5;
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("enemy") && !playerInvisibilityFrameTimer.IsCooldown)
        {
            isDead=true;
            Destroy(gameObject);
            Thread.Sleep(1000);
            SceneManager.LoadScene("Menu");
        }
        if (collision.gameObject.CompareTag("experience"))
        {
            Debug.Log("hello");
            experienceSystem.AddExperience(10);
            Destroy(collision.gameObject);
        }

    }
    public void ShootBullet(Vector2 worldPosition,float angle)
    {
        GameObject go = Instantiate(Bullets, childObject.transform.position, Quaternion.identity);
        bulletX = worldPosition.x - gameObject.transform.position.x;
        bulletY = worldPosition.y - gameObject.transform.position.y;
        normalizedBulletX = Normalize(bulletX);
        normalizedBulletY = Normalize(bulletY);
        go.GetComponent<Bullet>().Initialize(new Vector2(normalizedBulletX, normalizedBulletY), angle);
        go.AddComponent<Timer>().Initialize(ConfigurationData.BulletTime, ConfigurationData.IsBulletDestroyable);
        bulletReloadTimer.StartCooldown();
    }
    public void ShootGrenade(Vector2 worldPosition, float angle)
    {
        GameObject go = Instantiate(Grenade, childObject.transform.position, Quaternion.identity);
        grenadeX = worldPosition.x;
        grenadeY = worldPosition.y;
        go.GetComponent<grenade>().Initialize(new Vector2(grenadeX, grenadeY), angle, transform.localScale.x);
        grenadeReloadTimer.StartCooldown();
    }

}
