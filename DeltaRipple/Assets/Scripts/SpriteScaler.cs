using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    [Header("Screen.width/Screen.height*2*orthographicSize")]
    [Header("游戏的有效内容宽度")]
    public float vaildWidth;

    private void Awake()
    {
        Adaptation();
    }

    /// <summary>
    /// 适配(通常版)
    /// </summary>
    private void Adaptation()
    {
        float orthographicSize = 16;
        GetComponent<Camera>().orthographicSize = orthographicSize;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
