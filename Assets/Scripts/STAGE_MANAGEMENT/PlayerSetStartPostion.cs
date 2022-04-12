using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace STAGE_MANAGEMENT
{
    public class PlayerSetStartPostion : MonoBehaviour
    {
        //[Header("������ų �÷��̾�")]
        private GameObject player;
        
        private void OnEnable()
        {
            Respawn();
        }

        public void Respawn()
        {
            // ���� Scene�� �÷��̾ ������ Ȯ��
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                // �÷��̾� ���� ���� ����
                
                player.transform.position = this.transform.position;
                //player.GetComponent<CharacterController>().Move(this.transform.position);
                Debug.Log($"�÷��̾� : {player.transform.position} / ���� : {this.transform.position}");
            }
        }
    }
}

