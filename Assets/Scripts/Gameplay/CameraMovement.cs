using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject playerObject;
    private Player playerScript;
    void Start()
    {
        playerScript = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.isDead)
        {
            transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, transform.position.z);
        }

    }
}
