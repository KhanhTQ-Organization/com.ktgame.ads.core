using System;
using System.Collections.Generic;

#if ADMOB
using GoogleMobileAds.Api;
#endif

namespace com.ktgame.ads.core
{
    public class NativeDecorator : INativeAdapter
    {
        protected INativeAdapter Adapter { private set; get; }
#if ADMOB
        public NativeAd CurrentNativeAd => Adapter.CurrentNativeAd;
        public Queue<NativeAd> NativeAdsPreload => Adapter.NativeAdsPreload;
        public List<NativeAd> NativeAdsTemp => Adapter.NativeAdsTemp;
#endif
        public event Action<AdPlacement> OnLoadSucceeded;
        public event Action<AdError> OnLoadFailed;
        public event Action<AdPlacement> OnClicked;
        public event Action<ImpressionData> OnImpressionSuccess;
        public event Action OnClosed;
        public bool IsReady => Adapter.IsReady;

        public NativeDecorator(INativeAdapter adapter)
        {
            Adapter = adapter;
            Adapter.OnLoadFailed += LoadFailedHandler;
            Adapter.OnClicked += ClickHandler;
            Adapter.OnLoadSucceeded += LoadSucceededHandler;
            Adapter.OnClosed += ClosedHandler;
        }

        protected virtual void ClosedHandler()
        {
            OnClosed?.Invoke();
        }

        protected virtual void LoadSucceededHandler(AdPlacement AdPlacement)
        {
            OnLoadSucceeded?.Invoke(AdPlacement);
        }

        protected virtual void ClickHandler(AdPlacement AdPlacement)
        {
            OnClicked?.Invoke(AdPlacement);
        }

        protected virtual void LoadFailedHandler(AdError AdPlacement)
        {
            OnLoadFailed?.Invoke(AdPlacement);
        }
        
        protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
        {
            OnImpressionSuccess?.Invoke(impressionData);
        }

        public void Load()
        {
            Adapter.Load();
        }

        public void Show()
        {
            Adapter.Show();
        }
        
        public void Hide()
        {
            Adapter.Hide();
        }
        
        public void Destroy()
        {
            Adapter.Destroy();
        }
    }
}
