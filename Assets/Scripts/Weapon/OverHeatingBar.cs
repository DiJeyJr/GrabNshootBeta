using UnityEngine;

namespace Weapon
{
    public class OverHeatingBar : MonoBehaviour
    {
        [SerializeField] private RectTransform overHeatingBar;
    
        private ShootFunction _shootFunction;

        private void Start()
        {
            _shootFunction = GetComponent<ShootFunction>();
        }

        private void Update()
        {
            //Getting Overheat percentage
            float overheatPercentage = 1 - _shootFunction.GetOverheatPercentage();
        
            //Limits
            if (overheatPercentage > 1)
                overheatPercentage = 1;
        
            if (overheatPercentage < 0)
                overheatPercentage = 0;
        
            //Updating Size
            overHeatingBar.localScale = new Vector3(overheatPercentage, 1f, 1f);
        }
    }
}
