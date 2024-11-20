using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMultiplierManager : MonoBehaviour
{
    public enum Element
    {
        Neutral,
        Water,
        Nature,
        Fire
    }
    
    public int CalculateElementalMultiplier(Element attackerElement, Element targetElement)
    {
        // Weakness
        if (attackerElement == Element.Water && targetElement == Element.Fire)
            return 2; 
        if (attackerElement == Element.Nature && targetElement == Element.Water)
            return 2; 
        if (attackerElement == Element.Fire && targetElement == Element.Nature)
            return 2; 
        
        // Immunity
        if (attackerElement == targetElement)
            return 0;

        //Regular Multiplier
        return 1;
    }
}
