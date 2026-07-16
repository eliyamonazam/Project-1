using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    public int knightSwordBuff = 5;
    public int fairyMagicBuff = 5;

    public void GrantReward()
    {
        GameObject.Find("Knight")?.GetComponent<PlayerCombat>()?.BoostDamage(knightSwordBuff);
        GameObject.Find("Fairy")?.GetComponent<FairyAttack>()?.BoostDamage(fairyMagicBuff);
    }
}