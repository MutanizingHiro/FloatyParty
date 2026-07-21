using UnityEngine;

/// <summary>
/// プレイヤーがダメージを与えられるオブジェクト
/// </summary>

//これを継承したオブジェクトは
//「プレイヤーがダメージを与えられる」ということ
public interface IPlayerDamageable
{
    //当たったら実行する処理（継承した場合、この関数がないとエラーになる）
    void Hit(int damage);
}
