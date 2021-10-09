using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragButton : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 centerPos;
    private Vector2 size;
    public RectTransform JudgeLine;

    // 下底边与上底边的滑动限制
    private float[] limitY = new float[2];
    public float SafeOffset = 5f;

    // 0 = 无状态， 1 = 正在重置位置，  2 = 等待重置位置，  3 = 拖动中
    // 懒得另外写一个Enum，用一个byte代替
    private byte resetStatus = 0;
    void Start()
    {
        centerPos = transform.position;
        size = ((RectTransform)transform).rect.size / 2;

        // init the limit of judge line
        limitY[0] = JudgeLine.position.y - JudgeLine.rect.size.y / 2 + SafeOffset;
        limitY[1] = JudgeLine.position.y + JudgeLine.rect.size.y / 2 - SafeOffset;
    }
    void Update()
    {
        if (resetStatus == 1)
        {
            // 将滑块的位置重置回中间（非线性）
            var movePos = (centerPos - (Vector2)transform.position) / 5;
            transform.position += (Vector3)movePos;
        }
    }

    private Vector2 offsetPos; 
    public void StartReset()
    {
        // 确认是否要重置
        if (resetStatus == 2)
        {
            resetStatus = 1;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        var newPos = eventData.position - offsetPos;
        // limit x pos
        newPos.x = centerPos.x;
        // limit move area
        if (newPos.y - size.y < limitY[0])
        {
            newPos.y = limitY[0] + size.y;
        }

        // limit move area
        if (newPos.y + size.y > limitY[1])
        {
            newPos.y = limitY[1] - size.y;
        }
        transform.position = newPos;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        // 手按下，开始滑动
        offsetPos = eventData.position - (Vector2)transform.position;
        resetStatus = 3;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // 手放开，准备重置
        if (resetStatus != 2)
        {
            resetStatus = 2;
            Invoke("StartReset", 0.25f);
        }
    }
}
