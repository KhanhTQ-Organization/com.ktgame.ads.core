using System;
using System.Collections.Generic;

#if ADMOB_NATIVE
using GoogleMobileAds.Api;
#endif

namespace com.ktgame.ads.core
{
	public class NullNativeAdapter : INativeAdapter
	{
		public static readonly NullNativeAdapter Instance = new NullNativeAdapter();
#if ADMOB_NATIVE
		public NativeAd CurrentNativeAd { get; private set; }
		public Queue<NativeAd> NativeAdsPreload { get; private set;}
		public List<NativeAd> NativeAdsTemp { get; private set;}
#endif
		public event Action<AdPlacement> OnLoadSucceeded;
		public event Action<AdError> OnLoadFailed;
		public event Action<AdPlacement> OnClicked;
		public event Action<ImpressionData> OnImpressionSuccess;
		public event Action OnClosed;
		public bool IsReady { set; get; }
        
		private NullNativeAdapter()
		{
            
		}
		public void Load()
		{
            
		}
		public void Show()
		{
            
		}
		public void Hide()
		{
          
		}
		public void Destroy()
		{
         
		}
	}
}
