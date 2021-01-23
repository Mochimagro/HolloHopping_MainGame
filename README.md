# ホロホッピング!!!/HoloHopping!!!

ホロライブの非公式ファンゲーム
ジャンル：アクションゲーム


# デモ/DEMO

[配信先(UnityRoom)](https://unityroom.com/games/holohopping)

![プレイ画像](https://drive.google.com/uc?export=view&id=1aebieHpnXxMAGdXLMfmjFcsVR-vOLQVj)

# 使用アセット/Used Assets

- [UniRx](https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276)
- [DoTweenPro](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416)
- [Arbor3](https://assetstore.unity.com/packages/tools/visual-scripting/arbor-3-fsm-bt-graph-editor-112239)
- [DoozyUI](https://assetstore.unity.com/packages/tools/gui/doozyui-complete-ui-management-system-138361)
- [Modern UI](https://assetstore.unity.com/packages/tools/gui/modern-ui-pack-150824)

# デザイン(プログラミング的な)/Design

本ゲームのアウトゲームの開発には「MV(R)Pパターン」を参考にしています。
インゲームは例外的に、新規作成したComponentをアタッチしてゲームオブジェクトの管理をしています。

- Component
```bash
インゲームで扱うゲームオブジェクトに対してアタッチしています。
ゲームオブジェクトにアタッチされたTransform,RigidBodyなどはこのComponentを介して操作されます
```

- Data
```bash
ScriptableObjectを継承したPrefabやアイテムのスコアなどを管理するクラスです。
```

- Entity
```bash
Projectに保存されたDataをComponentへ渡すためにEntityとして加工します。
プレハブなども利用するときはDataとEntityを介します。
```

- Presenter
```bash
Model,Viewの両者のイベントを管理するクラスです。今回はMonoBehaviorを継承し、Scene内のゲームオブジェクトにアタッチしています。
アウトゲームではDoozyUIと組み合わせて実装しています。
また、このクラスには計算等の処理を行うことは許されてません。
```

- View
```bash
プレイヤーのUI入力・システム側のUI操作を反映します。
インゲームではスコア等のUIに使用しています。
```

- Model
```bash
数値やオブジェクト等のデータを管理するクラスです。
数値変更がされたときにイベントを発行します。
```

# 外部ソフト/OtherTools
- [MagicaVoxel](https://ephtracy.github.io/)
- [Blender](https://www.blender.org/)

# 原作(ホロライブ)/Source(Hololive)
ホロライブの著作権表示
© 2017-2020 cover corp. [ホロライブプロダクション](https://www.hololive.tv/)
