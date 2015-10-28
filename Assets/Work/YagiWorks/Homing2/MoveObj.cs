using UnityEngine;
using System.Collections;

public class MoveObj : MonoBehaviour
{
    public BezierPoint p0;
    public BezierPoint p1;
    public BezierPoint p2;
    public float moveTime;


    private float nowTime;
   
    private int movenumber = 0;

    void Start()
    {
        nowTime = 0;
    }

    void Update()
    {
        if (movenumber==0&&Input.GetKeyDown("space"))
        {
            movenumber=1;
        }

        if (movenumber!=0)
        {
            if (movenumber == 1)
            {
                Vector3 currentPoint = BezierCurve.GetPoint(p0, p1, nowTime / moveTime);
                transform.position = currentPoint;
            }
            if (movenumber == -1)
            {
                Vector3 currentPoint = BezierCurve.GetPoint(p1, p2, nowTime / moveTime);
                transform.position = currentPoint;
            }
            nowTime += Time.deltaTime;
            if (nowTime > moveTime)
            {
                if (movenumber == -1) movenumber = 0;
                nowTime = 0;
                movenumber=movenumber*-1;
            }
        }
    }
}
