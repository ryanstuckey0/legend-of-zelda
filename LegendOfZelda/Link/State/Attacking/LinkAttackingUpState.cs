﻿using Sprint0.Link.Interface;
using Sprint0.Link.State.NotMoving;
using System;

namespace Sprint0.Link.State.Attacking
{
    class LinkAttackingUpState : ILinkState
    {
        private Link link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkAttackingUpState(Link link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkAttackingUpState(Link link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateStrikingUpLinkSprite();
            link.BlockStateChange = true;
        }

        public void Update()
        {
            damaged = damaged && DateTime.Compare(DateTime.Now, healthyDateTime) < 0; // only compare if we're damaged
            link.CurrentSprite.Update();
            if (link.CurrentSprite.FinishedAnimation())
            {
                link.BlockStateChange = false;
                StopMoving();
            }
        }

        public void Draw()
        {
            link.CurrentSprite.Draw(link.Game.SpriteBatch, link.GetPosition(), damaged);
        }

        public void MoveDown()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveLeft()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveRight()
        {
            // Cannot interupt state, do nothing
        }

        public void MoveUp()
        {
            // Cannot interupt state, do nothing
        }

        public void BeDamaged(int damage)
        {
            if (!damaged)
            {
                this.link.SubtractHealth(damage);
                healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
            }
        }

        public void BeHealthy()
        {
            damaged = false;
        }

        public void StopMoving()
        {
            link.SetState(new LinkStandingStillUpState(link, damaged, healthyDateTime));
        }

        public void UseSword()
        {
            // Already attacking, do nothing
        }

        public void PickUpItem()
        {
            // Cannot interupt state, do nothing
        }

        public void UseItem()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpSword()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpHeartContainer()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpTriforce()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpBow()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpBoomerang()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBomb()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBoomerang()
        {
            // Cannot interupt state, do nothing
        }

        public void UseBow()
        {
            // Cannot interupt state, do nothing
        }

        public void UseSwordBeam()
        {
            // Cannot interupt state, do nothing
        }
    }
}