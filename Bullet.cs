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
        rig.velocity = transform.forward * speed;//transform.forward ==Vector3�� z������ �ǹ��� 

        Destroy(gameObject, 3f);//3�ʵ� ���� ������Ʈ(�Ѿ�) �ı�
    }

    private void OnTriggerEnter(Collider other) //Ʈ���Ŵ� �ݶ��̴��� �ٸ��� ��������� �����ʰ� �浹�� ������ �� �ڱ��ڽ��� triger�� �ƴ϶� �������� Ʈ���� ���¶� �����
    {
        if(other.tag=="Player") //�浹�� ����� �±װ� �÷��̾� �ϰ�� 
        {
             PlayerController player=other.GetComponent<PlayerController>(); //������ ������Ʈ���� �÷��̾� ��Ʈ�ѷ� ��� ������Ʈ�� ������ 
            if(player!=null) //player �ȿ� ������Ʈ�� ����ִٸ� 
                player.Die(); //�÷��̾� ��Ʈ�ѷ� �ȿ� Die �޼��� ����
        }
    }
}
