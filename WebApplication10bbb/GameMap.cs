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

        const int height = 29;

        const int width = 26;

        public char[,] DefaultCoinMap = {
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
