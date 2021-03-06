﻿using UnityEngine;

namespace ChampionsOfForest
{
    public class ItemStat
    {
        public float LevelPow = 1;
        public float ValueCap = 0;
        public int StatID = 0;
        public string Name = "";
        public int Rarity = 0;
        public float MinAmount = 0;
        public float MaxAmount = 0;
        public float Amount = 1;
        public float Multipier = 1;
        public bool DisplayAsPercent = false;
        public int RoundingCount;

        public delegate void OnEquipDelegate(float f);
        public OnEquipDelegate OnEquip;
        public delegate void OnUnequipDelegate(float f);
        public OnUnequipDelegate OnUnequip;
        public delegate void OnConsumeDelegate(float f);
        public OnConsumeDelegate OnConsume;
        /// <summary>
        /// Creates new itemStat and adds it to the database
        /// </summary>
        /// <param name="id">ID of the item, used to access it from the DB</param>
        /// <param name="Min">Min amount for the stat at level 1</param>
        /// <param name="Max">Max amount for the stat at level 1</param>
        /// <param name="name">Name of the stat, what should be displayed in the item context menu</param>
        /// <param name="rarity">range 0-7</param>
        /// <param name="LvlPower">How much should it increase per level(min max values will be powered to this amount)</param>
        public ItemStat(int id, float Min, float Max, float LvlPower, string name, int rarity, OnEquipDelegate onEquip = null, OnUnequipDelegate onUnequip = null, OnConsumeDelegate onConsume = null)
        {
            LevelPow = LvlPower;
            StatID = id;
            MaxAmount = Max;
            MinAmount = Min;
            Name = name;
            Rarity = rarity;
            OnEquip = onEquip;
            OnUnequip = onUnequip;
            OnConsume = onConsume;
            ItemDataBase.AddStat(this);
        }
        public ItemStat(ItemStat s, int level = 1, float Multipier = 0)
        {
            Name = s.Name;
            LevelPow = s.LevelPow;
            StatID = s.StatID;
            Rarity = s.Rarity;
            MinAmount = s.MinAmount;
            MaxAmount = s.MaxAmount;
            OnEquip = s.OnEquip;
            OnUnequip = s.OnUnequip;
            OnConsume = s.OnConsume;
            RoundingCount = s.RoundingCount;
            DisplayAsPercent = s.DisplayAsPercent;
            this.ValueCap = s.ValueCap;
            if (Multipier != 0)
            {
                this.Multipier = Multipier;
            }
            else { this.Multipier = s.Multipier; }
            Amount = this.Multipier * RollValue(level);
            if (ValueCap != 0)
            {
                Amount = Mathf.Min(ValueCap, Amount);
            }
        }
        public ItemStat()
        {

        }

        public float RollValue(int level = 1)
        {
            float mult = 1;
            if (LevelPow != 0)
            {
                mult = Mathf.Pow(level, LevelPow);
            }
            float f = UnityEngine.Random.Range(MinAmount, MaxAmount) * mult;
            return f;
        }
    }
}
