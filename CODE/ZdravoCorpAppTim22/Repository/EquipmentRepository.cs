﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorpAppTim22.Repository.FileHandlers;
using ZdravoCorpAppTim22.Repository.Generic;

namespace ZdravoCorpAppTim22.Repository
{
    public class EquipmentRepository : GenericRepository<Equipment>
    {
        public static string FileName = "EquipmentData.json";
        private static EquipmentRepository instance;
        private EquipmentRepository() : base(FileName) { }
        public static EquipmentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipmentRepository();
                }

                return instance;
            }
        }
    }
}