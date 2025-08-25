using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5; // 수평감도
    [SerializeField]
    private float rotCamYAxisSpeed = 5; // 수직감도

    private float limitMinX = -50; // X축 회전 최소
    private float limitMaxX = 50; // X축 회전 최대
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;
        eulerAngleX += mouseY * rotCamXAxisSpeed;

        // 
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }    

private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}