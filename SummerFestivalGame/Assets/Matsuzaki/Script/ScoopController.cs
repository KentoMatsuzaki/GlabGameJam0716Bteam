using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoopController : MonoBehaviour
{
    //�J�[�\�����W���擾���邽�߂̕ϐ�
    Vector3 _screenPoint;
    //�X�R�A�p�̕ϐ�
    int _score = 0;
    //�X�R�A�p�̃e�L�X�g
    [SerializeField] Text _text;
    //����1�̃X�R�A
    [SerializeField] int _fish1Point;

    void Start()
    {
        
    }

    
    void Update()
    {
        this._screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(a);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("T");
        if(other.gameObject.tag == "Fish1")
        {
            Debug.Log("Fish1");
            _score += _fish1Point;
        }

        SetScore();
    }

    void SetScore()
    {
        _text.text = _score.ToString();
    }
}
