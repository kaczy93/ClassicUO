﻿#region license

// BSD 2-Clause License
//
// Copyright (c) 2025, andreakarasho
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this
//   list of conditions and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using ClassicUO.Game.Managers;
using ClassicUO.Utility;

namespace ClassicUO.Game.GameObjects
{
    internal sealed class FixedEffect : GameEffect
    {
        public FixedEffect(World world, EffectManager manager, ushort graphic, ushort hue, int duration, byte speed)
            : base(world, manager, graphic, hue, duration, speed)
        {

        }

        public FixedEffect
        (
            World world,
            EffectManager manager,
            ushort sourceX,
            ushort sourceY,
            sbyte sourceZ,
            ushort graphic,
            ushort hue,
            int duration,
            byte speed
        ) : this(world, manager, graphic, hue, duration, speed)
        {
            SetSource(sourceX, sourceY, sourceZ);
        }

        public FixedEffect
        (
            World world,
            EffectManager manager,
            uint sourceSerial,
            ushort sourceX,
            ushort sourceY,
            sbyte sourceZ,
            ushort graphic,
            ushort hue,
            int duration,
            byte speed
        ) : this(world, manager, graphic, hue, duration, speed)
        {
            Entity source = World.Get(sourceSerial);

            if (source != null && SerialHelper.IsValid(sourceSerial))
            {
                SetSource(source);
            }
            else
            {
                SetSource(sourceX, sourceY, sourceZ);
            }
        }

        public override void Update()
        {
            base.Update();

            if (!IsDestroyed)
            {
                (var x, var y, var z) = GetSource();

                if (Source != null)
                {
                    Offset = Source.Offset;
                }

                if (X != x || Y != y || Z != z)
                {
                    SetInWorldTile(x, y, z);
                }
            }
        }
    }
}