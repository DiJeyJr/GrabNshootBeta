using UnityEngine;
using Weapon;

public class AmmoInitializer : MonoBehaviour
{
    public GameObject fireAmmoPrefab;
    public GameObject natureAmmoPrefab;
    public GameObject waterAmmoPrefab;

    void Start()
    {
        AmmoFactory.RegisterAmmoPrefab("Fire", fireAmmoPrefab);
        AmmoFactory.RegisterAmmoPrefab("Nature", natureAmmoPrefab);
        AmmoFactory.RegisterAmmoPrefab("Water", waterAmmoPrefab);
    }
}
