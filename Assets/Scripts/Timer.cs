using UnityEngine;

public class Timer : MonoBehaviour
{
    protected float timer;
    protected bool IsDestroyable;
    protected bool isCooldown = false;
    protected float gameObjectDuration;

    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (IsDestroyable)
        {
            if (timer >= gameObjectDuration)
                DestroyGameObject();
        }
        else if (isCooldown)
        {
            {
                if (timer >= gameObjectDuration)
                    isCooldown = false;
            }
        }



    }
    public void Initialize(float duration, bool IsDestroyable)
    {
        gameObjectDuration = duration;
        this.IsDestroyable = IsDestroyable;
    }
    public void RestartTimer()
    {
        timer = 0;
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public bool IsCooldown
    {
        get { return isCooldown; }
    }
    public void StartCooldown()
    {
        isCooldown = true;
        RestartTimer();
    }
}
