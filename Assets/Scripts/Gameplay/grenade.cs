using Unity.VisualScripting;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float bulletAngle;
    public float bulletSpeed;
    public Vector2 movement;
    private float timer;
    Animator grenadeAnimator;
    protected bool isAudioPlayed=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletSpeed = 15f;
        timer = 0f;
        grenadeAnimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(movement.x, movement.y), (bulletSpeed * Time.deltaTime));
        if (timer >= ConfigurationData.GrenadeExplosionTime)
        {
            if (!isAudioPlayed)
            {
                AudioManager.Instance.PlaySound(AudioManager.SoundType.EXPLOTION, 0.4f);
                isAudioPlayed = true;
            }
            grenadeAnimator.SetBool("IsExploded", true);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            if(timer >= ConfigurationData.GrenadeAnimationTime)
            {
                
                Destroy(gameObject);
                timer = 0f;
            }
                
        }
    }
    public void Initialize(Vector2 movements, float angle,float direction)
    {
        movement = movements;
        bulletAngle = angle;
        if (direction < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.y *= -1;
            transform.localScale = localScale;
        }
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, bulletAngle));
    }
}
