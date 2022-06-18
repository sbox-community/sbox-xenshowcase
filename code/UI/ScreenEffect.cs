using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;

public class ScreenEffect: Panel
{
	//Another privimites
	private List<Texture> textlist = new List<Texture>();
	private float frametimelimit;
	private float frame;
	//private float oldHeight;
	public ScreenEffect() {}
	public void Select(float newframe, float newframelimit, List<Texture> newtextlist)
	{

		frame = newframe;
		frametimelimit = newframelimit;
		textlist = newtextlist;
		//oldHeight = Screen.Height;

		Style.BackgroundImage = textlist[0];
		Style.BackgroundPositionX = Length.Pixels( 0 );
		Style.BackgroundPositionY = Length.Pixels( 0 );
		Style.BackgroundSizeX = Length.Cover;
		Style.BackgroundSizeY = Length.Cover;
		Style.Width = Length.ViewWidth( 100 );
		Style.Height = Length.ViewHeight( 100 );
		Style.Position = PositionMode.Absolute;
		Style.MixBlendMode = "lighten";// "normal";
		//Style.Opacity = 0.5f;
		//Style.BackdropFilterBrightness = Length.Pixels( 2f );
	}


	private float lasttime = 0;
	private int ti = 0;
	public override void Tick()
	{
		//TODO: catch changes of screen res.
		/*if ( !Screen.Height.Equals(oldHeight) )
		{
			oldHeight = Screen.Height;
			Style.BackgroundSizeX = Length.Cover;
			Style.BackgroundSizeY = Length.Cover;
			Style.Dirty();
		}*/
		var player = Local.Pawn;
		if ( player == null ) return;
		lasttime += Time.Delta;
		if ( lasttime > PerformanceStats.FrameTime*frametimelimit )
		{
			Style.BackgroundImage = textlist[frame-1 < ti ? ti = 0 : ti++];
			lasttime = 0;
		}

		base.Tick();
	}
}

