using System;
using System.Collections.Generic;
#if ADMOB
using GoogleMobileAds.Api;
#endif

namespace com.ktgame.ads.core
{
	public interface INativeAdapter
	{
#if ADMOB_NATIVE
		NativeAd CurrentNativeAd { get; }
		Queue<NativeAd> NativeAdsPreload { get; }
		List<NativeAd> NativeAdsTemp { get; }
#endif
		event Action<AdPlacement> OnLoadSucceeded;
		event Action<AdError> OnLoadFailed;
		event Action<AdPlacement> OnClicked;
		event Action<ImpressionData> OnImpressionSuccess;
		event Action OnClosed;

		bool IsReady { get; }
		void Load();
		void Show();
		void Hide();
		void Destroy();
	}
}
