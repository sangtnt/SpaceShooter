using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static Vector2 GetCameraMax()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        return max;
    }

    public static Vector2 GetCameraMin()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        return min;
    }
    public static Vector2 GetObjectMaxLimitInCamera(GameObject o)
    {
        Vector2 max = GetCameraMax();
        max.x -= o.transform.localScale.x / 2;
        max.y -= o.transform.localScale.y / 2;
        return max;
    }
    public static Vector2 GetObjectMinLimitInCamera(GameObject o)
    {
        Vector2 min = GetCameraMin();
        min.x += o.transform.localScale.x / 2;
        min.y += o.transform.localScale.y / 2;
        return min;
    }
}
