﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


namespace HoloHopping.Entity
{
    public class CharacterEntityList
    {
        public CharacterEntityList(Data.CharacterList list)
        {
            Entities = new List<CharacterEntity>();

            foreach (var data in list.List)
            {
                Entities.Add(new CharacterEntity(data));
            }
        }

        public List<CharacterEntity> Entities { get; private set; }

    }
}

namespace HoloHopping.Data
{

    public class CharacterList : ScriptableObject
    {
        [SerializeField] private List<CharacterData> _list = new List<CharacterData>();

        public List<CharacterData> List { get { return _list; } }
    }
}