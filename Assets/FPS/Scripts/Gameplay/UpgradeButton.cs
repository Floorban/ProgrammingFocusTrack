using Unity.FPS.UI;
using Unity.FPS.Gameplay;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;
    public UpgradePanelManager upgradePanelManager;
    public GameObject player;
    public void OnClicked()
    {
        powerUpEffect.Apply(player.gameObject);
        upgradePanelManager.ClosePanel();
    }
}
