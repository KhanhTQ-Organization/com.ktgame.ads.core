using System;
using System.Collections.Generic;

#if ADMOB
using GoogleMobileAds.Api;
#endif

namespace com.ktgame.ads.core
{
	public class NullNativeInterAdapter : INativeAdapter
	{
		public static readonly NullNativeInterAdapter Instance = new NullNativeInterAdapter();
#if ADMOB
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
        
		private NullNativeInterAdapter()
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
