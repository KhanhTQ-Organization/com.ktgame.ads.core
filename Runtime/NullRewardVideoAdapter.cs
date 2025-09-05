using System;

namespace com.ktgame.ads.core
{
    public class NullRewardVideoAdapter : IRewardVideoAdapter
    {
        public static readonly NullRewardVideoAdapter Instance = new NullRewardVideoAdapter();

        private NullRewardVideoAdapter()
        {
        }
        
        public event Action<AdError> OnLoadFailed;
        public event Action OnLoadSucceeded;
        public event Action<AdError> OnShowFailed;
        public event Action OnVideoOpened;
        public event Action OnVideoClicked;
        public event Action OnVideoClosed;
        public event Action<AdPlacement> OnRewarded;
        public event Action<ImpressionData> OnImpressionSuccess;
        public bool IsReady => true;
        
        public void Load()
        {
            
        }

        public void Show(AdPlacement adPlacement)
        {
            OnRewarded?.Invoke(adPlacement);
        }
    }
}
