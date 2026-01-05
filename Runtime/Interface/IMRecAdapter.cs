using System;
using UnityEngine;

namespace com.ktgame.ads.core
{
	public interface IMRecAdapter
	{
		event Action<AdPlacement> OnLoadSucceeded;
		event Action<AdError> OnLoadFailed;
		event Action<AdPlacement> OnClicked;
		event Action<ImpressionData> OnImpressionSuccess;
		bool IsReady { get; }
		void Load();
		void Show();
		void Hide();
		void UpdateMRecPosition(MRecPosition position);
		void UpdateMRecPosition(Vector2 position);
		void Destroy();
	}
}
