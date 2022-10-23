using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody rig;//������ �ٵ� �̿��� ���� �������� �ʿ���
    [Range(0, 10)] public float speed = 10.0f;  //[Range] �� ����ϸ� �ν����Ϳ��� ���ڰ� �ƴ� �巡�׷� ���� ����
   
    void Start()
    {
        rig = GetComponent<Rigidbody>(); //������ �ٵ�
       
    }
   
    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //GetAxis == -1 ,0 ,1 �� ǥ�� , Raw �� -1 ~1 ���� �Ҽ������� ǥ���� ���� �ε巯�� �����ӿ� ��� 
        float v = Input.GetAxisRaw("Vertical");
       
        rig.velocity = new Vector3(h, 0, v) * speed; //�ݶ��̴� �ձ� ������ ���ν�Ƽ ���
    }
    public void Die()
    {
        gameObject.SetActive(false); //�÷��̾� ���� ������Ʈ ��Ȱ��ȭ
        GameManager gamemanager=FindObjectOfType<GameManager>(); //���ӸŴ����� ������Ʈ Ÿ������ ã�� (������ ��μ� ������Ʈ���� ����ϸ� �ȵ�)
        gamemanager.EndGame();//���� �Ŵ����� �ִ� EndGame����
    }
}
