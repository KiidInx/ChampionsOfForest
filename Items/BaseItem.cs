﻿using System.Collections.Generic;
using UnityEngine;

namespace ChampionsOfForest
{
    public class BaseItem
    {
        public enum ItemType { Shield, Quiver, Weapon, Other, Material, Helmet, Boot, Pants, ChestArmor, ShoulderArmor, Glove, Bracer, Amulet, Ring, SpellScroll }
        public delegate void OnItemEquip();
        public delegate void OnItemUnequip();
        public delegate void OnItemConsume();


        public List<List<ItemStat>> PossibleStats;
        public int Rarity = 0;                  //rarity to display in different color
        public int ID = 0;                      //the id of an item
        public int StackSize = 1;               //how many items can be placed in one item slot?
        public bool CanConsume = false;             //can you eat this bad boy?
        public ItemType _itemType = ItemType.Weapon;          //determines on which inv slot can this item be placed in
        public enum WeaponModelType { None, GreatSword, LongSword, Chargeblade, Hammer, Lance, Flail, Helberd, Gauntlet, Staff, Dagger, Axe, Greatbow };
        public WeaponModelType weaponModel = WeaponModelType.None;
        public OnItemEquip onEquip;
        public OnItemUnequip onUnequip;
        public OnItemConsume onConsume;
        public string name;                 //name of item, 
        public string description;          //what is this item basically
        public string lore;                 //some cool story to make this item have any sense, or a place for a joke
        public string tooltip;              //what should be displayed in the tooltip of this item
        public int level = 1;                   //level of this item
        public int minLevel = 1;
        public int maxLevel = 1;
        public Texture2D icon;              //icon of this item
        public bool PickUpAll = true;              //should the item be picked one by one, or grab all at once

        //Drop settings
        public List<EnemyProgression.Enemy> LootsFrom;



        public BaseItem()
        {

        }

        public BaseItem(params int[][] possibleStats)
        {
            PossibleStats = new List<List<ItemStat>>();
            foreach (int[] a in possibleStats)
            {
                List<ItemStat> list = new List<ItemStat>();
                foreach (int statID in a)
                {
                    if (statID == 0)
                    {
                        list.Add(null);
                    }
                    else if (statID == -1)
                    {
                        int[] allstats = new int[]
                        {
                            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,21,22,23,24,25,26,31,34,35,36,37,38,39,40,41,42,43,44,45,46,47,49,50,51,52,53,54,55,56,57,59,60,61,62,63,64,65
                        };
                        foreach (int c in allstats)
                        {
                            list.Add(new ItemStat(ItemDataBase.Stats[c]));
                        }
                    }
                    else
                    {
                        list.Add(new ItemStat(ItemDataBase.Stats[statID]));
                    }
                }
                PossibleStats.Add(list);
            }
            ID = ItemDataBase._Item_Bases.Count; ;
            ItemDataBase._Item_Bases.Add(this);

        }



        public BaseItem(List<List<ItemStat>> possibleStats, int rarity, int StackSize, ItemType itemType, string name, string description, string lore, string tooltip, int minlevel, int maxlevel, Texture2D texture, bool pickupAll = false)
        {
            PossibleStats = possibleStats;
            Rarity = rarity;
            ID = ItemDataBase._Item_Bases.Count; ;
            this.StackSize = StackSize;
            _itemType = itemType;
            PickUpAll = pickupAll;
            this.name = name;
            this.description = description;
            this.lore = lore;
            this.tooltip = tooltip;
            this.minLevel = minlevel;
            this.maxLevel = maxlevel;
            LootsFromAssignDefault();
            ItemDataBase._Item_Bases.Add(this);
            icon = texture;
        }
        public BaseItem(int[][] possibleStats, int rarity, int StackSize, ItemType itemType, string name, string description, string lore, string tooltip, int minlevel, int maxlevel, Texture2D texture, bool pickupAll = false)
        {
            PossibleStats = new List<List<ItemStat>>();
            foreach (int[] a in possibleStats)
            {
                List<ItemStat> list = new List<ItemStat>();
                foreach (int b in a)
                {
                    if (b == 0)
                    {
                        list.Add(null);
                    }
                    else
                    {
                        list.Add(ItemDataBase.Stats[b]);
                    }
                }
                PossibleStats.Add(list);
            }
            Rarity = rarity;
            ID = ItemDataBase._Item_Bases.Count;
            this.StackSize = StackSize;
            _itemType = itemType;
            PickUpAll = pickupAll;
            this.name = name;
            this.description = description;
            this.lore = lore;
            this.tooltip = tooltip;
            this.minLevel = minlevel;
            this.maxLevel = maxlevel;
            LootsFromAssignDefault();
            ItemDataBase._Item_Bases.Add(this);
            icon = texture;
        }
        public BaseItem(int[][] possibleStats, int rarity, int iD, int StackSize, WeaponModelType weaponModel, string name, string description, string lore, string tooltip, int minlevel, int maxlevel, Texture2D texture, bool pickupAll = false)
        {
            PossibleStats = new List<List<ItemStat>>();
            foreach (int[] a in possibleStats)
            {
                List<ItemStat> list = new List<ItemStat>();
                foreach (int b in a)
                {
                    if (b == 0)
                    {
                        list.Add(null);
                    }
                    else
                    {
                        list.Add(ItemDataBase.Stats[b]);
                    }
                }
                PossibleStats.Add(list);
            }
            Rarity = rarity;
            ID = iD;
            this.StackSize = StackSize;
            _itemType = ItemType.Weapon;
            this.weaponModel = weaponModel;
            PickUpAll = pickupAll;
            this.name = name;
            this.description = description;
            this.lore = lore;
            this.tooltip = tooltip;
            this.minLevel = minlevel;
            this.maxLevel = maxlevel;
            LootsFromAssignDefault();
            ItemDataBase._Item_Bases.Add(this);
            icon = texture;
        }

