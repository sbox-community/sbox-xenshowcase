using Sandbox;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sandbox
{
	//Another primitives

	[Library( "xen_sounds", Description = "Xen soundscape sesleri ve müzikleri." )]
	public partial class xen_sounds : Entity
	{
		static readonly SoundEvent Boid = new( "sounds/xen/boid.vsnd" )
		{
			Volume = 0.3f
		};
		static readonly SoundEvent Teleport = new( "sounds/xen/teleport_winddown1.vsnd" )
		{
			Volume = 0.5f
		};
		static readonly SoundEvent Ambient = new( "sounds/xen/xen_amb17a.vsnd" )
		{
			Volume = 0.3f
		};

		static readonly SoundEvent Music01 = new( "sounds/joel-nielsen-xen-soundtrack-01-transcendent.vsnd" )
		{
			Volume = 0.1f
		};
		//static readonly SoundEvent Music02 = new( "sounds/joel-nielsen-xen-soundtrack-04-convergence.vsnd" ) { Volume = 0.1f };
		//static readonly SoundEvent Music03 = new( "sounds/joel-nielsen-xen-soundtrack-03-entangled.vsnd" ) { Volume = 0.1f };

		private bool spawned = true;

		public override void Spawn()
		{
			base.Spawn();
			Transmit = TransmitType.Always;

			if ( spawned )
			{
				_ = Musics();
				_ = BoidPlay();
				_ = TeleportPlay();
				_ = AmbientPlay();

				spawned = false;
			}
		}

		async Task Musics()
		{
			while ( true )
			{
				if ( !spawned )
				{

					var delayTime = 0;
					var random = Rand.Int( 1, 3 );
					/*if ( random == 1 )
					{*/
					Sound.FromEntity( Music01.Name, this );
					delayTime = 95;
					/*}
							else if (random == 2){
								Sound.FromEntity( Music02.Name, this );
								delayTime = 119;
								}
							else
							{
								Sound.FromEntity( Music03.Name,this );
								delayTime = 105;
								}*/

					await Task.Delay( delayTime * 1000 );
				}
				else
				{
					await Task.Delay( 1000 );
				}
			}
		}

		async Task BoidPlay()
		{
			Boid.Volume = 0.1F;
			Boid.Create();
			while ( true )
			{
				if ( !spawned )
				{
					Sound.FromEntity( Boid.Name, this );
					await Task.Delay( 18 * 1000 );
				}
				else
				{
					await Task.Delay( 1000 );
				}
			}
		}

		async Task TeleportPlay()
		{
			while ( true )
			{
				if ( !spawned )
				{
					await Task.Delay( 14 * 1000 );
					if ( Rand.Int( 1, 3 ) == 2 )
					{
						Sound.FromEntity( Teleport.Name, this );
					}
				}
				else
				{
					await Task.Delay( 1000 );
				}
			}
		}
		async Task AmbientPlay()
		{
			while ( true )
			{
				await Task.Delay( 31 * 1000 );
				Sound.FromEntity( Ambient.Name, this );
			}
		}
	}
}
