using UnityEngine;
using Weapon;

public class AmmoInitializer : MonoBehaviour
{
    public GameObject fireAmmoPrefab;
    public GameObject natureAmmoPrefab;
    public GameObject waterAmmoPrefab;

    void Start()
    {
        AmmoAbstractFactory.RegisterAmmoFactory("Fire", new FireAmmoFactory(fireAmmoPrefab));
        AmmoAbstractFactory.RegisterAmmoFactory("Nature", new NatureAmmoFactory(natureAmmoPrefab));
        AmmoAbstractFactory.RegisterAmmoFactory("Water", new WaterAmmoFactory(waterAmmoPrefab));
    }
}