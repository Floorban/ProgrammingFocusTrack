using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Unity.FPS.UI
{
    public class PlayerExpBar : MonoBehaviour
    {
        [Tooltip("Image component dispplaying current experience")]
        public Image ExpFillImage;

        PlayerCharacterController m_PlayerController;
        private float lerpSpeed;

        public TextMeshProUGUI openConterText;
        void Start()
        {
            PlayerCharacterController playerCharacterController =
                  GameObject.FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerExpBar>(
                playerCharacterController, this);

            m_PlayerController = playerCharacterController.GetComponent<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, PlayerExpBar>(m_PlayerController, this,
                playerCharacterController.gameObject);
        }

        void Update()
        {
            //lerpSpeed = 10f * Time.deltaTime;
            //ExpFillImage.fillAmount = Mathf.Lerp(ExpFillImage.fillAmount, m_PlayerController.currentExperience / m_PlayerController.maxExperience, lerpSpeed);

            openConterText.text = m_PlayerController.coinNum.ToString();
            ExpFillImage.fillAmount = m_PlayerController.currentExperience / (m_PlayerController.maxExperience);
        }

    }

}