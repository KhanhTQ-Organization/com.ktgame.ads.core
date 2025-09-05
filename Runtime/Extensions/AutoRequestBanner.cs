namespace com.ktgame.ads.core.extensions
{
	public class AutoRequestBanner : BannerDecorator
	{
		protected IRequestStrategy RequestStrategy { private set; get; }

		public AutoRequestBanner(IRequestStrategy requestStrategy, IBannerAdapter adapter) : base(adapter)
		{
			RequestStrategy = requestStrategy;
			RequestStrategy.OnRequest += RequestHandler;
		}

		private void RequestHandler()
		{
			Load();
		}

		protected override void LoadFailedHandler(AdError error)
		{
			base.LoadFailedHandler(error);
			RequestStrategy.Request();
		}

		protected override void LoadSucceededHandler(AdPlacement placement)
		{
			base.LoadSucceededHandler(placement);
			RequestStrategy.MarkSuccess();
			RequestStrategy.OnRequest -= RequestHandler;
		}
	}
}
