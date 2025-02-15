﻿using Model;
using System.Collections.Generic;
using ZdravoCorpAppTim22.Controller.Generic;
using ZdravoCorpAppTim22.Model;
using ZdravoCorpAppTim22.Service;

namespace ZdravoCorpAppTim22.Controller
{
    public class EquipmentDataController : GenericController<EquipmentDataService, EquipmentData>
    {
        private static EquipmentDataController instance;
        private EquipmentDataController() : base(EquipmentDataService.Instance) { }
        public static EquipmentDataController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipmentDataController();
                }
                return instance;
            }
        }
        public EquipmentData GetByName(string name)
        {
            return EquipmentDataService.Instance.GetByName(name);
        }

        public List<EquipmentData> GetAllConsumable()
        {
            List<EquipmentData> tempListAll = GetAll();
            List<EquipmentData> tempList = new List<EquipmentData>();
            for (int i = 0; i < tempListAll.Count; i++)
            {
                if (tempListAll[i].Type == EquipmentType.consumable)
                {
                    tempList.Add(tempListAll[i]);
                }
            }

            return tempList;
        }
    }
}