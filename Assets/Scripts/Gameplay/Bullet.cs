using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletAngle;
    public float bulletSpeed;
    public Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(Vector2 movements, float angle)
    {
        movement = movements;
        bulletAngle = angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, bulletAngle));
    }
    void Start()
    {
        
        bulletSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position= Vector2.MoveTowards(transform.position,new Vector2(movement.x + transform.position.x, movement.y+transform.position.y), (bulletSpeed * Time.deltaTime));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
          
            Destroy(gameObject);
            
        }
    }

}
