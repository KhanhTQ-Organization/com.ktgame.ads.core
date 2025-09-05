namespace com.ktgame.ads.core.extensions
{
	public class AutoRequestMRec : MRecDecorator
	{
		protected IRequestStrategy RequestStrategy { private set; get; }

		public AutoRequestMRec(IRequestStrategy requestStrategy, IMRecAdapter adapter) : base(adapter)
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
