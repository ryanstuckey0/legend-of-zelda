﻿using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Item
{
    class LinkPickingUpBowState : LinkLazyAbstractState
    {
        public const int spawnOffsetX = 0;
        public const int spawnOffsetY = -15;

        public LinkPickingUpBowState(LinkPlayer link) : base(link)
        {
        }

        public LinkPickingUpBowState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }

        protected override void InitClass()
        {
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBowSprite();
        }

        public override void Update()
        {
            if (link.CurrentSprite.FinishedAnimation())
            {
                link.BlockStateChange = false;
                StopMoving();
            }
            else
            {
                link.BlockStateChange = true;
            }
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
        }

        public override void Draw()
        {
            float posX = link.GetPosition().X + spawnOffsetX;
            float posY = link.GetPosition().Y + spawnOffsetY;
            link.CurrentSprite.Draw(link.Game.SpriteBatch, new Vector2(posX, posY), damaged);
        }

        public override void StopMoving()
        {
            link.SetState(new LinkStandingStillDownState(link, damaged, healthyDateTime));
        }
    }
}
