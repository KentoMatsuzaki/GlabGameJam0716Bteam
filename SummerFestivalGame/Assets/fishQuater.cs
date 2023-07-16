using UnityEngine;

public class fishQuater : MonoBehaviour
{
    // �ő�̉�]�p���x[deg/s]
    [SerializeField] private float _maxAngularSpeed = Mathf.Infinity;

    // �i�s�����Ɍ����̂ɂ����邨���悻�̎���[s]
    [SerializeField] private float _smoothTime =0;

    private Transform _transform;

    // �O�t���[���̈ʒu
    private Vector3 _prevPos;

    private float _currentAngularVelocity;

    private void Start()
    {
        _transform = transform;

        _prevPos = _transform.position;
    }

    private void Update()
    {
        // ���݃t���[���̈ʒu
        var position = _transform.position;

        // �ړ��ʂ��v�Z
        var move = position - _prevPos;

        // ����Update�Ŏg�����߂̑O�t���[���ʒu�X�V
        _prevPos = position;

        // �Î~���Ă����Ԃ��ƁA�i�s���������ł��Ȃ����߉�]���Ȃ�
        if (move == Vector3.zero) return;

        // �i�s�����i�ړ��ʃx�N�g���j�Ɍ����悤�ȃN�H�[�^�j�I�����擾
        var targetRot = Quaternion.LookRotation(move, Vector3.up);

        // ���݂̌����Ɛi�s�����Ƃ̊p�x�����v�Z
        var diffAngle = Vector3.Angle(_transform.forward, move);
        // ���݃t���[���ŉ�]����p�x�̌v�Z
        var rotAngle = 
            Mathf.SmoothDampAngle(0,diffAngle,ref _currentAngularVelocity,_smoothTime,_maxAngularSpeed);
        // ���݃t���[���ɂ������]���v�Z
        var nextRot = Quaternion.RotateTowards(_transform.rotation,targetRot,rotAngle);

        // �I�u�W�F�N�g�̉�]�ɔ��f
        _transform.rotation = nextRot;
    }
}