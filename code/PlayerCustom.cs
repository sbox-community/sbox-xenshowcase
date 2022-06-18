using Sandbox;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gamemodecustomtr
{
	public partial class PlayerCustom : Player
	{
		private TimeSince timeSinceJumpReleased;
		public static PlayerCustom Instance;
		private bool spawned = true;
		private bool spawnedcl = true;
		private TimeSince whenspawned = 0f;
		private AnimatedEntity modelent;
		private bool renderTheCamera = false;
		private List<Texture> teleporterscreen = new List<Texture>();
		private static Entity returnpad;
		private static AnimatedEntity returnpadcl;
		//private List<Texture> startup = new List<Texture>();
		public PlayerCustom()
		{
			if ( Instance == null )
				Instance = this;

			Inventory = new Inventory( this );
		}

		public override void Respawn()
		{ 
			base.Respawn();

			SetModel( "models/citizen/citizen.vmdl" );
			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			CameraMode = new FirstPersonCamera();
			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			Inventory.DeleteContents();

			WalkController controller = new WalkController();
			controller.Gravity = 170f;
			Controller = controller;

			fpAnim();
		}

		public override void BuildInput( InputBuilder input )
		{
			base.BuildInput( input );

			if ( renderTheCamera )
			{
				var pawn = Local.Pawn;
				if ( pawn == null ) return;

				input.Clear();
				if ( scene == 0 )
					input.ViewAngles = ent1.GetAttachment( "cameraParent" ).Value.Rotation.Angles();
				else if ( scene == 1 )
				{
					var cameraang = ent3.GetAttachment( "cameraParent" ).Value.Rotation.Angles();
					input.ViewAngles = new Angles( 25 + (cameraang.pitch), -167, 0 + (cameraang.roll / 4) );

				}
				else if ( scene == 2 )
					input.ViewAngles = new Angles( 0, 90, 0 );
				else if ( scene == 3 )
					input.ViewAngles = modelent.GetAttachment( "camera_parent" ).Value.Rotation.Angles();
			}
		}

		public void CallUse()
		{

			var Tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 85 )
				.Ignore( this )
				.HitLayer( CollisionLayer.Debris )
				.Radius( 2f )
				.Run();


			if ( Tr.Entity == null ) return;

			if ( Tr.Entity is not IUse Use ) return;

			if ( !Use.IsUsable( this ) ) return;


			Use.OnUse( this );
		}
		public override void OnKilled()
		{
			base.OnKilled();
			EnableDrawing = false;
		}
		public override void Simulate( Client cl )
		{
			base.Simulate( cl );


			SimulateActiveChild( cl, ActiveChild );

			if ( spawned && whenspawned > 1.5f )
			{
				spawned = false;
			}

			// Viewpoint switching
			if ( Input.Pressed( InputButton.View ) )
			{
				if ( CameraMode is not FirstPersonCamera )
				{
					CameraMode = new FirstPersonCamera();

				}
				else
				{
					CameraMode = new ThirdPersonCamera();
				}
			}


			if ( Input.Released( InputButton.Jump ) )
			{
				if ( timeSinceJumpReleased < 0.3f )
				{
					Game.Current?.DoPlayerNoclip( cl );
				}

				timeSinceJumpReleased = 0;
			}

			if ( Input.Left != 0 || Input.Forward != 0 )
			{
				timeSinceJumpReleased = 1;
			}

			if ( !IsServer || Health <= 0 ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( InputButton.Use ) )
				{
					CallUse();
				}
				if ( Input.MouseWheel != 0 && Inventory.Count() != 0 )
				{
					int newSpot = Inventory.GetActiveSlot() + Math.Sign( Input.MouseWheel );

					if ( newSpot < -1 )
					{
						newSpot = Inventory.Count() - 1;
					}

					Inventory.SetActiveSlot( newSpot, true );
				}
			}

		}

		/// <summary>
		///  Animations
		/// </summary>
		/// 

		private static AnimatedEntity ent1;
		private static AnimatedEntity ent2;
		private static AnimatedEntity ent3;
		private static AnimatedEntity ent4;
		private static AnimatedEntity ent5;
		private static AnimatedEntity ent6;
		private static Particles particle1;
		private static Particles kulelight;
		private static Particles kulelight2;
		private static Particles tplight1;
		private static Particles tplight2;
		private static Particles tplight3;
		private static Particles tplight4;
		private static Particles tplight5;
		private static Particles tplight6;
		private static Particles tplight7;
		private static Particles tplight8;
		private static Particles tplight9;
		private static Particles tplight10;
		private static Particles tplight11;
		private static Particles tplight12;
		private static Particles tplight13;
		private static Particles tplight14;
		private static Particles tplight15;
		private static Particles tplight16;
		private static Particles tplight17;
		private static ScreenEffect sceffect;
		private static int scene = 4;

		/*[ServerCmd( "playanim" )]
		public static void playanim()
		{

			var client = ConsoleSystem.Caller;
			var player = client.Pawn as PlayerCustom;

			player.fpAnim(true);
		}*/

		public static void tpeffects()
		{

			tplight1 = Particles.Create( "particles/tp_light.vpcf" );
			tplight1.SetPosition( 0, new Vector3( 3274.70f, 3525.1f, -4676.0f ) );

			tplight2 = Particles.Create( "particles/tp_light.vpcf" );
			tplight2.SetPosition( 0, new Vector3( 3307.45f, 3539.06f, -4676.0f ) );

			tplight3 = Particles.Create( "particles/tp_light.vpcf" );
			tplight3.SetPosition( 0, new Vector3( 3322.21f, 3572.01f, -4676.0f ) );

			tplight4 = Particles.Create( "particles/tp_light.vpcf" );
			tplight4.SetPosition( 0, new Vector3( 3308.16f, 3605.15f, -4676.0f ) );

			tplight5 = Particles.Create( "particles/tp_light.vpcf" );
			tplight5.SetPosition( 0, new Vector3( 3275.38f, 3618.66f, -4676.0f ) );

			tplight6 = Particles.Create( "particles/tp_light.vpcf" );
			tplight6.SetPosition( 0, new Vector3( 3241.86f, 3605.83f, -4676.0f ) );

			tplight7 = Particles.Create( "particles/tp_light.vpcf" );
			tplight7.SetPosition( 0, new Vector3( 3228.18f, 3572.27f, -4676.0f ) );
			
			tplight8 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight8.SetPosition( 0, new Vector3( 3222.97f, 3566f, -4672.2f ) );

			tplight9 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight9.SetPosition( 0, new Vector3( 3225.5f, 3593.5f, -4672.1f ) );

			tplight10 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight10.SetPosition( 0, new Vector3( 3242.70f, 3615.74f, -4672.2f ) );

			tplight11 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight11.SetPosition( 0, new Vector3( 3268.8f, 3625.50f, -4672.2f ) );

			tplight12 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight12.SetPosition( 0, new Vector3( 3295.13f, 3620.07f, -4672.2f ) );

			tplight13 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight13.SetPosition( 0, new Vector3( 3324.93f, 3592.8f, -4672.2f ) );

			tplight14 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight14.SetPosition( 0, new Vector3( 3327.47f, 3565f, -4672.2f ) );

			tplight15 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight15.SetPosition( 0, new Vector3( 3316.92f, 3539.28f, -4672.2f ) );

			tplight16 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight16.SetPosition( 0, new Vector3( 3295f, 3523.54f, -4672.2f ) );

			tplight17 = Particles.Create( "particles/tp_light_mini.vpcf" );
			tplight17.SetPosition( 0, new Vector3( 3267.59f, 3520.1f, -4672.2f ) );

			_ = removeTeleportEffects();
			_ = removeTeleportEffects2();
		}

		//Primitive way to perform thats

		public static async Task removeTeleportEffects()
		{
			await GameTask.Delay( 6000 );
			tplight1.Destroy( false );
			tplight2.Destroy( false );
			tplight3.Destroy( false );
			tplight4.Destroy( false );
			tplight5.Destroy( false );
			tplight6.Destroy( false );
			tplight7.Destroy( false );
		}

		public static async Task removeTeleportEffects2()
		{
			await GameTask.Delay( 2000 );
			tplight17.Destroy( false );
			await GameTask.Delay( 100 );
			tplight16.Destroy( false );
			await GameTask.Delay( 100 );
			tplight15.Destroy( false );
			await GameTask.Delay( 100 );
			tplight14.Destroy( false );
			await GameTask.Delay( 100 );
			tplight13.Destroy( false );
			await GameTask.Delay( 100 );
			tplight12.Destroy( false );
			await GameTask.Delay( 100 );
			tplight11.Destroy( false );
			await GameTask.Delay( 100 );
			tplight10.Destroy( false );
			await GameTask.Delay( 100 );
			tplight9.Destroy( false );
			await GameTask.Delay( 100 );
			tplight8.Destroy( false );

		}

		private void xen1play()
		{
			scene = 0;

			if ( sceffect != null )
			{
				sceffect.Delete();
				sceffect = null;

			}
	
			if( particle1 != null)
			{
				particle1.Destroy();
				particle1 = null;
			}

			ent1 = new AnimatedEntity();
			ent1.SetModel( "models/intro/intro_nihilanth.vmdl" );
			ent1.Rotation = Rotation.From( new Angles( 0, 0, 0 ) );
			ent1.Position = new Vector3( 1917.01f, -3557.07f, 12248.47f );
			ent1.ClientSpawn();
			ent1.CurrentSequence.Name = "interdimensional";

			ent2 = new AnimatedEntity();
			ent2.SetModel( "models/intro/intro_nihilanth_tower_part1.vmdl" );
			ent2.Rotation = Rotation.From( new Angles( 0, 0, 0 ) );
			ent2.Position = new Vector3( 1917.01f, -3557.07f, 12248.47f );
			ent2.ClientSpawn();
			ent2.CurrentSequence.Name = "cinephys";

			kulelight = Particles.Create( "particles/kule_isik_mini.vpcf" );
			kulelight.SetPosition( 0, new Vector3( 2217.01f, -3557.07f, 12488.47f ) );
			kulelight2 = Particles.Create( "particles/kule_isik_mini_freq.vpcf" );
			kulelight2.SetPosition( 0, new Vector3( 2317.01f, -3557.07f, 12488.47f ) );
			
			Sound.FromWorld( "introportalwave", ent1.Position );
		}

		private void xen2play()
		{
			scene = 1;

			ent3 = new AnimatedEntity();
			ent3.SetModel( "models/intro/intro_interdimensional.vmdl" );
			ent3.Rotation = Rotation.From( new Angles( 0, 0, 0 ) );
			ent3.Position = new Vector3( 1576.06f, 276.58f, 10872 );
			ent3.ClientSpawn();
			ent3.CurrentSequence.Name = "interdimensional";

			ent4 = new AnimatedEntity();
			ent4.SetModel( "models/intro/intro_interdimensional_shell.vmdl" );
			ent4.Rotation = Rotation.From( new Angles( 0, 0, 0 ) );
			ent4.Position = new Vector3( 1576.06f, 276.58f, 10872 );
			ent4.ClientSpawn();

			ent5 = new AnimatedEntity();
			ent5.SetModel( "models/intro/intro_interdimensional_shell2.vmdl" );
			ent5.Rotation = Rotation.From( new Angles( 0, 0, 0 ) );
			ent5.Position = new Vector3( 1576.06f, 276.58f, 10872 );
			ent5.ClientSpawn();
			ent5.CurrentSequence.Name = "interdimensional";

			Sound.FromWorld( "electric_explosion3", ent3.Position );
			Sound.FromWorld( "r_ambience_xen3", ent3.Position );
			Sound.FromWorld( "r_ambience_xen2", ent3.Position );
			Sound.FromWorld( "teleport_postblast_thunder1", ent3.Position );

			sceffect = Local.Hud.FindRootPanel().AddChild<ScreenEffect>();
			sceffect.Select( 55, 2f, teleporterscreen );
		}
		private void xen3play()
		{
			scene = 2;

			if ( ent5 != null )
			{
				ent5.Delete();
				ent5 = null;
			}

			ent6 = new AnimatedEntity();
			ent6.SetModel( "models/intro/intro_shockwave.vmdl" );
			ent6.Rotation = Rotation.From( new Angles( -90, 90, 0 ) );
			ent6.Position = new Vector3( -1214.62f, -5075.11f, 11723.48f );
			ent6.ClientSpawn();
			ent6.CurrentSequence.Name = "shockwave";

			Sound.FromWorld( "interdimension_travel", ent6.Position );
			Sound.FromWorld( "portal_in_01", ent6.Position );
			Sound.FromWorld( "port_suckin1", ent6.Position );
			
		}
		private void xenlast()
		{
			scene = 3;

			modelent = new AnimatedEntity();
			modelent.SetModel( "models/xen/firstperson_standup.vmdl" );
			modelent.Position = new Vector3( 3285f, 3575f, -4677.5f );
			modelent.Rotation = Rotation.From( new Angles( 0, -150, 0 ) );
			modelent.ClientSpawn();
			

			if ( sceffect != null )
			{
				sceffect.Delete();
				sceffect = null;
			}
			if ( kulelight != null)
			{
				kulelight.Destroy();
				kulelight = null;
			}
			if ( kulelight2 != null )
			{
				kulelight2.Destroy();
				kulelight2 = null;
			}
			if ( ent1 != null )
			{
				ent1.Delete();
				ent1 = null;
			}
			if ( ent2 != null )
			{
				ent2.Delete();
				ent2 = null;
			}
			if ( particle1 != null )
			{
				particle1.Destroy();
				particle1 = null;
			}
			if ( ent3 != null )
			{
				ent3.Delete();
				ent3 = null;
			}
			if ( ent4 != null )
			{
				ent4.Delete();
				ent4 = null;
			}
			if ( ent5 != null )
			{
				ent5.Delete();
				ent5 = null;
			}
			if ( ent6 != null )
			{
				ent6.Delete();
				ent6 = null;
			}

		}

		//Precaching
		/*async Task loadStartupImages()
		{
			for ( int i = 1; i < 1788; i++ )
			{
				startup.Add( Texture.White );
				startup.Insert( i, await Texture.LoadAsync( FileSystem.Mounted, "materials/intro/startup/" + i.ToString().PadLeft( 5, '0' ) + ".png" ) );
				await Task.Delay( 100 );
			}

		}*/

		[ClientRpc]
		private void fpAnim( bool again = false )
		{
			if ( spawnedcl )
			{
				for ( int i = 0; i < 55; i++ )
					teleporterscreen.Insert( i, Texture.Load( FileSystem.Mounted, "materials/intro/screen_effect/xenteleport/xen_teleporter_screen_" + (i > 9 ? i : ("0" + i)) + "_00_00.png" ) );

				//_ = loadStartupImages();

				List<Entity> ents = All.OfType<Entity>().ToList();//.Where( e => e.ClassName == "prop_dynamic" ).
				foreach ( Entity e in ents ) {
					if ( e.Position.x == 3274.625f )
					{ 
						returnpad = e;
						break;
					}
				}
			}

			if ( returnpad.IsValid())
			{
				returnpadcl = new AnimatedEntity();
				returnpadcl.SetModel( "models/props_xen/return_pad.vmdl" );
				returnpadcl.Rotation = returnpad.Rotation;
				returnpadcl.Position = returnpad.Position;
				returnpadcl.ClientSpawn();
				returnpad.EnableDrawing = false;
			}

			if ( spawnedcl || again )
			{
				_ = playAnim( );
			}

		}

		async Task playAnim()
		{

			renderTheCamera = true;
			xen3play();

			await Task.Delay( 1500 );
			await Task.Delay( 1000 );

			ScreenFade( false, Color.White, 0.5f,0.5f, 1f );

			xen2play();

			await Task.Delay( 7000 );

			ScreenFade( false, Color.White, 2.5f, 2.5f, 1f );
			xen1play();

			await Task.Delay( 5500 );

			Sound.FromWorld( "nihilanth_coldopen01", ent1.Position );

			await Task.Delay( 6050 );

			var newlight = new PointLightEntity();
			newlight.Position = new Vector3( 3285f, 3575f, -4677.5f );
			newlight.SetLightColor( Color.Gray );
			newlight.Brightness = 10000;
			newlight.Spawn();

			if ( pp == null )
			{
				PostProcess.Add( new StandardPostProcess() );
				pp = PostProcess.Get<StandardPostProcess>();
			}

			pp.FilmGrain.Enabled = true;
			pp.FilmGrain.Intensity = 0.25f;

			pp.Saturate.Enabled = true;
			pp.Saturate.Amount = 0.75f;

			pp.ChromaticAberration.Enabled = true;
			pp.ChromaticAberration.Offset = new Vector3( 0.004f, 0.08f, 0.0f );

			pp.Sharpen.Enabled = true;
			pp.Sharpen.Strength = 1.5f;

			await Task.Delay( 500 );

			pp.FilmGrain.Enabled = false;
			pp.Saturate.Enabled = false;
			pp.ChromaticAberration.Enabled = false;
			pp.Sharpen.Enabled = false;

			newlight.Delete();

			PostProcess.Remove( pp );
			pp = null;
			ScreenFade( false, Color.White, 2.5f, 2.5f, 1f );

			xenlast();

			Sound.FromWorld( "xen_portal_in",new Vector3( 3269.11f, 3561.32f, -4659.91f) );

			await Task.Delay( 1000 );

			Sound.FromWorld( "player_breathing_knockout01_no_fx", new Vector3( 3269.11f, 3561.32f, -4659.91f ) );

			await Task.Delay( 1500 );

			Sound.FromWorld( "nihilanth_comesanother01", new Vector3( 3269.11f, 3561.32f, -4659.91f ) );

			modelent.SetAnimParameter( "first_person_standup", true );
			returnpadcl.CurrentSequence.Name = "return_pad_wind_down";
			tpeffects();
			await Task.Delay( 1000 );
			PlayMusics();
			await Task.Delay( 8500 );

			scene = 4;
			renderTheCamera = false;
			modelent.Delete();
			

			/*if ( sceffect != null )
			{
				sceffect.Delete();
				sceffect = null;
			}
			sceffect = Local.Hud.FindRootPanel().AddChild<ScreenEffect>();
			sceffect.Select( 1788, 2f,startup );

			Sound.FromScreen( "startup" );

			await Task.Delay( 5000 );

			if ( sceffect != null )
			{
				sceffect.Delete();
				sceffect = null;
			}*/

		}
		public override void PostCameraSetup( ref CameraSetup camSetup )
		{
			base.PostCameraSetup( ref camSetup );
			if ( renderTheCamera )
			{
				var camParent = scene == 0 && ent1 != null ? ent1.GetAttachment( "cameraParent" ) ?? default : (scene == 1 && ent3 != null ? ent3.GetAttachment( "cameraParent" ) ?? default : (scene == 2 && ent6 != null ? ent6.Transform : modelent != null ? modelent.GetAttachment( "camera_parent" ) ?? default : new Transform()));

				if ( scene == 1 )
				{
					camSetup.Position = camParent.Position + new Vector3( 0, 0, 0 ); camSetup.FieldOfView = 125;
				}
				else if ( scene == 0 )
				{
					camSetup.Position = camParent.Position; camSetup.FieldOfView = 50;

				}
				else
					camSetup.Position = camParent.Position;
			}
		}


		/// <summary>
		///  Post-Process and Screen Fade effects 
		/// </summary>
		/// 

		private StandardPostProcess pp;
		public float Remap( float value, float from1, float to1, float from2, float to2 )
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}

		private float sftime = 0;
		private float sfoffsettime = 0;
		private bool sffadein = false;
		private Color sfcolor = Color.White;
		private float sfmaxtime = 0;
		private float sfmaxamount = 0;
		private void ScreenFadeProcess()
		{

			if (sftime != 0)
			{
				pp.ColorOverlay.Enabled = true;
				pp.ColorOverlay.Color = sfcolor;

				var sfsontime = sftime - Time.Now;
				if ( sfsontime <= 0 )
				{
					sftime = 0;
					pp.ColorOverlay.Enabled = false;
					PostProcess.Remove( pp );
					pp = null;

					return;
				}
				if ( sfoffsettime - Time.Now > 0 )
					pp.ColorOverlay.Amount = sffadein ? 0 : sfmaxamount;
				else
					pp.ColorOverlay.Amount = sffadein ? Remap( sfsontime, 0f, sfmaxtime,  sfmaxamount ,0 ) : Remap( sfsontime, 0f, sfmaxtime, 0f,  sfmaxamount );

			}
		}
		private void ScreenFade( bool fadein, Color color, float time, float offsettime, float maxamount )
		{

			if ( pp == null )
			{
				PostProcess.Add( new StandardPostProcess() );
				pp = PostProcess.Get<StandardPostProcess>();
			}

			sftime = Time.Now + time + offsettime;
			sffadein = fadein;
			sfcolor = color;
			sfmaxamount = maxamount;
			sfmaxtime = time;
			sfoffsettime = Time.Now + offsettime;
		}


		public override void FrameSimulate( Client cl )
		{
			
			ScreenFadeProcess();

			base.FrameSimulate( cl );
		}

		/// <summary>
		///  Music Spawner
		/// </summary>
		//[ClientRpc]
		private void PlayMusics()
		{
			if ( spawnedcl )
			{
				_ = Musics();
				_ = BoidPlay();
				_ = TeleportPlay();
				_ = AmbientPlay();

				spawnedcl = false;
			}
		}
	}
}
