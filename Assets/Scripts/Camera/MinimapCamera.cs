
using UnityEngine;

namespace Complete
{
    public class MnimapCamera : MonoBehaviour
    {
        // 追従対象のプレイヤーオブジェクト
        [SerializeField] private Transform m_Target;

        // カメラの高さ
        [SerializeField] private float m_Height = 20f;

        // カメラの追従速度
        [SerializeField] private float m_FollowSpeed = 5f;

        private void FixedUpdate()
        {
            // 追従対象が指定されていない場合は何もしない
            if (m_Target == null)
            {
                m_Target = GameObject.Find("CompleteTank(Clone)").transform;
                //Debug.LogWarning("追従対象が指定されていません。");
                return;
            }

            // カメラの位置を更新
            UpdatePosition();

            // カメラの回転を更新（真下を向く）
            UpdateRotation();
        }

        private void UpdatePosition()
        {
            // プレイヤーの真上の目標位置を計算
            Vector3 targetPosition = m_Target.position + Vector3.up * m_Height;

            // 現在のカメラ位置から目標位置にスムーズに移動
            transform.position = Vector3.Lerp(transform.position, targetPosition, m_FollowSpeed * Time.deltaTime);
        }

        private void UpdateRotation()
        {
            // カメラを常に真下を向くように設定
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}