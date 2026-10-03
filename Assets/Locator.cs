using UnityEngine;

public class Locator : Singleton<Locator>
{
    public Player player;
    protected override void Awake()
    {
        base.Awake();
        player ??= FindObjectOfType<Player>();
    }
}
