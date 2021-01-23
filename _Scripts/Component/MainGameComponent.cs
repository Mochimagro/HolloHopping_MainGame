﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Doozy.Engine;

namespace HoloHopping.Component
{
    using Presenter;
    using Model;
    public class MainGameComponent : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private HoppingCharaCreaterComponent _hoppingCharaCreaterComponent = null;
        [SerializeField] private ItemCreaterComponent _itemCreaterComponent = null;
        [SerializeField] private ItemTextCreaterComponent _itemTextCreaterComponent = null;
        [SerializeField] private EffectCreaterComponent _effectCreaterComponent = null;

        [Header("Presenters")]
        [SerializeField] private ScorePresenter _scorePresenter = null;
        [SerializeField] private ReadyLabelPresenter _readyLabelPresenter = null;
        [SerializeField] private BGMPresenter _bgmPresenter = null;

        private GameSystemModel _gameSystemModel = null;

        public void Init()
        {
            _readyLabelPresenter.ShowReadyText();

            ScoreModel scoreModel = null;
            _gameSystemModel = new GameSystemModel();

            _scorePresenter.Init(out scoreModel);

            _itemCreaterComponent.Init(scoreModel);

            _effectCreaterComponent.Init();

            _bgmPresenter.Init();
            _bgmPresenter.PlayReadySound();

            Bind();
        }

        public void InvokeSystem()
        {
            GameEventMessage.SendEvent("StartGame");

            _readyLabelPresenter.ShowGoText();

            _itemCreaterComponent.StartAutoCreate();

            _hoppingCharaCreaterComponent.CreateHoppingCharacter();

            _bgmPresenter.PlayStartSound();
        }

        private void Bind()
        {
            _itemCreaterComponent.OnGetItem.Subscribe(entity =>
            {
                _itemTextCreaterComponent.CreateText(entity);
            });

            _hoppingCharaCreaterComponent.OnCreateCharacter.Subscribe(createdChara =>
            {
                Debug.Log("Create");
                _gameSystemModel.AddLeaveCount();
            });

            _hoppingCharaCreaterComponent.OnCharacterMiss.Subscribe(missChara =>
            {
                Debug.Log("Miss");
                _gameSystemModel.ReduceLeaveCount();
                _effectCreaterComponent.CreateEffect(missChara.FXCreateEntity);
            });

            _hoppingCharaCreaterComponent.OnHopCharacter.Subscribe(fxEntity =>
            {
                _effectCreaterComponent.CreateEffect(fxEntity);
            });

            _gameSystemModel.AllCharacterMiss.Subscribe(_ =>
            {
                Debug.Log("AllMiss");
            });
        }

    }
}