        /// <summary>
        /// set to this by default
        /// </summary>
        private void LootsFromAssignDefault()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.RegularArmsy,EnemyProgression.Enemy.PaleArmsy,EnemyProgression.Enemy.RegularVags,EnemyProgression.Enemy.PaleVags,EnemyProgression.Enemy.Cowman,EnemyProgression.Enemy.Baby,EnemyProgression.Enemy.Girl,EnemyProgression.Enemy.Worm,EnemyProgression.Enemy.Megan,EnemyProgression.Enemy.NormalMale,EnemyProgression.Enemy.NormalLeaderMale,EnemyProgression.Enemy.NormalFemale,EnemyProgression.Enemy.NormalSkinnyMale,EnemyProgression.Enemy.NormalSkinnyFemale,EnemyProgression.Enemy.PaleMale,EnemyProgression.Enemy.PaleSkinnyMale,EnemyProgression.Enemy.PaleSkinnedMale,EnemyProgression.Enemy.PaleSkinnedSkinnyMale,EnemyProgression.Enemy.PaintedMale,EnemyProgression.Enemy.PaintedLeaderMale,EnemyProgression.Enemy.PaintedFemale,EnemyProgression.Enemy.Fireman
            };
        }

        //Sets the item to drop from only a specyfic group of enemies
        public void DropSettings_OnlyArmsy()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.RegularArmsy,EnemyProgression.Enemy.PaleArmsy
            };
        }
        public void DropSettings_OnlyVags()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.PaleVags,EnemyProgression.Enemy.RegularVags
            };
        }
        public void DropSettings_OnlyCow()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.Cowman,
            };
        }
        public void DropSettings_OnlyBaby()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.Baby
            };
        }
        public void DropSettings_OnlyMegan()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.Megan
            };
        }
        public void DropSettings_OnlyCreepy()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
               EnemyProgression.Enemy.RegularArmsy,EnemyProgression.Enemy.PaleArmsy,EnemyProgression.Enemy.RegularVags,EnemyProgression.Enemy.PaleVags,EnemyProgression.Enemy.Cowman,EnemyProgression.Enemy.Baby,EnemyProgression.Enemy.Girl,EnemyProgression.Enemy.Worm,EnemyProgression.Enemy.Megan
            };
        }
        public void DropSettings_OnlyCannibals()
        {
            LootsFrom = new List<EnemyProgression.Enemy>()
            {
                EnemyProgression.Enemy.NormalMale,EnemyProgression.Enemy.NormalLeaderMale,EnemyProgression.Enemy.NormalFemale,EnemyProgression.Enemy.NormalSkinnyMale,EnemyProgression.Enemy.NormalSkinnyFemale,EnemyProgression.Enemy.PaleMale,EnemyProgression.Enemy.PaleSkinnyMale,EnemyProgression.Enemy.PaleSkinnedMale,EnemyProgression.Enemy.PaleSkinnedSkinnyMale,EnemyProgression.Enemy.PaintedMale,EnemyProgression.Enemy.PaintedLeaderMale,EnemyProgression.Enemy.PaintedFemale,EnemyProgression.Enemy.Fireman
            };
        }
    }

}

