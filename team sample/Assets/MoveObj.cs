using UnityEngine;
using System.Collections;

public class MoveObj : MonoBehaviour
{
    public BezierPoint p1;
    public BezierPoint p2;

    private float nowTime;
    private float moveTime = 2f;

    void Start()
    {
        nowTime = 0;
    }

    void Update()
    {
        Vector3 currentPoint = BezierCurve.GetPoint(p1, p2, nowTime / moveTime);
        transform.position = currentPoint;

        nowTime += Time.deltaTime;
        if (nowTime > moveTime) nowTime = 0;
    }
}