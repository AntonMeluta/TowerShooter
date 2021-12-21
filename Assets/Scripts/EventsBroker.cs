using System;
using UnityEngine;

public class EventsBroker
{        
    #region Отлавливание события тапа по экрану
    public delegate void TapHandler(Vector3 tapVector);
    public static event TapHandler OnTap;
    public static void TapEvent(Vector3 vector)
    {
        OnTap?.Invoke(vector);
    }
    #endregion

    #region событие - начало или завершение тапа
    public delegate void TapUpdateStateHandler(bool isTapNow);
    public static event TapUpdateStateHandler OnTapUpdateState;
    public static void TapUpdateStateEvent(bool isTapNow)
    {
        OnTapUpdateState?.Invoke(isTapNow);
    }
    #endregion

    #region событие - игрок переходит в состояние боя
    public static Action OnPlayerToWar;
    public static void PlayerStartedFight()
    {
        OnPlayerToWar?.Invoke();
    }
    #endregion

    #region событие - игрока терпит поражение
    public static Action OnPlayerLost;
    public static void PlayerFail()
    {
        OnPlayerLost?.Invoke();
    }
    #endregion

    #region событие - игрок убивает врага
    public static Action OnPlayerKill;
    public static void PlayerKill()
    {
        OnPlayerKill?.Invoke();
    }
    #endregion

    #region событие - новая волна врагов, обновление UI
    public delegate void NewWaveHandler(int countWave);
    public static event NewWaveHandler OnWave;
    public static void NewWaveEvent(int waveValue)
    {
        OnWave?.Invoke(waveValue);
    }
    #endregion

}
