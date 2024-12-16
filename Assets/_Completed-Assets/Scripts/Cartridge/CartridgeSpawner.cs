using Complete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Complete
{
    public class CartridgeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject shellCartridgePrefab; // ShellCartridge�̃v���n�u
        [SerializeField] private GameObject gameManagerObj;  // GameManager�I�u�W�F�N�g�ւ̎Q��
        private GameManager gameManager;

        [SerializeField] private Vector2 spawnAreaSize = new Vector2(10f, 10f); // �����G���A�͈̔�
        [SerializeField] private float spawnHeight = 1f; // �����ʒu�̍���

        [SerializeField] private float spawnInterval = 5f; // �����Ԋu

        private void Start()
        {
            // GameManager�̃C���X�^���X���擾
            gameManager = gameManagerObj.GetComponent<GameManager>();

            if (gameManagerObj != null)
            {
                // GameManager�̃C�x���g���w��
                gameManager.OnGameStateChanged += HandleGameStateChanged;
            }
        }

        // �Q�[����ԕύX���̏���
        private void HandleGameStateChanged(GameState newState)
        {
            // �Q�[�����v���C���̎������R���[�`�����J�n
            if (newState == GameState.RoundPlaying)
            {
                StartCoroutine(SpawnRoutine());  // �v���C���̂Ƃ�����SpawnRoutine���J�n
            }
            else
            {
                StopCoroutine(SpawnRoutine());  // �Q�[���I���܂��͊J�n���͒�~
            }
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                SpawnCartridge(); // �v���n�u�𐶐�
                yield return new WaitForSeconds(spawnInterval); // �w�肵�����ԑҋ@
            }
        }

        public void SpawnCartridge()
        {
            // �����_���Ȉʒu���v�Z
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                spawnHeight,
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
            );

            // �v���n�u�𐶐�
            Instantiate(shellCartridgePrefab, randomPosition, Quaternion.identity);
        }
    }
}
