using Sandbox;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace gamemodecustomtr
{
	[Library( "gamemodecustomtr", Title = "Xen Showcase" )]
	public partial class GamemodeCustom : Sandbox.Game
	{
		public static PlayerCustom Instance;
		public static ModelEntity dome;
		public static EnvironmentLightEntity lightEnv;
		private Color dynamicColor;
		public HUD GameHUD { get; set; }
		public GamemodeCustom()
		{
			if ( IsServer )
			{
				GameHUD = new HUD();
				dome = new ModelEntity();
			}
		}
		public float Remap( float value, float from1, float to1, float from2, float to2 )
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}

		public static Entity returnpad;

		[Event.Tick.Server]
		private void Tick()
		{
			dynamicColor = new Color( MathX.Clamp( System.MathF.Cos( Time.Now / 2 ), 0.65f, 1f ), MathX.Clamp( System.MathF.Cos( Time.Now / 4 ), 0.65f, 1f ), MathX.Clamp( System.MathF.Cos( Time.Now / 8 ), 0.65f, 1f ) );
			dome.RenderColor = dynamicColor;
			//dome.Scale = (float) Remap( System.MathF.Cos( Time.Now ), -1f, 1f, 3f, 4f );
			if ( lightEnv == null ) {
				lightEnv = All.OfType<EnvironmentLightEntity>().FirstOrDefault();
				return;
			}

			lightEnv.Brightness = Remap( System.MathF.Sin( Time.Now/12 ), -1f, 1f, 0.3f, 5f );
			lightEnv.SkyIntensity = Remap( System.MathF.Sin( Time.Now/12 ), -1f, 1f, 0.3f, 3f );
			lightEnv.Color = dynamicColor;
			lightEnv.SkyColor = dynamicColor;
			//lightEnv.GlowActive

			//a nonsense dynamic gravity change
			//foreach ( var ply in Client.All)
			//	((ply.Pawn as Player).Controller as WalkController).Gravity = Remap( System.MathF.Sin( Time.Now/2 ), -1f, 1f, 50, 300 );
		}


		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public bool removed = true;
		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			if (removed)
			{
				List<Entity> ents = All.OfType<Entity>().ToList();//Where( e => e.ClassName == "prop_dynamic" ).
				foreach ( Entity e in ents )
				{
					// there should be the other ways to get the dome entity without via entityname/targetname
					if ( e.Position.x == 198.125f ) 
					{
						dome.SetModel( "models/narkozmap/skybox/nrkz_dome.vmdl" );
						dome.Position = e.Position;
						dome.Rotation = e.Rotation;
						//dome.Scale = 1f;
						dome.RenderColor = new Color( 1f, 1f, 1f );
						e.Delete();
						break;

					}
					if (e.Position.x == 3274.625f )// return_pad
						returnpad = e;
				}
				removed = false;
			}

			PlayerCustom ply = new();
			client.Pawn = ply;

			ply.Respawn();
		}

		public override void DoPlayerNoclip( Client player )
		{
			if ( player.Pawn is Player basePlayer )
			{
				if ( basePlayer.DevController is NoclipController )
				{
					Log.Info( "Noclip Mode Off" );
					basePlayer.DevController = null;
				}
				else
				{
					Log.Info( "Noclip Mode On" );
					basePlayer.DevController = new NoclipController();
				}
			}
		}
	}

}
