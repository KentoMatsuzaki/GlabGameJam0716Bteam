using UnityEngine;

public class fishRand : MonoBehaviour
{
    [SerializeField] private GameObject fish;     //�����������I�u�W�F�N�g���C���X�y�N�^�[������
    [SerializeField] private int speed = 0;       //�����ړ��̃X�s�[�h
    Vector3 movePosition;                         //�ړI�n
    
    void Start()
    {
        //�ړI�n��ݒ�
        movePosition = moveRandomPosition();  
    }

    void Update()
    {
        //player�I�u�W�F�N�g���ړI�n�ɓ��B����ƁA�ړI�n���Đݒ�
        if (movePosition == fish.transform.position)    
        {
            movePosition = moveRandomPosition();        
        }
        //�B������(player�I�u�W�F�N�g,�ړI�n�Ɉړ�, �ړ����x)
        this.fish.transform.position =                  
            Vector3.MoveTowards(fish.transform.position, movePosition, speed * Time.deltaTime);  
    }

    private Vector3 moveRandomPosition()   
    {
        // �ړI�n�����ix��y�������_���l�j
        Vector3 randomPos = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 30);
        return randomPos;
    }
}