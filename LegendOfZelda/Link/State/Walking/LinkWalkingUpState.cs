﻿using LegendOfZelda.Link.Interface;
using LegendOfZelda.Link.State.Attacking;
using LegendOfZelda.Link.State.Item;
using LegendOfZelda.Link.State.NotMoving;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Link.State.Walking
{
    class LinkWalkingUpState : LinkActiveAbstractState
    {
        private int distanceWalked;

        public LinkWalkingUpState(LinkPlayer link) : base(link)
        {
        }

        public LinkWalkingUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime) : base(link, damaged, healthyDateTime)
        {
        }
        public LinkWalkingUpState(LinkPlayer link, bool damaged, DateTime healthyDateTime, bool walkingToggle) : base(link, damaged, healthyDateTime)
        {
            this.walkingToggle = walkingToggle;
        }

        protected override void InitClass()
        {
            distanceWalked = 0;
            link.CurrentSprite = LinkSpriteFactory.Instance.CreateWalkingUpLinkSprite();
            link.Velocity = new Vector2(0, -1 * Constants.LinkWalkStepDistanceInterval);
            blockNewDirection = true;
        }

        public override void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.Mover.Update();
            distanceWalked += (int)link.Mover.Velocity.Length();
            link.CurrentSprite.Update();

            if (distanceWalked > Constants.LinkWalkDistanceInterval)
            {
                StopMoving();
            }
        }
        public override void MoveUp()
        {
            // Already moving up, do nothing
        }

        public override void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.Position, damaged, walkingToggle);
        }

        public override void StopMoving()
        {
            link.State = new LinkStandingStillUpState(link, damaged, healthyDateTime, walkingToggle);
        }

        public override void UseSword()
        {
            link.State = new LinkAttackingUpState(link, damaged, healthyDateTime);
        }

        public override void UseBow()
        {
            link.State = new LinkUsingBowUpState(link, damaged, healthyDateTime);
        }

        public override void UseBomb()
        {
            link.State = new LinkUsingBombUpState(link, damaged, healthyDateTime);
        }

        public override void UseBoomerang()
        {
            link.State = new LinkUsingBoomerangUpState(link, damaged, healthyDateTime);
        }

        public override void UseSwordBeam()
        {
            link.State = new LinkUsingSwordBeamUpState(link, damaged, healthyDateTime);
        }
    }
}
