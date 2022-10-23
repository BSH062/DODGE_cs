using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=8f;
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig= GetComponent<Rigidbody>();
        rig.velocity = transform.forward * speed;//transform.forward ==Vector3의 z방향을 의미함 

        Destroy(gameObject, 3f);//3초뒤 게임 오브젝트(총알) 파괴
    }

    private void OnTriggerEnter(Collider other) //트리거는 콜라이더와 다르게 물리계산을 하지않고 충돌만 감지함 꼭 자기자신이 triger가 아니라도 상대방쪽이 트리거 상태라도 적용됨
    {
        if(other.tag=="Player") //충돌한 대상의 태그가 플레이어 일경우 
        {
             PlayerController player=other.GetComponent<PlayerController>(); //상대방의 오브젝트에서 플레이어 컨트롤러 라는 컴포넌트를 가져옴 
            if(player!=null) //player 안에 컴포넌트가 들어있다면 
                player.Die(); //플레이어 컨트롤러 안에 Die 메서드 실행
        }
    }
}
