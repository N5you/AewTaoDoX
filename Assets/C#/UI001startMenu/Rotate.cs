using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    private bool isRotating = false;
    public float rotateSpeed = 10;
    // Use this for initialization

    private void OnMouseDown()
    {
        isRotating = true;
    }

    private void OnMouseUp()
    {
        isRotating = false;
    }

    private void Update()
    {
        if (isRotating)
        {
            RotateView();
        }
    }

    // Update is called once per frame
    void RotateView()
    {
        //Input .GetAxis ("Mouse X"); 得到鼠标在水平方向的滑动
        //Input .GetAxis ("Mouse Y");得到鼠标在垂直方向的滑动
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));
    }
}