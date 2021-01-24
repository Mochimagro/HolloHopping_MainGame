﻿using System.Collections;
using UnityEngine;
using UnityEditor.Animations;

namespace HoloHopping.Component
{
    public class CharacterComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private GameObject _hopping = null;

        public void Init()
        {

        }

        public bool HoppingObjectSetActive { set { _hopping.SetActive(value); } }
        public AnimatorController AnimatorController { set { _animator.runtimeAnimatorController = value; } }
        public Animator Animator { get { return _animator; } }
        public SkinnedMeshRenderer HoppingSkin { get { return _hopping.GetComponent<SkinnedMeshRenderer>(); } }
    }
}