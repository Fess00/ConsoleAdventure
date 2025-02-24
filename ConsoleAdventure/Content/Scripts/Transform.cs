﻿using ConsoleAdventure.Settings;
using ConsoleAdventure.WorldEngine;

namespace ConsoleAdventure
{
    abstract public class Transform
    {
        public WorldEngine.World world { get; protected set; }
        public int worldLayer { get; protected set; }
        
        public Position position;
        public RenderFieldType renderFieldType;
        public bool isObstacle;

        protected Transform(WorldEngine.World world, Position position = null)
        {
            if (position != null) this.position = position;
            else this.position = new Position(0, 0);

            this.world = world;
        }

        public void Initialize()
        {
            world.fields[worldLayer][position.y][position.x].content = this;
        }

        public virtual void Move(int stepSize, Rotation rotation)
        {
            world.MoveSubject(this, worldLayer, stepSize, rotation);
        }

        public string GetSymbol()
        {
            switch (renderFieldType)
            {
                case RenderFieldType.empty:
                    return "  ";
                case RenderFieldType.player:
                    return " ^";
                case RenderFieldType.ruine:
                    return "::";
                case RenderFieldType.wall:
                    return "##";
                case RenderFieldType.tree:
                    return " *";
                case RenderFieldType.floor:
                    return " .";
                case RenderFieldType.door:
                    return "[]";
                case RenderFieldType.loot:
                    return " $";
                default:
                    return "??";
            }

        }
    }
}
