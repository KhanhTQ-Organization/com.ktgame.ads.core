using System;

namespace com.ktgame.ads.core
{
    public class RewardVideoDecorator : IRewardVideoAdapter
    {
        protected IRewardVideoAdapter Adapter { private set; get; }

        public event Action<AdError> OnLoadFailed;
        public event Action OnLoadSucceeded;
        public event Action<AdError> OnShowFailed;
        public event Action OnVideoOpened;
        public event Action OnVideoClicked;
        public event Action OnVideoClosed;
        public event Action<AdPlacement> OnRewarded;
        public event Action<ImpressionData> OnImpressionSuccess;
        public bool IsReady => Adapter.IsReady;

        protected RewardVideoDecorator(IRewardVideoAdapter adapter)
        {
            Adapter = adapter;
            Adapter.OnShowFailed += ShowFailedHandler;
            Adapter.OnVideoOpened += VideoOpenedHandler;
            Adapter.OnVideoClosed += VideoClosedHandler;
            Adapter.OnRewarded += RewardHandler;
            Adapter.OnLoadFailed += LoadFailedHandler;
            Adapter.OnLoadSucceeded += LoadSucceededHandler;
            Adapter.OnVideoClicked += VideoClickHandler;
            Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
        }

        protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
        {
            OnImpressionSuccess?.Invoke(impressionData);
        }

        protected virtual void VideoClickHandler()
        {
            OnVideoClicked?.Invoke();
        }

        protected virtual void LoadSucceededHandler()
        {
            OnLoadSucceeded?.Invoke();
        }

        protected virtual void LoadFailedHandler(AdError obj)
        {
            OnLoadFailed?.Invoke(obj);
        }

        protected virtual void RewardHandler(AdPlacement rewardData)
        {
            OnRewarded?.Invoke(rewardData);
        }

        protected virtual void VideoClosedHandler()
        {
            OnVideoClosed?.Invoke();
        }

        protected virtual void VideoOpenedHandler()
        {
            OnVideoOpened?.Invoke();
        }

        protected virtual void ShowFailedHandler(AdError error)
        {
            OnShowFailed?.Invoke(error);
        }

        public void Load()
        {
            Adapter.Load();
        }

        public virtual void Show(AdPlacement adPlacement)
        {
            Adapter.Show(adPlacement);
        }
    }
}