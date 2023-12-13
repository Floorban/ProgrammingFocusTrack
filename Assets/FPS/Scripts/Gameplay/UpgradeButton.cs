using Unity.FPS.UI;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;
    public WeaponPowerupEffect weaponPowerupEffect;
    public UpgradePanelManager upgradePanelManager;
    public GameObject player;
    public WeaponController weapon;

    [SerializeField]
    private bool isWeapon;
    public void OnClicked()
    {
        if (!isWeapon)
        {
            powerUpEffect.Apply(player.gameObject);
        }else
        {
            weaponPowerupEffect.ApplyWeapon(weapon);
        }
        upgradePanelManager.ClosePanel();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("clicked");
    }
}
