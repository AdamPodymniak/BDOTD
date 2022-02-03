using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    #region Singleton
    public static EquipManager instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public Modyfikators[] currentModyfikators;
    public delegate void OnModChanged(Modyfikators newMod, Modyfikators oldMod);
    public OnModChanged onModChanged;
    public int numOfSlots;
    public int maxNumOfSlots;
    public int slotIndex;

    private void Start()
    {
        currentModyfikators = new Modyfikators[maxNumOfSlots];
    }

    public void Equip(Modyfikators newMod)
    {
        Modyfikators oldMod = null;
        if(numOfSlots > slotIndex)
        {
            currentModyfikators[slotIndex] = newMod;
            slotIndex++;

            if (onModChanged != null)
            {
                onModChanged.Invoke(newMod, oldMod);
            }
        }
    }
    public void unequipAll()
    {
        slotIndex = 0;
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
        }
    }
}
