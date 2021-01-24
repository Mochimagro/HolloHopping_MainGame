﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace HoloHopping.Entity
{

    public interface IEntity
    {

    }
    public class ItemEntity : IEntity
    {
        public ItemEntity(Data.ItemData data)
        {
            Component = data.PrefabComponent;
            Score = data.Score;
            ItemColor = data.ItemColor;
            ItemMode = data.ItemMode;
        }

        public Component.ItemComponent Component { get; private set; }
        public int Score { get; private set; }
        public string GetText { get; set; }
        public Data.ItemMode ItemMode { get; private set; }
        public Color ItemColor { get; private set; }
        public Vector3 GetPos { get; set; }
        public Enum.SEScene SEScene { get; set; }
        public FXCreateEntity FXCreateEntity { get; set; }
    }
}

namespace HoloHopping.Data
{
    public enum ItemMode
    {
        None,
        Score,
        AddCharacter,
        StarRush
    }

    [CreateAssetMenu(menuName =
        MenuName.Format.DATA +
        MenuName.Attribute.ITEM +
        MenuName.Type.PARAMETER,
        fileName = "NewItemName")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private Component.ItemComponent _prefab = null;
        [SerializeField] private int _score = 100;
        [SerializeField] private Color _itemColor = Color.white;
        [SerializeField] private ItemMode _itemMode = ItemMode.None;
        public Component.ItemComponent PrefabComponent { get { return _prefab; } }
        public int Score { get { return _score; } }
        public Color ItemColor { get { return _itemColor; } }
        public ItemMode ItemMode { get { return _itemMode; } }
    }
}