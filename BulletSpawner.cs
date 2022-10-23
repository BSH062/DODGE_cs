using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet; //������ �Ѿ��� ���� �������� �־��ִ°�
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ� 

    float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð� 
    float spawnRate;//���� �ֱ�
    Transform target; //�߻��� ��� (�Ѿ��� ������� Ÿ��)
    
    void Start()
    {
        //�������� �����ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //�����ֱ�� 0.5~3�ʷ� �����ϰ� ����  
        spawnRate=Random.Range(spawnRateMin, spawnRateMax);
        //�׳� �ۺ����� �����ؼ� �־��൵ �� FInd�� ���갪�� ��μ� ������� �ʴ� �������� �����ϵ��� �ؾ���
        target = FindObjectOfType<PlayerController>().transform;
        
    }

    void Update()
    {
        //�ð� ����
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn>=spawnRate) //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        {
            timeAfterSpawn = 0f; //�ð� �ʱ�ȭ 
            //Bullet�� �������� bullet�� ����
            GameObject bullet =Instantiate(Bullet,transform.position,transform.rotation);
            //�Ѿ��� �÷��̾ �ٶ󵵷� ȸ�� 
            bullet.transform.LookAt(target);

            //���� ���������� �����ϰ� ���� 
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
