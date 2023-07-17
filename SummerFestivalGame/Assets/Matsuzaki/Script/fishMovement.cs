using UnityEngine;
using UnityEngine.UIElements;

public class fishMovement : MonoBehaviour
{
    [Header("�ړ����x")]       public float moveSpeed;             // �ړ����x
    /*[Header("�X�R�A�i���z�j")] public int Score;          */         //�X�R�A�i���z�j
    [Header("�ŏ���]���x")]   public float minRotationTime = 1f;  // �ŏ���]���ԁi���󃂃f���ƍ��킹�Ȃ��Ɣ��ʂ��Â炢�ł��j
    [Header("�ő��]���x")]   public float maxRotationTime = 3f;  // �ő��]���ԁi���󃂃f���ƍ��킹�Ȃ��Ɣ��ʂ��Â炢�ł��j
    [Header("�ŏ���~����")]   public float minIdleTime;           // �ŏ���~����
    [Header("�ő��~����")]   public float maxIdleTime;           // �ő��~����
    [Header("�����̍��W�擾")] public Transform _transform;                                    //

    private Vector3 targetPosition;                                 // �ړI�n�̍��W
    private Quaternion targetRotation;                              // �ړI�n�̉�]

    private float rotationTimer;                                    // ��]�^�C�}�[
    private float idleTimer;                                        // ��~�^�C�}�[
    /*private float rotationSpeed = Mathf.Infinity;    */               // ��]���x

    private void Start()
    {
        //���̖ړI�n�����肵��]����
        SetNewTarget();
    }

    private void Update()
    {
        //�ړI�n�Ɉړ����I�����ꍇ
        if (IsAtTargetPosition())
        {
            //��莞�ԃ����_���ŐÎ~
            idleTimer -= Time.deltaTime;
            //��~���Ɏ��̖ړI�n�����肵��]����
            if (idleTimer <= 0f) { SetNewTarget(); }
        }
        else
        { MoveTowardsTarget(); }
    }

    private void SetNewTarget()
    {
        // �����_���ȍ��W������
        targetPosition = GenerateRandomPosition();

        // ��]���Ԃ������_���ɐݒ�
        rotationTimer = Random.Range(minRotationTime, maxRotationTime);

        // ��~���Ԃ������_���ɐݒ�
        idleTimer = Random.Range(minIdleTime, maxIdleTime);

        // �ړI�n�̉�]��ݒ�
        targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);

        RotateTowardsTarget(targetPosition - transform.position);
    }

    private Vector3 GenerateRandomPosition()
    {
        //��ʊO�֏o�����Ȃ��悤�ɒ���
        float minX = -12f;
        float maxX = 12f;
        float minY = -7f;
        float maxY = 9f;

        //�����_���Ŏ��̍��W������
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPos;
    }

    private bool IsAtTargetPosition()
    {
        //�ړI�l�̍��W�ϊ�
        return transform.position == targetPosition;
    }

    private void MoveTowardsTarget()
    {
        //���݂̍��W����ړI�n�ւ̈ړ�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsTarget(Vector3 dir)
    {
        if (rotationTimer <= 0f) { return; }

        rotationTimer -= Time.deltaTime;

        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var angles = new Vector3(angle, 90, -90);
        _transform.rotation = Quaternion.Euler(angles);
    }
}

//�e�N���X�ɋ�̃I�u�W�F�N�g��z�u�i�X�N���v�g�Y�t�j�ˎq�N���X�ɋ����̃��f���Y�t�Ŏg�p


