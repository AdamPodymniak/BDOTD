using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    #region Singleton
    public static EquipManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Modyfikators[] currentModyfikators;
    public delegate void OnModChanged(Modyfikators newMod, Modyfikators oldMod);
    public OnModChanged onModChanged;
    public int numOfSlots = 3;
    private int slotIndex = 0;

    private void Start()
    {
        currentModyfikators = new Modyfikators[numOfSlots];

    }

    public void Equip(Modyfikators newMod)
    {
        Modyfikators oldMod = null;
        if(slotIndex < 3)
        {
            if(currentModyfikators[slotIndex] != null)
            {
                oldMod = currentModyfikators[slotIndex];
                Inventory.instance.Add(oldMod);
            }
            currentModyfikators[slotIndex] = newMod;
            slotIndex++;
        }
        if(onModChanged != null)
        {
            onModChanged.Invoke(newMod, oldMod);
        }
    }
    public void unequipAll()
    {
        for (int i = 0; i < numOfSlots; i++)
        {
            if(currentModyfikators[i] != null)
            {
                Modyfikators oldMod = currentModyfikators[i];
                Inventory.instance.Add(oldMod);

                currentModyfikators[i] = null;

                if (onModChanged != null)
                {
                    onModChanged.Invoke(null, oldMod);
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            unequipAll();
            slotIndex = 0;
        }
    }
}
