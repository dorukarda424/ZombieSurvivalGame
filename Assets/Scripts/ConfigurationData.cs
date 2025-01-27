using System.Xml.Linq;
using UnityEngine;

public static class ConfigurationData
{
    static float maxExperience= 50f;

    static float playerSpeed = 5f;
    static float playerDashSpeed = 1000f;
    static float playerDashCooldown = 6f;
    static float playerInvisibilityFrameCooldown = 1f;

    static float maxZombieDistance = 25f;
    static float zombieSpeed = 5f;
    static int enemyPoint = 150;
    static float zombieHealth = 3;
    static float terrainGeneratorPaddingHorizontal = 35;
    static float terrainGeneratorPaddingVertical = 30;

    static float groundVerticalLength = 60;
    static float groundHorizontalLength = 70;

    static float bulletDamageIncreaseAfterLevel = 1f;
    static float bulletDamage = 1f;
    static float bulletTime = 3f;
    static float bulletReloadTime = 0.6f;
    static float grenadeReloadTime = 2f;
    static float grenadeExplosionTime = 1f;
    static float grenadeAnimationTime = 1.45f;

    static float enemySpawnerVerticalPadding = 2f;
    static float enemySpawnerHorizontalPadding = 2f;
    static float enemySpawnTime = 2.0f;

    static bool isBulletReloadDestroyable=false;
    static bool isBulletDestroyable = true;
    static bool isSpawnerDestroyable = false;
    static bool playerDashDestroyable = false;
    static bool playerInvisibilityFrameDestroyable = false;

    public static float BulletTime
    {
        get { return bulletTime; }
    }
    public static float BulletReloadTime
    {
        get { return bulletReloadTime; }
    }
    public static float GrenadeReloadTime
    {
        get { return grenadeReloadTime; }
    }
    public static bool IsBulletReloadDestroyable
    {
        get { return isBulletReloadDestroyable; }
    }
    public static bool IsBulletDestroyable
    {
        get { return isBulletDestroyable; }
    }
    public static bool IsSpawnerDestroyable
    {
        get { return isSpawnerDestroyable; }
    }
    public static float EnemySpawnerVerticalPadding
    {
        get { return enemySpawnerVerticalPadding; }
    }
    public static float EnemySpawnerHorizontalPadding
    {
        get { return enemySpawnerHorizontalPadding; }
    }
    public static float GroundVerticalLength
    {
        get { return groundVerticalLength; }
    }
    public static float GroundHorizontalLength
    {
        get { return groundHorizontalLength; }
    }
    public static float TerrainGeneratorPaddingHorizontal
    {
        get { return terrainGeneratorPaddingHorizontal; }
    }
    public static float TerrainGeneratorPaddingVertical
    {
        get { return terrainGeneratorPaddingVertical; }
    }
    public static float MaxZombieDistance
    {
        get { return maxZombieDistance; }
    }
    public static float ZombieSpeed
    {
        get { return zombieSpeed; }
    }
    public static int EnemyPoint
    {
        get { return enemyPoint; }
    }
    public static float EnemySpawnTime
    {
        get { return enemySpawnTime; }
    }
    public static float PlayerSpeed
    {
        get { return playerSpeed; }
    }
    public static float PlayerDashSpeed
    {
        get { return playerDashSpeed; }
    }
    public static float PlayerDashCooldown
    {
        get { return playerDashCooldown; }
    }
    public static float PlayerInvisibilityFrameCooldown
    {
        get { return playerInvisibilityFrameCooldown; }
    }
    public static float GrenadeExplosionTime
    {
        get { return grenadeExplosionTime; }
    }
    public static float GrenadeAnimationTime
    {
        get { return grenadeAnimationTime; }
    }
    public static bool PlayerDashDestroyable
    {
        get { return playerDashDestroyable; }
    }
    public static bool PlayerInvisibilityFrameDestroyable
    {
        get { return playerInvisibilityFrameDestroyable; }
    }
    public static float ZombieHealth
    {
        get { return zombieHealth; }
    }
    public static float MaxExperience
    {
        get { return maxExperience; }
    }
    public static float BulletDamage
    {
        get { return bulletDamage; }
        set { bulletDamage = value; }
    }
    public static float BulletDamageIncreaseAfterLevel
    {
        get { return bulletDamageIncreaseAfterLevel; }
    }
}
