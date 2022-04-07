using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STAGE_MANAGEMENT
{
    public class Gate : MonoBehaviour
    {
        [Header ("�ⱸ tranform")]
        public bool requestExit;
        private void Awake()
        {
            requestExit = false;
            //Debug.Log("Gate������Ʈ �߰�");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("�����ڽ��ϱ�?");
            if (other.gameObject.CompareTag("Player"))
            {
                StageManager.Inst.NextStage();
            }
        }
    }
}

