using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Rigidbody2D rig;
    SpriteRenderer sprite;
    Vector2 moveDir;
    public Image img;

    public float isJump = 1;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        img.fillAmount = isJump;
        CharacterMove();
        rig.velocity = moveDir + new Vector2(0, rig.velocity.y);
    }
    void CharacterMove()
    {

        x = Input.GetAxisRaw("Horizontal") * 5;
        if(x > 0)
        {
            sprite.flipX = true;
        }
        else if(x < 0)
        {
            sprite.flipX = false;
        }
        moveDir.x = x;
        if(Input.GetAxis("Jump")!= 0 && isJump > 0)
        {
            //rig.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
            rig.velocity = new Vector2(rig.velocity.x, 3);
            isJump -= Time.deltaTime;
            isJump = Mathf.Clamp(isJump, 0, 1);
        }
    }
}
