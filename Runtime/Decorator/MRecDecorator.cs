using System;
using UnityEngine;

namespace com.ktgame.ads.core
{
	public class MRecDecorator : IMRecAdapter
	{
		protected IMRecAdapter Adapter { private set; get; }
		public event Action<AdError> OnLoadFailed;
		public event Action<AdPlacement> OnLoadSucceeded;
		public event Action<AdPlacement> OnClicked;
		public event Action<ImpressionData> OnImpressionSuccess;
		//public bool IsReady => Adapter.IsReady;
		
		protected MRecDecorator(IMRecAdapter adapter)
		{
			Adapter = adapter;
			Adapter.OnLoadFailed += LoadFailedHandler;
			Adapter.OnClicked += ClickHandler;
			Adapter.OnImpressionSuccess += ImpressionSuccessHandler;
			Adapter.OnLoadSucceeded += LoadSucceededHandler;
		}
		
		protected virtual void LoadSucceededHandler(AdPlacement adPlacement)
		{
			OnLoadSucceeded?.Invoke(adPlacement);
		}

		protected virtual void ImpressionSuccessHandler(ImpressionData impressionData)
		{
			OnImpressionSuccess?.Invoke(impressionData);
		}

		protected virtual void ClickHandler(AdPlacement adPlacement)
		{
			OnClicked?.Invoke(adPlacement);
		}
		
		protected virtual void LoadFailedHandler(AdError adError)
		{
			OnLoadFailed?.Invoke(adError);
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

		public void UpdateMRecPosition(MRecPosition position)
		{
			Adapter.UpdateMRecPosition(position);
		}

		public void UpdateMRecPosition(Vector2 position)
		{
			Adapter.UpdateMRecPosition(position);
		}

		public void Destroy()
		{
			Adapter.Destroy();
		}
	}
}