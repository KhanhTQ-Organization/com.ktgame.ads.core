using System;

namespace com.ktgame.ads.core
{
    public interface IRewardVideoAdapter
    {
        event Action<AdError> OnLoadFailed;
        event Action OnLoadSucceeded;
        event Action<AdError> OnShowFailed;
        event Action OnVideoOpened;
        event Action OnVideoClicked;
        event Action OnVideoClosed;
        event Action<AdPlacement> OnRewarded;
        event Action<ImpressionData> OnImpressionSuccess;
		event Action<ImpressionData> OnPain;
        bool IsReady { get; }
        
        void Load();
        void Show(AdPlacement adPlacement);
    }
}
