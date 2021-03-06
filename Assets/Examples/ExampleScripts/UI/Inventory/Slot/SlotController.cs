﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cosmos;
public class SlotController : MonoEventHandler
{
    string slotItemName = "Slot";
    UIImplementArgs<InventoryDataSet> uip;
    GameObject slot;
    string fullPath;
    List<Slot> slotList = new List<Slot>();
    int SlotCount { get { return slotList.Count; } }
    protected override void OnInitialization()
    {
        fullPath = Utility.UI.GetUIFullRelativePath(slotItemName);
        AddDefaultEventListener(UIImplementParam.UIIMPLEMENT_UPDATESLOT);
        AddEventListener(UIImplementParam.UIIMPLEMENT_UPDATEITEM, UpdateItemHandler);
        slot = Facade.Instance.LoadResAsset<GameObject>(fullPath);
    }
    protected override void OnTermination()
    {
        RemoveDefaultEventListener(UIImplementParam.UIIMPLEMENT_UPDATESLOT);
        RemoveEventListener(UIImplementParam.UIIMPLEMENT_UPDATEITEM, UpdateItemHandler);
    }
    protected override void EventHandler(object sender, GameEventArgs args)
    {
        uip = args as UIImplementArgs<InventoryDataSet>;
        UpdateSlot(uip.Data);
        UpdateItem(uip.Data);
    }
    void UpdateSlot(InventoryDataSet args)
    {
        if (slotList.Count == 0)
        {
            for (int i = 0; i < uip.Data.InventoryCapacity; i++)
            {
                var go = Instantiate(slot, transform);
                go.name = "Slot";
                slotList.Add(go.GetComponent<Slot>());
            }
        }
        else if (slotList.Count > uip.Data.InventoryCapacity)
        {
            for (int i = 0; i < slotList.Count; i++)
            {
                if (i >= uip.Data.ItemDataSets.Count)
                {
                    GameManager.KillObjectImmediate(slotList[i].gameObject);
                }
            }
            slotList.RemoveRange(uip.Data.ItemDataSets.Count, slotList.Count - uip.Data.ItemDataSets.Count);
        }
        else if (slotList.Count < uip.Data.InventoryCapacity)
        {
            for (int i = 0; i < uip.Data.InventoryCapacity; i++)
            {
                if (i >= slotList.Count)
                {
                    var go = Instantiate(slot, transform);
                    go.name = "Slot";
                    slotList.Add(go.GetComponent<Slot>());
                }
            }
        }
    }
    void UpdateItem(InventoryDataSet args)
    {
        for (int i = 0; i < args.ItemDataSets.Count; i++)
        {
            slotList[i].SetupSlot(args.ItemDataSets[i]);
        }
    }
    void UpdateItemHandler(object sender,GameEventArgs args)
    {
        var slots = GetComponentsInChildren<Slot>();
        for (int i = 0; i < slots.Length; i++)
        {
            uip.Data.ItemDataSets[i] = slots[i].GetDateSet();
        }
       
    }
}
