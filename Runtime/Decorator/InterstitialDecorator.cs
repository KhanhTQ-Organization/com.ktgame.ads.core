using System;

namespace com.ktgame.ads.core
{
	public class InterstitialDecorator : IInterstitialAdapter
	{
		protected IInterstitialAdapter Adapter { private set; get; }
		public event Action<AdError> OnLoadFailed;
		public event Action OnLoadSucceeded;
		public event Action<AdError> OnShowFailed;
		public event Action<AdPlacement> OnShowSucceeded;
		public event Action<AdPlacement> OnClicked;
		public event Action OnClosed;
		public event Action<ImpressionData> OnImpressionSuccess;
		public event Action<ImpressionData> OnPaid;
		public bool IsReady => Adapter.IsReady;

		protected InterstitialDecorator(IInterstitialAdapter adapter)
		{
			Adapter = adapter;
			Adapter.OnLoadFailed += LoadFailedHandler;
			Adapter.OnShowFailed += ShowFailedHandler;
			Adapter.OnShowSucceeded += ShowSucceededHandler;
			Adapter.OnClicked += ClickHandler;
			Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
			Adapter.OnLoadSucceeded += LoadSucceededHandler;
			Adapter.OnClosed += ClosedHandler;
			Adapter.OnPaid += AdRevenuePaidHandler;
		}

		protected virtual void AdRevenuePaidHandler(ImpressionData impressionData)
		{
			OnPaid?.Invoke(impressionData);
		}

		protected virtual void ClosedHandler()
		{
			OnClosed?.Invoke();
		}

		protected virtual void LoadSucceededHandler()
		{
			OnLoadSucceeded?.Invoke();
		}

		protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
		{
			OnImpressionSuccess?.Invoke(impressionData);
		}

		protected virtual void ClickHandler(AdPlacement adPlacement)
		{
			OnClicked?.Invoke(adPlacement);
		}

		protected virtual void ShowSucceededHandler(AdPlacement adPlacement)
		{
			OnShowSucceeded?.Invoke(adPlacement);
		}

		protected virtual void ShowFailedHandler(AdError adError)
		{
			OnShowFailed?.Invoke(adError);
		}

		protected virtual void LoadFailedHandler(AdError adError)
		{
			OnLoadFailed?.Invoke(adError);
		}

		public void Load()
		{
			Adapter.Load();
		}

		public void Show(AdPlacement adPlacement)
		{
			Adapter.Show(adPlacement);
		}
	}
}
