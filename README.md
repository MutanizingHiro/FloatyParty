# Floaty Party
防衛シューティング型2Dゲームである。ライフガードとなり、水鉄砲で浮き輪の侵略者を撃ち落としながら、できるだけ長く海岸を守り抜く。ただし、プレイヤーの近くで浮き輪を撃ちすぎると心臓発作を起こし、ゲームオーバーになる。  

## 開発環境
使用ゲームエンジン：Unity<br>
使用言語：C#<br>
開発期間：約4週間<br>
所要時間の概算 ：約45〜50時間<br>
開発メンバー: 4名<br>
外部アセット使用：なし<br>
AI活用：なし<br>
学校提供フレームワーク：なし<br>

## 担当範囲
-イラスト<br>
-キャラクターデザイン<br>
-アニメーター<br>

## 主な実装
タゲットアイコンの UI Canvas に Render Mode を World Space に設定して、マウスの位置を正確に追跡する。
```
Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
transform.position = new Vector3(worldMousePos.x,worldMousePos.y,0);
```
<br>

シングルトンパターンでゲームマネージャーを実装し、タイトル画面・メイン画面・ゲームオーバーの3つの状態を一元管理する。
シーン遷移時にはフェードイン・フェードアウトのアニメーションを挟むことで、画面切り替えが自然に見えるよう調整した。
```
 private void Awake()
 {
     if(instance != null)
     {
         Destroy(gameObject);
         return;
     }

     instance = this;
     DontDestroyOnLoad(gameObject);

     gameState = GameState.titleScreen;
 }
```

```
IEnumerator TitleScreenToMainGame()
{
    anim.Play("FadeIn");
    yield return new WaitForSeconds(screenTransitionTimer);

    gameState = GameState.mainScreen;
    SceneManager.LoadScene("MainGame");

    yield return new WaitForSeconds(screenTransitionTimer);

    anim.Play("FadeOut");
}

public IEnumerator GameOverScreenToMainGame()
{
    anim.Play("FadeIn");
    yield return new WaitForSeconds(screenTransitionTimer);

    gameState = GameState.mainScreen;
    SceneManager.LoadScene("MainGame");

    yield return new WaitForSeconds(screenTransitionTimer);
    anim.Play("FadeOut");
}

public IEnumerator GameOverScreenToTitleScreen()
{
    anim.Play("FadeIn");

    yield return new WaitForSeconds(screenTransitionTimer);

    gameState = GameState.titleScreen;
    SceneManager.LoadScene("TitleScreen");

    yield return new WaitForSeconds(screenTransitionTimer);
    anim.Play("FadeOut");
}
```
<br>

## リンク
https://drive.google.com/drive/folders/1ZGtDfkFQ-zqbh_whHEIc3GC_dU3v2NoH?usp=drive_link
