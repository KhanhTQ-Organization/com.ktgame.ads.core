using System;
namespace com.ktgame.ads.core
{
	public class NullAdAdapter : IAdAdapter
	{
		public IBannerAdapter Banner { private set; get; }
		public IInterstitialAdapter Interstitial { private set; get; }
		public IInterstitialAdapter InterstitialImage { private set; get; }
		public IRewardVideoAdapter RewardVideo { private set; get; }
		public IAppOpenAdapter AppOpen { private set; get; }
		public IMRecAdapter MRec { private set; get; }
		public INativeAdapter Native { private set; get; }
		public INativeAdapter NativeInter { private set; get; }

		public NullAdAdapter()
		{
			Banner = NullBannerAdapter.Instance;
			Interstitial = NullInterstitialAdapter.Instance;
			InterstitialImage = NullInterstitialAdapter.Instance;
			RewardVideo = NullRewardVideoAdapter.Instance;
			AppOpen = NullAppOpenAdapter.Instance;
			MRec = NullMRecAdapter.Instance;
			Native = NullNativeAdapter.Instance;
		}

		public void Initialize(Action<bool> onComplete)
		{
			onComplete.Invoke(true);
		}

		public void SetPause(bool pause)
		{
            
		}

		public void SetBanner(IBannerAdapter bannerAdapter)
		{
			Banner = bannerAdapter;
		}

		public void SetInterstitial(IInterstitialAdapter interstitialAdapter)
		{
			Interstitial = interstitialAdapter;
		}

		public void SetRewardVideo(IRewardVideoAdapter rewardVideoAdapter)
		{
			RewardVideo = rewardVideoAdapter;
		}

		public void SetAppOpen(IAppOpenAdapter appOpenAdapter)
		{
			AppOpen = appOpenAdapter;
		}

		public void SetMRec(IMRecAdapter mRecAdapter)
		{
			MRec = mRecAdapter;
		}
		
		public void SetNative(INativeAdapter nativeAdapter)
		{
			Native = nativeAdapter;
		}

		public void SetNativeInter(INativeAdapter nativeInterAdapter)
		{
			NativeInter = nativeInterAdapter;
		}

		public void SetInterstitialImage(IInterstitialAdapter interstitialImage)
		{
			InterstitialImage = interstitialImage;
		}
	}
}
