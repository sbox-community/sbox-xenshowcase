using Sandbox;
using Sandbox.UI;

namespace gamemodecustomtr
{
	public partial class HUD : Sandbox.HudEntity<RootPanel>
	{ 
		public static HUD Instance;
  
		public HUD() => BuildHUD();

		[Event.Hotload]
		void BuildHUD()
		{   
			Instance = this;
			
			if ( !IsClient ) 
				return;

			RootPanel.DeleteChildren( true );
			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<Menu>();
		}
	}
}
