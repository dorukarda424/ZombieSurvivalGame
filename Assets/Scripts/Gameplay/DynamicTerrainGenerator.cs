using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicTerrainGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    protected List<GameObject> myGroundList = new();

    [SerializeField]
    GameObject player;

    private Player playerScript;

    protected float groundHorizontalLength;
    protected float groundVerticalLength;
    protected float terrainGeneratorPaddingHorizontal;
    protected float terrainGeneratorPaddingVertical;

    protected SpriteRenderer spriteRenderer;
    // Reference to the sprite you want to display
    public Sprite imageToDisplay;

    void Start()
    {
        GameObject newImageObject = new GameObject("NewImage");
        groundHorizontalLength=ConfigurationData.GroundHorizontalLength;
        groundVerticalLength=ConfigurationData.GroundVerticalLength;
        terrainGeneratorPaddingHorizontal = ConfigurationData.TerrainGeneratorPaddingHorizontal;
        terrainGeneratorPaddingVertical = ConfigurationData.TerrainGeneratorPaddingVertical;
        playerScript=player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.isDead)
        {
            foreach (GameObject item in myGroundList)
            {
                spriteRenderer = item.GetComponent<SpriteRenderer>();
                if (player.transform.position.x < item.transform.position.x - terrainGeneratorPaddingHorizontal)
                {


                    if (GroundIsNotVisible(spriteRenderer.bounds.min.x, spriteRenderer.bounds.max.x, player.transform.position.x, true))
                    {
                        TransformGroundPositionHorizontal(item, true);
                    }
                }
                else if (player.transform.position.x > item.transform.position.x + terrainGeneratorPaddingHorizontal)
                {

                    if (GroundIsNotVisible(spriteRenderer.bounds.min.x, spriteRenderer.bounds.max.x, player.transform.position.x, false))
                    {
                        TransformGroundPositionHorizontal(item, false);
                    }

                }
                if (player.transform.position.y < item.transform.position.y - terrainGeneratorPaddingVertical)
                {


                    if (GroundIsNotVisible(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y, player.transform.position.y, true))
                    {
                        TransformGroundPositionVertical(item, true);
                    }
                }
                else if (player.transform.position.y > item.transform.position.y + terrainGeneratorPaddingVertical)
                {

                    if (GroundIsNotVisible(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y, player.transform.position.y, false))
                    {
                        TransformGroundPositionVertical(item, false);
                    }

                }


            }
        }
        
    }
    public bool GroundIsNotVisible(float minPosition, float maxPosition, float playerPosition, bool isMin)
    {

        if (isMin)
        {
            if (playerPosition > minPosition && playerPosition < maxPosition)
                return false;
            else
                return true;
        }
        else
            return true;

    }
    public void TransformGroundPositionHorizontal(GameObject ground, bool isMin)
    {
        if (isMin)
        {
            ground.transform.position = new Vector3(ground.transform.position.x - groundHorizontalLength, ground.transform.position.y, ground.transform.position.z);
        }
        else
        {
            ground.transform.position = new Vector3(ground.transform.position.x + groundHorizontalLength, ground.transform.position.y, ground.transform.position.z);
        }


    }
    public void TransformGroundPositionVertical(GameObject ground, bool isMin)
    {
        if (isMin)
        {
            ground.transform.position = new Vector3(ground.transform.position.x, ground.transform.position.y - groundVerticalLength, ground.transform.position.z);
        }
        else
        {
            ground.transform.position = new Vector3(ground.transform.position.x, ground.transform.position.y + groundVerticalLength, ground.transform.position.z);
        }
    }
}
