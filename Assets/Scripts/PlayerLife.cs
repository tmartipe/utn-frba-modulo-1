public class PlayerLife : Life
{
    public override void TakeDamage(int damage)
    {
        currentLife -= damage;
        HUDManager.Instance.UpdateHeartIcons(currentLife);
        //TODO: Death logic
    }
}