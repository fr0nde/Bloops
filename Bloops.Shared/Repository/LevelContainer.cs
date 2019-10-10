using System;
using System.Collections.Generic;
using Bloops.Shared.Entities;

namespace Bloops.Shared.Repository
{
    public static class LevelContainer
    {
        private static Dictionary<int, Level> LevelDictionary;

        public static void Initialize()
        {
            LevelDictionary = new Dictionary<int, Level>() {
                // Level du monde 1
                {1, new Level(1,1,0,0,0, new List<Obstacle>() {})},
                {2, new Level(2,1,0,0,0, new List<Obstacle>() {})},
                {3, new Level(3,1,0,0,0, new List<Obstacle>() {})},
                {4, new Level(4,1,0,0,0, new List<Obstacle>() {})},
                {5, new Level(5,1,0,0,0, new List<Obstacle>() {})},
                {6, new Level(6,1,0,0,0, new List<Obstacle>() {})},
                {7, new Level(7,1,0,0,0, new List<Obstacle>() {})},
                {8, new Level(8,1,0,0,0, new List<Obstacle>() {})},
                {9, new Level(9,1,0,0,0, new List<Obstacle>() {})},
                {10, new Level(10,1,0,0,0, new List<Obstacle>() {})},
                // Level du monde 2
                {11, new Level(11,2,0,0,0, new List<Obstacle>() {})},
                {12, new Level(12,2,0,0,0, new List<Obstacle>() {})},
                {13, new Level(13,2,0,0,0, new List<Obstacle>() {})},
                {14, new Level(14,2,0,0,0, new List<Obstacle>() {})},
                {15, new Level(15,2,0,0,0, new List<Obstacle>() {})},
                {16, new Level(16,2,0,0,0, new List<Obstacle>() {})},
                {17, new Level(17,2,0,0,0, new List<Obstacle>() {})},
                {18, new Level(18,2,0,0,0, new List<Obstacle>() {})},
                {19, new Level(19,2,0,0,0, new List<Obstacle>() {})},
                {20, new Level(20,2,0,0,0, new List<Obstacle>() {})}
            };
        }

        public static Level GetLevelById(int id)
        {
            return LevelDictionary[id];
        }
    }
}
