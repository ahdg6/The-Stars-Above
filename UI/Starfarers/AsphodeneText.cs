﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace StarsAbove.UI.Starfarers
{
    internal class AsphodeneText : UIState
	{
		// For this bar we'll be using a frame texture and then a gradient inside bar, as it's one of the more simpler approaches while still looking decent.
		// Once this is all set up make sure to go and do the required stuff for most UI's in the Mod class.
		private UIText text;
		private UIText warning;
		
		private UIText AText;
		private UIText EridaniText;
		private UIElement area;
		private UIElement area2;
		private UIElement area3;
		private UIImage barFrame;
		private UIImage bg;
		private UIImageButton imageButton;
		private UIImage bulletIndicatorOn;
		private Color gradientA;
		private Color gradientB;
		private Color finalColor;
		private Vector2 offset;
		public bool dragging = false;
		public static bool Draggable;
		public override void OnInitialize() {
			

			area = new UIElement(); 
			area.Left.Set(-25, 0f);
			area.Top.Set(160, 0f); 
			area.Width.Set(700, 0f); 
			area.Height.Set(300, 0f);
			area.HAlign = area.VAlign = 0.5f; // 1

			text = new UIText("", 1.2f);
			text.Width.Set(0, 0f);
			text.Height.Set(155, 0f);
			text.Top.Set(73, 0f);
			text.Left.Set(200, 0f);


			area.OnMouseDown += new UIElement.MouseEvent(DragStart);
			area.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			

			barFrame = new UIImage(Request<Texture2D>("StarsAbove/UI/Starfarers/blank"));
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

			imageButton = new UIImageButton(Request<Texture2D>("StarsAbove/UI/Starfarers/Button"));
			imageButton.OnClick += MouseClickA;
			imageButton.Left.Set(600, 0f);
			imageButton.Top.Set(222, 0f);
			imageButton.Width.Set(70, 0f);
			imageButton.Height.Set(52, 0f);
			/*Asphodene = new UIImage(Request<Texture2D>("StarsAbove/UI/Starfarers/Eridani"));
			Asphodene.OnMouseOver += MouseOverA;
			Asphodene.OnClick += MouseClickA;
			Asphodene.Top.Set(0, 0f);
			Asphodene.Left.Set(0, 0f);
			Asphodene.Width.Set(0, 0f);
			Asphodene.Height.Set(0, 0f);*/





			gradientA = new Color(249, 133, 36); // 
			gradientB = new Color(255, 166, 83); //
			//area3.Append(Asphodene);
			
			area.Append(text);
			
			area.Append(barFrame);
			area.Append(imageButton);
			Append(area);

			
		}
		private void DragStart(UIMouseEvent evt, UIElement listeningElement)
		{
			if (!(Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogueVisibility >= 2f && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogue == true && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().chosenStarfarer == 1) && Draggable)
				return;
			if (!Draggable)
			{
				offset = new Vector2(evt.MousePosition.X - area.Left.Pixels, evt.MousePosition.Y - area.Top.Pixels);
				dragging = true;
			}
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			if (!(Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogueVisibility >= 2f && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogue == true && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().chosenStarfarer == 1) && Draggable)
				return;
			if (!Draggable)
			{
				Vector2 end = evt.MousePosition;
				dragging = false;

				area.Left.Set(end.X - offset.X, 0f);
				area.Top.Set(end.Y - offset.Y, 0f);

				Recalculate();
			}
		}
		private void MouseClickA(UIMouseEvent evt, UIElement listeningElement)
		{
			if (!(Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogueVisibility >= 2f && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogue == true && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().chosenStarfarer == 1))
				return;

			if (Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogueScrollNumber < Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogue.Length)
			{
				Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogueScrollNumber = Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogue.Length;
			}
			else
            {
				Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogueLeft--;
				Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogueScrollTimer = 0;
				Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogueScrollNumber = 0;

				if (Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogueLeft <= 0)
				{
					Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogue = false;
					Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().chosenDialogue = 0;
					Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().dialogue = "";

				}
			}
			




			// We can do stuff in here!
		}


		public override void Draw(SpriteBatch spriteBatch) {
			// This prevents drawing unless we are using an ExampleDamageItem
			if (!(Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogueVisibility > 0 && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().chosenStarfarer == 1))
				return;

			base.Draw(spriteBatch);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			var modPlayer = Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>();
			// Calculate quotient
			
			Rectangle hitbox = area.GetInnerDimensions().ToRectangle();
			

			//Rectangle indicator = new Rectangle((600), (280), (700), (440));
			//indicator.X += 0;
			//indicator.Width -= 0;
			//indicator.Y += 0;
			//indicator.Height -= 0;

			//Rectangle dialogueBox = new Rectangle((50), (480), (700), (300));


			spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/Dialogue"), hitbox, Color.White * modPlayer.starfarerDialogueVisibility);
			if (modPlayer.vagrantDialogue == 2)
			{
				spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/HA" + modPlayer.expression), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));
			}
			else
			{
				spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/A" + modPlayer.expression), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));

			}
			if(modPlayer.starfarerOutfitVisible != 0 && modPlayer.expression < 10)
            {
				spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/AOutfit" + modPlayer.starfarerOutfitVisible), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));

			}
			if (modPlayer.expression == 0 || modPlayer.expression == 1 || modPlayer.expression == 2 || modPlayer.expression == 3 || modPlayer.expression == 4 || modPlayer.expression == 6)
			{
				if (modPlayer.blinkTimer > 70 && modPlayer.blinkTimer < 75)
				{
					spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/ABlink"), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));
				}
				if (modPlayer.blinkTimer > 320 && modPlayer.blinkTimer < 325)
				{
					spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/ABlink"), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));
				}
				if (modPlayer.blinkTimer > 420 && modPlayer.blinkTimer < 425)
				{
					spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/ABlink"), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));
				}
				if (modPlayer.blinkTimer > 428 && modPlayer.blinkTimer < 433)
				{
					spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/ABlink"), hitbox, Color.White * (modPlayer.starfarerDialogueVisibility - 0.3f));
				}
			}

			spriteBatch.Draw((Texture2D)Request<Texture2D>("StarsAbove/UI/Starfarers/DialogueTop"), hitbox, Color.White * modPlayer.starfarerDialogueVisibility);



			Recalculate();


		}
			
		
		public override void Update(GameTime gameTime) {
			if (!(Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().starfarerDialogueVisibility > 0 && Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>().chosenStarfarer == 1))
			{
				area.Remove();
				return;

			}
			else
			{
				Append(area);
			}
			
			var modPlayer = Main.LocalPlayer.GetModPlayer<StarsAbovePlayer>();

			// Setting the text per tick to update and show our resource values.
			text.SetText($"{modPlayer.animatedDialogue}");
			


			//text.SetText($"[c/5970cf:{modPlayer.judgementGauge} / 100]");
			base.Update(gameTime);
		}
	}
}
