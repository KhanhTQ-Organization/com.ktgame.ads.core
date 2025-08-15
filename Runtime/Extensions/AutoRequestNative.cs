using System;
using Cysharp.Threading.Tasks;

namespace com.ktgame.ads.core.extensions
{
    public class AutoRequestNative : NativeDecorator, IDisposable
    {
        private readonly IRequestStrategy _requestStrategy;
        private readonly float _initialDelay;
        private readonly float _retryDelay;
        private bool _isLoading;
        private bool _hasAd;

        public AutoRequestNative(IRequestStrategy requestStrategy, INativeAdapter adapter, float initialDelaySeconds = 1f, float retryDelaySeconds = 3f) : base(adapter)
        {
            _initialDelay = initialDelaySeconds;
            _retryDelay = retryDelaySeconds;
            _requestStrategy = requestStrategy;

            _requestStrategy.OnRequest += OnRequestTriggered;
        }

        private void OnRequestTriggered()
        {
            if (_isLoading || _hasAd)
            {
                return;
            }

            LoadWithDelay(_initialDelay).Forget();
        }

        private async UniTaskVoid LoadWithDelay(float delay)
        {
            _isLoading = true;

            if (delay > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delay));
            }

            Load();
        }

        protected override void LoadSucceededHandler(AdPlacement placement)
        {
            base.LoadSucceededHandler(placement);
            _isLoading = false;
            _hasAd = true;
            _requestStrategy.MarkSuccess();
        }

        protected override void LoadFailedHandler(AdError error)
        {
            base.LoadFailedHandler(error);
            _isLoading = false;
            _hasAd = false;

            //RetryLoadAsync().Forget();
        }

        private async UniTask RetryLoadAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_retryDelay));
            _requestStrategy.Request();
        }

        public void InvalidateAd()
        {
            _hasAd = false;
        }

        public void Dispose()
        {
            _requestStrategy.OnRequest -= OnRequestTriggered;
        }
    }
}
