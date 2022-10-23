using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet; //생성할 총알의 원본 프리팹을 넣어주는곳
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기 

    float timeAfterSpawn; //최근 생성 시점에서 지난 시간 
    float spawnRate;//생성 주기
    Transform target; //발사할 대상 (총알이 노려야할 타겟)
    
    void Start()
    {
        //생성이후 누적시간을 0으로 초기화
        timeAfterSpawn = 0f;
        //생성주기는 0.5~3초로 랜덤하게 지정  
        spawnRate=Random.Range(spawnRateMin, spawnRateMax);
        //그냥 퍼블릭으로 선언해서 넣어줘도 됨 FInd는 연산값이 비싸서 사용하지 않는 방향으로 구현하도록 해야함
        target = FindObjectOfType<PlayerController>().transform;
        
    }

    void Update()
    {
        //시간 갱신
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn>=spawnRate) //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        {
            timeAfterSpawn = 0f; //시간 초기화 
            //Bullet의 복제본을 bullet에 저장
            GameObject bullet =Instantiate(Bullet,transform.position,transform.rotation);
            //총알이 플레이어를 바라도록 회전 
            bullet.transform.LookAt(target);

            //다음 생성간격을 랜덤하게 지정 
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
