using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TpsCameraControl : MonoBehaviour
{
    public Transform targetTank;// �Ǐ]�Ώۂ̃^���N��Transform
    [SerializeField]
    private float distance = 3.0f ;// �J�����ƃ^���N�̑��ΓI�Ȉʒu
    [SerializeField]
    private float height = 2.0f; // �^���N����̍���
    [SerializeField]
    private float smoothSpeed = 10f;// �Ǐ]���x


    private void FixedUpdate()
    {
        if (targetTank == null)
        {
            Debug.LogWarning("�Ǐ]�Ώۂ̃^���N���w�肳��Ă��܂���");
            return;
        }

        // �ڕW�ʒu���v�Z
        Vector3 desiredPosition = targetTank.position - targetTank.forward * distance + Vector3.up * height;
        // ���݈ʒu�ƖڕW�ʒu�̕�ԁi�X���[�Y�ɓ����j
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // �J�����ʒu���X�V
        transform.position = smoothedPosition;

        // �^�[�Q�b�g����������
        transform.LookAt(targetTank);
    }
}
