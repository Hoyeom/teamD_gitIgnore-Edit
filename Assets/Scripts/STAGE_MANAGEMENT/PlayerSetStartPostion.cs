using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace STAGE_MANAGEMENT
{
    public class PlayerSetStartPostion : MonoBehaviour
    {
        //[Header("������ų �÷��̾�")]
        private GameObject Player;
        
        private void OnEnable()
        {
            // ���� Scene�� �÷��̾ ������ Ȯ��
            if (GameObject.FindGameObjectWithTag("Player") == null) 
            {
                // �÷��̾� ����
                Instantiate(Player, this.transform);
            }
            else
            {
                // �÷��̾� ���� ���� ����
                GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position;
            }
        }
    }
}

