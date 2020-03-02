using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public GameObject obstacle; 
    private bool startTimer; //是否开始掉落
    private float fallTime;  //倒计时
    private Rigidbody2D my_Body;  

    private void Awake()
    {
        my_Body = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// 初始化台阶更换皮肤
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="fallTime"></param>
    /// <param name="obstacleDir"></param>
    public void Init(Sprite sprite, float fallTime, int obstacleDir)
    {
        my_Body.bodyType = RigidbodyType2D.Static;
        this.fallTime = fallTime;
        startTimer = true;
        for (int i = 0; i < spriteRenderers.Length; i++)    //朝左边
        {
            spriteRenderers[i].sprite = sprite;
        }

        if (obstacleDir == 0)//朝右边
        {
            if (obstacle != null)
            {
                obstacle.transform.localPosition = new Vector3(-obstacle.transform.localPosition.x,
                    obstacle.transform.localPosition.y, 0);
            }
        }
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameStarted == false || GameManager.Instance.PlayerIsMove == false) return;

        if (startTimer)
        {
            fallTime -= Time.deltaTime;
            if (fallTime < 0)//倒计时结束
            {
                //掉落
                startTimer = false;
                if (my_Body.bodyType != RigidbodyType2D.Dynamic)
                {
                    my_Body.bodyType = RigidbodyType2D.Dynamic;
                    StartCoroutine(DealyHide());
                }
            }
        }
        if (transform.position.y - Camera.main.transform.position.y < -6)
        {
            StartCoroutine(DealyHide());
        }
    }
    private IEnumerator DealyHide()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
