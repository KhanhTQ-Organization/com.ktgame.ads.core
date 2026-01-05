using System;

namespace com.ktgame.ads.core
{
	public interface IAdAdapter
	{
		IBannerAdapter Banner { get; }
		IInterstitialAdapter Interstitial { get; }
		IInterstitialAdapter InterstitialImage { get; }
		IRewardVideoAdapter RewardVideo { get; }
		IAppOpenAdapter AppOpen { get; }
		IMRecAdapter MRec { get; }
		INativeAdapter Native { get; }
		INativeAdapter NativeInter { get; }
		void Initialize(Action<bool> onComplete);
		void SetPause(bool pause);
		void SetBanner(IBannerAdapter bannerAdapter);
		void SetInterstitial(IInterstitialAdapter interstitialAdapter);
		void SetInterstitialImage(IInterstitialAdapter interstitialImage);
		void SetRewardVideo(IRewardVideoAdapter rewardVideoAdapter);
		void SetAppOpen(IAppOpenAdapter appOpenAdapter);
		void SetAppOpenResume(IAppOpenAdapter appOpenAdapter);
		void SetMRec(IMRecAdapter mRecAdapter);
		void SetNative(INativeAdapter nativeAdapter);
		void SetNativeInter(INativeAdapter nativeInterAdapter);
		void SetNativeCollapsible(INativeAdapter nativeCollapsibleAdapter);
	}
}
