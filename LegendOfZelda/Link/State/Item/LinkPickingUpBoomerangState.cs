﻿using Sprint0.Link.Interface;
using Sprint0.Link.State.Attacking;
using Sprint0.Link.State.NotMoving;
using Sprint0.Link.State.Walking;
using System;

namespace Sprint0.Link.State.Item
{
    class LinkPickingUpBoomerangState : ILinkState
    {
        private Link link;
        private bool damaged;
        private DateTime healthyDateTime;

        public LinkPickingUpBoomerangState(Link link)
        {
            InitClass(link);
            damaged = false;
            healthyDateTime = DateTime.Now;
        }

        public LinkPickingUpBoomerangState(Link link, bool damaged, DateTime healthyDateTime)
        {
            InitClass(link);
            this.healthyDateTime = healthyDateTime;
            this.damaged = damaged;
        }

        private void InitClass(Link link)
        {
            this.link = link;
            this.link.CurrentSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpBoomerangSprite();
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

        public void SwordAttack()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpItem()
        {
            // Already picking up item, do nothing
        }

        public void UseItem()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpSword()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpHeart()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpTriforce()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpBow()
        {
            // Already picking up bow, do nothing
        }

        public void ShootBow()
        {
            // Cannot interupt state, do nothing
        }

        public void PickUpHeartContainer()
        {
            // Cannot interrupt state, do nothing
        }

        public void PickUpBoomerang()
        {
            // Cannot interrupt state, do nothing
        }

        public void UseBomb()
        {
            // Cannot interrupt state, do nothing
        }

        public void UseBoomerang()
        {
            // Cannot interrupt state, do nothing
        }
    }
}
