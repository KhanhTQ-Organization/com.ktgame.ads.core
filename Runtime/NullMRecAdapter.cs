using System;
using UnityEngine;

namespace com.ktgame.ads.core
{
	public class NullMRecAdapter : IMRecAdapter
	{
		public static readonly NullMRecAdapter Instance = new NullMRecAdapter();
        
		public event Action<AdPlacement> OnLoadSucceeded;
		public event Action<AdError> OnLoadFailed;
		public event Action<AdPlacement> OnClicked;
		public event Action<ImpressionData> OnImpressionSuccess;
		public bool IsReady => true;
		
		private NullMRecAdapter()
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
		public void UpdateMRecPosition(MRecPosition position)
		{
            
		}
		public void UpdateMRecPosition(Vector2 position)
		{
           
		}
		public void Destroy()
		{
           
		}
	}
}