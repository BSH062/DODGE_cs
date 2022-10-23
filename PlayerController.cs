using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody rig;//리지드 바디를 이용한 무브 구현으로 필요함
    [Range(0, 10)] public float speed = 10.0f;  //[Range] 를 사용하면 인스펙터에서 숫자가 아닌 드래그로 조절 가능
   
    void Start()
    {
        rig = GetComponent<Rigidbody>(); //리지드 바디
       
    }
   
    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //GetAxis == -1 ,0 ,1 로 표현 , Raw 는 -1 ~1 까지 소수점으로 표현함 좀더 부드러운 움직임에 사용 
        float v = Input.GetAxisRaw("Vertical");
       
        rig.velocity = new Vector3(h, 0, v) * speed; //콜라이더 뚫기 방지로 벨로시티 사용
    }
    public void Die()
    {
        gameObject.SetActive(false); //플레이어 게임 오브젝트 비활성화
        GameManager gamemanager=FindObjectOfType<GameManager>(); //게임매니저를 오브젝트 타입으로 찾음 (연산이 비싸서 업데이트에서 사용하면 안됨)
        gamemanager.EndGame();//게임 매니저에 있는 EndGame실행
    }
}
