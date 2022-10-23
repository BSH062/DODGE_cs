using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText; //게임오버시 나타날 텍스트
    public Text timeText; //생존시간 컴포넌트
    public Text recordText; //최고기록 컴포넌트

    private float surviveTime; //생존시간
    private bool isGameover; //게임오버 상태 
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover) //게임 오버가 아닌동안
        {
            surviveTime += Time.deltaTime; //생존시간 갱신
            timeText.text = "Time : " +(int)surviveTime; //deltaTime은 float이기때문에 int로변환
        }
        else //게임오버 상태인경우 (플레이어가 게임상태를 바꿈)
        {
            if(Input.GetKeyDown(KeyCode.R)) //r키를 누르면 초기화면을 불러옴
            {
                SceneManager.LoadScene(0); // " " 이름 자체로 불러와도 되지만 인덱스로도 구분할수있음
            }
        }
       

    }
    public void EndGame() //플레이어가 죽을때 실행
    {
        isGameover=true; //게임오버 상태를 true로 바꿈
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");//PlayerPrefs는 플레이어 설정으로 유니티에서 제공하는 클래스 setfloat는 (키 ,벨류)로 설정,getfloat(키) 로 값을 받아옴
        if (surviveTime>bestTime) //기록된 시간보다 생존시간이 길다면 
        {
            bestTime = surviveTime; //생존시간을 기록
            PlayerPrefs.SetFloat("BestTime", bestTime); //플레이어 프리팹으로 값을 저장해둠 getfloat로 BestTime선언시 저장된값을 불러옴
        }

        recordText.text="BestTime : "+(int)bestTime;
    }
   

}
