using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gunMousePosition = Input.mousePosition;
        Vector3 gunWorldPosition = Camera.main.ScreenToWorldPoint(gunMousePosition);
        Vector3 gunDirection = gunWorldPosition - (Vector3)transform.position;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        if(player.transform.localScale.x<0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180+angle));
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
