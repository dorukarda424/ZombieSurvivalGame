using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static DataManager Instance;
    public Vector3 lowerBound;
    public Vector3 upperBound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    private void Update()
    {
        
    }

   
    public void GetCameraPositions()
    {
        lowerBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        upperBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        
    }
}
