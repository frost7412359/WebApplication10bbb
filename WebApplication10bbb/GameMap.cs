﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10bbb
{
    public class GameMap
    {
        public GameMap()
        {

        }

        public char[,] map = {
            {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'c', ' ', ' ', ' ', ' ', 'c', ' ', ' ', ' ', ' ', ' ', 'c', 'w',    'w', 'c', ' ', ' ', ' ', ' ', ' ', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', 'c', ' ', ' ', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', 'c', ' ',    ' ', 'c', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w' ,'w', ' ', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', 'c', ' ', ' ', ' ', ' ', 'c', 'w', 'w', 'c', ' ', ' ', 'c', 'w',    'w', 'c', ' ', ' ', 'c', 'w', 'w', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'c', ' ', ' ', 'c', ' ',    ' ', 'c', ' ', ' ', 'c', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', ' ', ' ', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', ' ', ' ', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'c', ' ', ' ', ' ', ' ',    ' ', ' ', ' ', ' ', 'c', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'c', ' ', ' ', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', 'c', 'w',    'w', 'c', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', 'c', ' ', 'c', 'w', 'w', 'c', ' ', ' ', 'c', ' ', ' ', 'c', ' ',    ' ', 'c', ' ', ' ', 'c', ' ', ' ', 'c', 'w', 'w', 'c', ' ', 'c', 'w'},
            {'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w'},
            {'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w'},
            {'w', 'c', ' ', 'c', ' ', ' ', 'c', 'w', 'w', 'c', ' ', ' ', 'c', 'w',    'w', 'c', ' ', ' ', 'c', 'w', 'w', 'c', ' ', ' ', 'c', ' ', 'c', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', ' ', 'w'},
            {'w', 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'c', ' ',    ' ', 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'c', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},

        };

        //public char[,] map = {
        //    {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},
        //    {'w', 'c', ' ', ' ', ' ', ' ', 'c', ' ', ' ', ' ', ' ', ' ', 'c', 'w',    'w', 'c', ' ', ' ', ' ', ' ', ' ', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
        //    {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
        //    {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
        //    {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w',    'w', ' ', 'w', 'w', 'w', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
        //    {'w', 'c', ' ', ' ', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', 'c', ' ',    ' ', 'c', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
        //    {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w' ,'w', ' ', 'w'},
        //    {'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', ' ', 'w', 'w', ' ', 'w', 'w', 'w', 'w', ' ', 'w'},
        //    {'w', 'c', ' ', ' ', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', ' ', ' ',    ' ', ' ', ' ', ' ', 'c', ' ', ' ', 'c', ' ', ' ', ' ', ' ', 'c', 'w'},
        //    {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},

        //};
        public char[,] CoinMap = {
            {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'k', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'k', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w' ,'w', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ',    ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'c', 'c', 'c', 'c', 'c', 'w', 'c', 'c', 'c', 'c', 'w', ' ', ' ', ' ',    ' ', ' ', ' ', 'w', 'c', 'c', 'c', 'c', 'w', 'c', 'c', 'c', 'c', 'c'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ',    ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'k', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'k', 'w'},
            {'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},

        };
    }
}
