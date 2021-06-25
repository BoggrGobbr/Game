using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f, initialAngle;
    [SerializeField] private LayerMask collisionMask, entities;
    const float skinWidth = 0.15f;
    public BoxCollider2D bulletCollider;
    ModifierLists modifiers;
    bool visible = true;
    Coroutine despawn;
    int x = 0;
    void Start()
    {
        bulletCollider = GetComponent<BoxCollider2D>();
        rb.velocity = transform.right * speed;
        modifiers = GameObject.Find("Modifiers").GetComponent<ModifierLists>();
        initialAngle = transform.rotation.eulerAngles.z;
        Debug.Log(initialAngle);
    }

    void FixedUpdate()
    {
        float directionX = Mathf.Sign(rb.velocity.x);
        float rayLength = Mathf.Abs(rb.velocity.x) + skinWidth;
        if (bulletCollider.IsTouchingLayers(collisionMask))
        {
            if (bulletCollider.IsTouchingLayers(entities))
            {
                StartCoroutine(SceneSwitch());
            }
            Destroy(gameObject);
            
        }
        if (modifiers.bulletSin)
        {
            float angle = initialAngle + (Mathf.Cos(x++ * modifiers.bulletSinFrequency) * modifiers.bulletSignMagnitude);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.velocity = transform.right * speed;
        }
        if (modifiers.slowBullet)
            rb.velocity = transform.right * speed * (modifiers.bulletSpeedPercentage / 100);
         
    }

    void OnBecameInvisible()
    {
        despawn = StartCoroutine(DespawnBullet());     
    }

    private void OnBecameVisible()
    {
        if(despawn != null)
        StopCoroutine(despawn);
    }

    IEnumerator SceneSwitch()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("Death Screen");
        yield return load;
        SceneManager.UnloadSceneAsync("Game");
    }

    IEnumerator DespawnBullet()
    {
        visible = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        
    }

}
