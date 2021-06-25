using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpSystem : MonoBehaviour
{
    [SerializeField] int maxHp = 100, hp; public int MaxHp { get { return maxHp; } } public int Hp {  get { return hp; } }
    [SerializeField] GameObject sprite;
    [SerializeField] float timeToFlash, intervalTime;
    [SerializeField] bool isFlashing = false; public bool IsFlashing { get { return isFlashing; } }
    AnimationManager animationManager;
    PlayerInput player;
    [SerializeField] float hitPushSpeed;
    void Start()
    {
        hp = maxHp;
        sprite = transform.Find("Player Sprite").gameObject;
        player = GetComponent<PlayerInput>();
    }

    public void TakeDamage(int amount, int knockbackDirection)
    {     
        if (!isFlashing)
        {
            hp -= amount;
            player.knockbackVelocity.y = player.Knockback;
            player.knockbackVelocity.x = player.Knockback * knockbackDirection;  //knock player back in the direction they got hit from
            StartCoroutine(DoFlash());
        }
        
    }

    public void Heal(int amount)
    {
        if (hp + amount > maxHp)
            hp = maxHp;
        hp += amount;
    }
    void Update()
    {
        if(hp<=0)
        {
            StartCoroutine(SceneSwitch());
            Cursor.visible = true; //WILL TAKE THIS OUT LATER
        }
    }

    IEnumerator SceneSwitch()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("Death Screen");
        yield return load;
        SceneManager.UnloadSceneAsync("Game");
    }

    IEnumerator DoFlash()
    {
        float flashTimer = 0.0f;
        isFlashing = true;
        while (flashTimer < timeToFlash)
        {
            flashTimer += Time.deltaTime; // TIME TO FLASH IS NOT REAL TIME SECONDS BECAUSE OF THE YIELD
            Debug.Log("DELTATIME: " + flashTimer);
            sprite.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(intervalTime); //stops the routine and keeps sprite off for intervaltime seconds
            sprite.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(intervalTime); // keeps sprite on for interval time seconds
        }
        isFlashing = false;

    }
}
