using Unity.FPS.UI;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;
    public WeaponPowerupEffect weaponPowerupEffect;
    public UpgradePanelManager upgradePanelManager;
    public GameObject player;
    public GameObject weapon;

    [SerializeField]
    private bool isWeapon;
    private void Start()
    {
        upgradePanelManager = GetComponentInParent<UpgradePanelManager>();
        player = GameObject.FindWithTag("Player");
        weapon = GameObject.FindWithTag("PlayerWeapon");
    }
 
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
