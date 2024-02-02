using Unity.FPS.Gameplay;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class UpgradeButton : MonoBehaviour
    {
        UpgradePanelManager upgradePanelManager;
        PlayerCharacterController playerController;
        GameObject weapon;
        WeaponController weaponController;
        Health health;
        Button button;

        [Header("Amount of the power-up's value")]
        [SerializeField] float amount;
        public int buttonID;

        void Start()
        {
            upgradePanelManager = GetComponentInParent<UpgradePanelManager>();

            PlayerCharacterController playerCharacterController =
                             GameObject.FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, UpgradeButton>(
                playerCharacterController, this);

            playerController = playerCharacterController.GetComponent<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, UpgradeButton>(playerController, this,
                playerCharacterController.gameObject);

            health = playerCharacterController.GetComponent<Health>();
            weapon = GameObject.FindGameObjectWithTag("PlayerWeapon");
            weaponController = weapon.GetComponent<WeaponController>();
            button = GetComponent<Button>();
            button.onClick.AddListener(Clicked);
        }
        public void Clicked()
        {
            switch (buttonID)
            {
                case 0:
                    playerController.ModifyMoveSpeed(amount);
                    break;
                case 1:
                    playerController.ModifyJumpForce(amount);
                    break;
                case 2:
                    playerController.ModifyDmg(amount);
                    break;
                case 3:
                    health.ModifyMaxHp(amount);
                    break;
                case 4:
                    weaponController.ModifyAttackSpeed(amount);
                    break;
                case 5:
                    weaponController.ModifyReloadSpeed(amount);
                    break;
                case 6:
                    weaponController.ModifyReloadDelay(amount);
                    break;
                case 7:
                    weaponController.ModifyAmmoCapacity((int)amount);
                    break;
            }

            //OnUnlockPowerUp.Invoke(powerUpNames[buttonID]);
            upgradePanelManager.ClosePanel(buttonID);
        }

    }

}
