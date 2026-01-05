using System;
using System.Collections.Generic;
#if ADMOB
using GoogleMobileAds.Api;
#endif

namespace com.ktgame.ads.core
{
	public interface INativeAdapter
	{
		AdFormat AdFormat { get; }
		
#if ADMOB_NATIVE
		NativeAd CurrentNativeAd { get; }
#endif
		event Action<AdPlacement> OnLoadSucceeded;
		event Action<AdError> OnLoadFailed;
		event Action<AdPlacement> OnClicked;
		event Action<ImpressionData> OnImpressionSuccess;
		event Action<ImpressionData> OnPaid;
		event Action OnClosed;

		bool IsReady { get; }
		void Load();
		void Show();
		void Hide();
		void Destroy();
	}
}
