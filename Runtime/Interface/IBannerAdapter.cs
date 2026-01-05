using System;

namespace com.ktgame.ads.core
{
    public interface IBannerAdapter
    {
        event Action<AdError> OnLoadFailed;
        event Action<AdPlacement> OnLoadSucceeded;
        event Action<ImpressionData> OnImpressionSuccess;

        void Load();
        void Show();
        void Hide();
        void Destroy();
    }
}