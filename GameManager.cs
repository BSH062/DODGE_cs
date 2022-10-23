using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; //���ӿ����� ��Ÿ�� �ؽ�Ʈ
    public Text timeText; //�����ð� ������Ʈ
    public Text recordText; //�ְ��� ������Ʈ

    private float surviveTime; //�����ð�
    private bool isGameover; //���ӿ��� ���� 
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover) //���� ������ �ƴѵ���
        {
            surviveTime += Time.deltaTime; //�����ð� ����
            timeText.text = "Time : " +(int)surviveTime; //deltaTime�� float�̱⶧���� int�κ�ȯ
        }
        else //���ӿ��� �����ΰ�� (�÷��̾ ���ӻ��¸� �ٲ�)
        {
            if(Input.GetKeyDown(KeyCode.R)) //rŰ�� ������ �ʱ�ȭ���� �ҷ���
            {
                SceneManager.LoadScene(0); // " " �̸� ��ü�� �ҷ��͵� ������ �ε����ε� �����Ҽ�����
            }
        }
       

    }
    public void EndGame() //�÷��̾ ������ ����
    {
        isGameover=true; //���ӿ��� ���¸� true�� �ٲ�
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");//PlayerPrefs�� �÷��̾� �������� ����Ƽ���� �����ϴ� Ŭ���� setfloat�� (Ű ,����)�� ����,getfloat(Ű) �� ���� �޾ƿ�
        if (surviveTime>bestTime) //��ϵ� �ð����� �����ð��� ��ٸ� 
        {
            bestTime = surviveTime; //�����ð��� ���
            PlayerPrefs.SetFloat("BestTime", bestTime); //�÷��̾� ���������� ���� �����ص� getfloat�� BestTime����� ����Ȱ��� �ҷ���
        }

        recordText.text="BestTime : "+(int)bestTime;
    }
   

}
