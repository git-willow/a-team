using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TpsCameraControl : MonoBehaviour
{
    public Transform targetTank;// 追従対象のタンクのTransform
    [SerializeField]
    private float distance = 3.0f ;// カメラとタンクの相対的な位置
    [SerializeField]
    private float height = 2.0f; // タンクからの高さ
    [SerializeField]
    private float smoothSpeed = 10f;// 追従速度


    private void FixedUpdate()
    {
        if (targetTank == null)
        {
            Debug.LogWarning("追従対象のタンクが指定されていません");
            return;
        }

        // 目標位置を計算
        Vector3 desiredPosition = targetTank.position - targetTank.forward * distance + Vector3.up * height;
        // 現在位置と目標位置の補間（スムーズに動く）
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // カメラ位置を更新
        transform.position = smoothedPosition;

        // ターゲット方向を向く
        transform.LookAt(targetTank);
    }
}
