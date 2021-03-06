﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication10bbb.GhostsAndPacman;
using WebApplication10bbb.MapGraph;

namespace WebApplication10bbb
{
    public class Class : IDisposable
    {
        public List<string> clients = new List<string>();

        public string UserName;

        public Stopwatch stopwatch = new Stopwatch();

        public bool IsGameStarted = false;

        public bool CanGameBeContinuos = false;

        private GameMap _gameMap = new GameMap();

        private Pacman _pacman = new Pacman();

        private GhostBlinky blinky;

        private GhostPinky pinky;

        private GhostClyde clyde;

        private GhostInky inky;

        private Score score = new Score();

        public Timer PacmanTimer, ClydeTimer, PinkyTimer, BlinkyTimer, InkyTimer;

        public bool pause = false;

        List<string> eated_coin = new List<string>();

        List<string> eated_energizer = new List<string>();
        
        public string ConnectionID { get; set; }

       
        string fruit_pos;
        private int level = 1;

        private IHubContext<GameHub> hub { get; set; }

        public Class(string connectionID, IHubContext<GameHub> hub, string username)
        {
            clients.Add(connectionID);
            UserName = username;
            this.hub = hub;
        }

        public Task Move(int move)
        {
            if (pause == false)
            {
                if (move == 6)
                {
                    if (_gameMap.map[_pacman.position_x, _pacman.position_y + 1] != 'w')
                    {
                        _pacman.move_Y = 1;
                        _pacman.move_X = 0;
                    }
                }
                else if (move == 4)
                {
                    if (_gameMap.map[_pacman.position_x, _pacman.position_y - 1] != 'w')
                    {
                        _pacman.move_Y = -1;
                        _pacman.move_X = 0;
                    }
                }

                else if (move == 8)
                {
                    if (_gameMap.map[_pacman.position_x - 1, _pacman.position_y] != 'w')
                    {
                        _pacman.move_Y = 0;
                        _pacman.move_X = -1;
                    }
                }
                else if (move == 2)
                {
                    if (_gameMap.map[_pacman.position_x + 1, _pacman.position_y] != 'w')
                    {
                        _pacman.move_Y = 0;
                        _pacman.move_X = 1;
                    }
                }

            }
            return Task.CompletedTask;
        }

        internal Task StartGame()
        {
            blinky = new GhostBlinky();
            pinky = new GhostPinky();
            clyde = new GhostClyde();
            inky = new GhostInky();

            _pacman.isMoving = false;
            _pacman.position_x = 1;
            _pacman.position_y = 1;
            _pacman.move_X = 0;
            _pacman.move_Y = 1;

            level = 1;
            _pacman.lifes = 3;
            score.coin_sum = 0;
            score.game_finish = 0;
            score.sum_bonus_coin = 0;

            CountDown();

            eated_coin.Clear();
            eated_energizer.Clear();

            _gameMap.RestorMap();

            _pacman.isMoving = true;
            PacmanTimer = new Timer(UpdatePacman, null, 0, 100);
            InkyTimer = new Timer(UpdateInky, null, 0, 120);
            ClydeTimer = new Timer(UpdateCloudy, null, 0, 120);
            PinkyTimer = new Timer(UpdatePinky, null, 0, 120);
            BlinkyTimer = new Timer(UpdateBlinky, null, 0, 120);

            blinky.StartMoving();


            return Task.CompletedTask;
        }

        private void CountDown()
        {
            hub.Clients.Clients(clients).SendAsync("Level", level);

            int count = 3;
            hub.Clients.Clients(clients).SendAsync("Countdown", count);
            Thread.Sleep(400);
            ResetAllObject();
            hub.Clients.Clients(clients).SendAsync("Countdown", --count);
            Thread.Sleep(400);
            hub.Clients.Clients(clients).SendAsync("Countdown", --count);
            Thread.Sleep(400);
            hub.Clients.Clients(clients).SendAsync("Countdown", "Вперед");
            Thread.Sleep(200);
            hub.Clients.Clients(clients).SendAsync("Countdown", "hidd");
        }

        internal Task StartNewGame()
        {
            blinky = new GhostBlinky();
            pinky = new GhostPinky();
            clyde = new GhostClyde();
            inky = new GhostInky();

            _pacman.isMoving = false;
            _pacman.position_x = 1;
            _pacman.position_y = 1;
            _pacman.move_X = 0;
            _pacman.move_Y = 1;

            level = 1;
            _pacman.lifes = 3;
            score.coin_sum = 0;
            score.game_finish = 0;
            score.sum_bonus_coin = 0;

            CountDown();

            eated_coin.Clear();
            eated_energizer.Clear();

            _pacman.isMoving = true;
            PacmanTimer.Change(0, 100);
            InkyTimer.Change(0, 120);
            ClydeTimer.Change(0, 120);
            PinkyTimer.Change(0, 120);
            BlinkyTimer.Change(0, 120);

            blinky.StartMoving();
                       

            _gameMap.RestorMap();
            

            return Task.CompletedTask;
        }

        public void ContGameAfterReconect()
        {
            hub.Clients.Clients(clients).SendAsync("ChangePacmanPosition", _pacman.position_x, _pacman.position_y, score.coin_sum + score.sum_bonus_coin);
            hub.Clients.Clients(clients).SendAsync("ContinGameAfterReconnect", eated_coin, eated_energizer, _pacman.lifes);
            hub.Clients.Clients(clients).SendAsync("Level", level);
            hub.Clients.Clients(clients).SendAsync("ChangeInkyPosition", inky.position_x, inky.position_y, inky.IsFrightened, inky.MovingToHome);
            hub.Clients.Clients(clients).SendAsync("ChangeBlinkyPosition", blinky.position_x, blinky.position_y, blinky.IsFrightened, blinky.MovingToHome);
            hub.Clients.Clients(clients).SendAsync("ChangePinkyPosition", pinky.position_x, pinky.position_y, pinky.IsFrightened, pinky.MovingToHome);
            hub.Clients.Clients(clients).SendAsync("ChangeClydePosition", clyde.position_x, clyde.position_y, clyde.IsFrightened, clyde.MovingToHome);

        }

        public void ResetAllObject()
        {
            hub.Clients.Clients(clients).SendAsync("ChangePacmanPosition", _pacman.position_x, _pacman.position_y, score.coin_sum + score.sum_bonus_coin);
            hub.Clients.Clients(clients).SendAsync("ResetAllItem", eated_coin, eated_energizer, _pacman.lifes);
            hub.Clients.Clients(clients).SendAsync("Level", level);
            hub.Clients.Clients(clients).SendAsync("ChangeInkyPosition", inky.position_x, inky.position_y, inky.IsFrightened, inky.MovingToHome);
            hub.Clients.Clients(clients).SendAsync("ChangeBlinkyPosition", blinky.position_x, blinky.position_y, blinky.IsFrightened, blinky.MovingToHome);
            hub.Clients.Clients(clients).SendAsync("ChangePinkyPosition", pinky.position_x, pinky.position_y, pinky.IsFrightened, pinky.MovingToHome);
            hub.Clients.Clients(clients).SendAsync("ChangeClydePosition", clyde.position_x, clyde.position_y, clyde.IsFrightened, clyde.MovingToHome);

        }

        private void StopGhostMoving(Ghost ghost)
        {
            if (ghost.IsMoving == true)
            {
                ghost.IsMoving = false;
                ghost.IsPaused = true;
                if (ghost.IsFrightened)
                {
                    ghost.StopFrightened();
                }
                else
                {
                    ghost.StopPersecutionOrRunaway();
                }
            }
        }

        private void GameLost()
        {
            blinky = new GhostBlinky();
            pinky = new GhostPinky();
            clyde = new GhostClyde();
            inky = new GhostInky();

            _pacman.isMoving = false;

            IsGameStarted = false;

            Dispose();

            hub.Clients.Clients(clients).SendAsync("GameLost", score.coin_sum + score.sum_bonus_coin, UserName);
        }

        private void ContinGhostMoving(Ghost ghost)
        {
            if (ghost.IsPaused == true)
            {
                ghost.IsMoving = true;
                ghost.IsPaused = false;
                if (ghost.IsFrightened)
                {
                    ghost.ContinuousFrightened();
                }
                else
                {
                    ghost.ContinuousMoving();
                }
            }
        }

        internal Task PauseGame()
        {
            if (pause == false)
            {
                _pacman.last_move_X = _pacman.move_X;
                _pacman.last_move_Y = _pacman.move_Y;

                _pacman.move_X = 0;
                _pacman.move_Y = 0;

                StopGhostMoving(blinky);

                StopGhostMoving(pinky);

                StopGhostMoving(clyde);

                StopGhostMoving(inky);

                pause = true;
            }
            else
            {
                pause = false;
                _pacman.move_X = _pacman.last_move_X;
                _pacman.move_Y = _pacman.last_move_Y;

                ContinGhostMoving(blinky);

                ContinGhostMoving(pinky);

                ContinGhostMoving(clyde);

                ContinGhostMoving(inky);

            }

            return Task.CompletedTask;
        }

        private void CheckPacmanTouchGhost(Ghost ghost)
        {
            if ((_pacman.position_x == ghost.position_x) && (_pacman.position_y == ghost.position_y))
            {
                if (ghost.IsFrightened == true)
                {
                    ghost.FrightenedChange(new object());
                    ghost.MovingToHome = true;
                    score.bonus_coin = score.bonus_coin * 2;
                    score.sum_bonus_coin += score.bonus_coin;
                    hub.Clients.Clients(clients).SendAsync("Eated_ghost", ghost.position_x, ghost.position_y, score.bonus_coin);
                }
                else if ((ghost.IsFrightened == false) && (ghost.MovingToHome == false) && (ghost.IsMoving))
                {                                        
                    _pacman.lifes--;
                    if (_pacman.lifes < 0)
                    {
                        GameLost();
                    }
                    else
                    {
                        _pacman.position_x = 1;
                        _pacman.position_y = 1;
                        _pacman.move_X = 0;
                        _pacman.move_Y = 1;
                        GhostRerun();
                        hub.Clients.Clients(clients).SendAsync("PacmanLoseLife", _pacman.lifes);
                    }

                }

            }
        }

        private void MakeGhostFrightened(Ghost ghost, Timer timer)
        {
            if (ghost.IsMoving)
            {
                if (ghost.IsFrightened)
                {
                    ghost.FrightenedChange(new object());
                    ghost.Frightened();

                }
                else
                {
                    ghost.Frightened();
                    timer.Change(120, 300);
                }
            }
        }

        private void Rerun(Ghost ghost)
        {
            ghost.IsMoving = false;
            ghost.position_x = 11;
            ghost.position_y = 13;
            ghost.move_X = 0;
            ghost.move_Y = -1;
            if (ghost.IsFrightened)
            {
                ghost.FrightenedChange(new object());
            }
            if (ghost.PersecutionOrRunawayTimer != null)
            {
                ghost.StopPersecutionOrRunaway();
            }
           
        }

        private void GhostRerun()
        {
            score.ghost_start = 0;
            
            Rerun(blinky);
            blinky.StartMoving();

            Rerun(pinky);
            Rerun(inky);
            Rerun(clyde);

        }

        private void NextLevel()
        {
            blinky = new GhostBlinky();
            pinky = new GhostPinky();
            clyde = new GhostClyde();
            inky = new GhostInky();

            _pacman.isMoving = false;
            _pacman.position_x = 1;
            _pacman.position_y = 1;
            _pacman.move_X = 0;
            _pacman.move_Y = 1;

            _pacman.lifes++;
            level++;
            score.game_finish = 0;

            CountDown();

            eated_coin.Clear();
            eated_energizer.Clear();

            _pacman.isMoving = true;
            PacmanTimer.Change(0, 100);
            InkyTimer.Change(0, 120);
            ClydeTimer.Change(0, 120);
            PinkyTimer.Change(0, 120);
            BlinkyTimer.Change(0, 120);

            blinky.StartMoving();

            score.ghost_start = 0;
            

            _gameMap.RestorMap();
        }

        private void UpdatePacman(object state)
        {
            if (_pacman.isMoving)
            {
                if (pause == false)
                {
                    if (_gameMap.CoinMap[_pacman.position_x, _pacman.position_y] == 'c')
                    {
                        _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                        score.coin_sum += 10;
                        score.ghost_start++;
                        score.game_finish++;
                        //if (ghost_start_score == blinky.initial_score_limit)
                        //{
                        //    blinky.StartMoving();
                        //}
                        if ((score.ghost_start == pinky.initial_score_limit) && (pinky.IsMoving == false))
                        {
                            pinky.StartMoving();
                        }
                        if ((score.ghost_start == clyde.initial_score_limit) && (clyde.IsMoving == false))
                        {
                            clyde.StartMoving();
                        }
                        if ((score.ghost_start == inky.initial_score_limit) && (inky.IsMoving == false))
                        {
                            inky.StartMoving();
                        }
                        if (score.game_finish == 96)
                        {
                            Random random = new Random();
                            var t = random.Next(eated_coin.Count);
                            fruit_pos = eated_coin[t];

                            int first;
                            int second;

                            if (fruit_pos[1] == 'o')
                            {
                                first = Convert.ToInt32(fruit_pos[0].ToString());
                            }
                            else
                            {
                                first = Convert.ToInt32(((fruit_pos[0].ToString() + fruit_pos[1].ToString())).ToString());
                            }

                            if (fruit_pos[fruit_pos.Length - 2] == 'o')
                            {
                                second = Convert.ToInt32((fruit_pos[fruit_pos.Length - 1]).ToString());
                            }
                            else
                            {
                                second = Convert.ToInt32(((fruit_pos[fruit_pos.Length - 2].ToString() + fruit_pos[fruit_pos.Length - 1].ToString())).ToString());
                            }


                            _gameMap.CoinMap[first, second] = 'f';
                            hub.Clients.Clients(clients).SendAsync("CreateFruit", fruit_pos);

                        }
                        if (score.game_finish == 200)
                        {
                            Random random = new Random();
                            var t = random.Next(eated_coin.Count);
                            fruit_pos = eated_coin[t];

                            int first;
                            int second;

                            if (fruit_pos[1] == 'o')
                            {
                                first = Convert.ToInt32(fruit_pos[0].ToString());
                            }
                            else
                            {
                                first = Convert.ToInt32(((fruit_pos[0].ToString() + fruit_pos[1].ToString())).ToString());
                            }

                            if (fruit_pos[fruit_pos.Length - 2] == 'o')
                            {
                                second = Convert.ToInt32((fruit_pos[fruit_pos.Length - 1]).ToString());
                            }
                            else
                            {
                                second = Convert.ToInt32(((fruit_pos[fruit_pos.Length - 2].ToString() + fruit_pos[fruit_pos.Length - 1].ToString())).ToString());
                            }


                            _gameMap.CoinMap[first, second] = 'f';
                            hub.Clients.Clients(clients).SendAsync("CreateFruit", fruit_pos);

                        }
                        if (score.game_finish == 284)
                        {
                            NextLevel();
                        }

                        eated_coin.Add((_pacman.position_x).ToString() + "o" + (_pacman.position_y).ToString());

                    }
                    else if (_gameMap.CoinMap[_pacman.position_x, _pacman.position_y] == 'k')
                    {
                        eated_energizer.Add((_pacman.position_x).ToString() + "o" + (_pacman.position_y).ToString());

                        //score = score + 10;
                        score.bonus_coin = 100;

                        MakeGhostFrightened(blinky, BlinkyTimer);

                        MakeGhostFrightened(pinky, PinkyTimer);

                        MakeGhostFrightened(clyde, ClydeTimer);

                        MakeGhostFrightened(inky, InkyTimer);

                        _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                    }
                    else if (_gameMap.CoinMap[_pacman.position_x, _pacman.position_y] == 'f')
                    {
                        score.sum_bonus_coin = score.sum_bonus_coin + 500;
                        hub.Clients.Clients(clients).SendAsync("DestroyFruit", fruit_pos);
                        _gameMap.CoinMap[_pacman.position_x, _pacman.position_y] = ' ';
                    }

                    //pacman logic
                    if (_gameMap.map[_pacman.position_x + _pacman.move_X, _pacman.position_y + _pacman.move_Y] != 'w')
                    {
                        _pacman.position_x += _pacman.move_X;
                        _pacman.position_y += _pacman.move_Y;
                    }

                    // перевірка чи пакмен не натрапив на блінкі            
                    CheckPacmanTouchGhost(blinky);

                    // перевірка чи пакмен не натрапив на пінкі             
                    CheckPacmanTouchGhost(pinky);

                    // перевірка чи пакмен не натрапив на клуді
                    CheckPacmanTouchGhost(clyde);

                    // перевірка чи пакмен не натрапив на інкі
                    CheckPacmanTouchGhost(inky);


                    hub.Clients.Clients(clients).SendAsync("ChangePacmanPosition", _pacman.position_x, _pacman.position_y, score.coin_sum + score.sum_bonus_coin);

                }
            }
        }

        public void UpdateInky(object state)
        {
            //inky_logic
            if (inky.IsMoving)
            {
                if (inky.MovingToHome)
                {
                    inky.IsFrightened = false;

                    InkyTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11, 14, inky.position_x, inky.position_y);

                    inky.move_X = qwerty.Item1;
                    inky.move_Y = qwerty.Item2;

                    if ((inky.position_x == 11) && (inky.position_y == 14))
                    {
                        inky.MovingToHome = false;
                        InkyTimer.Change(120, 120);
                    }

                }
                else if (!inky.IsFrightened)
                {
                    if (inky.PersecutionOrRunaway)
                    {
                        inky.finish_point_x = inky.run_point_x;
                        inky.finish_point_y = inky.run_point_y;

                    }
                    else if (!inky.PersecutionOrRunaway)
                    {
                        int x = 0;
                        int y = 0;

                        if (_gameMap.map[_pacman.position_x + _pacman.move_X,_pacman.position_y + _pacman.move_Y] != 'w')
                        {
                            inky.pacman_position_plus_two_x = _pacman.position_x + _pacman.move_X;
                            inky.pacman_position_plus_two_y = _pacman.position_y + _pacman.move_Y;
                        }
                        try
                        {
                            if (_gameMap.map[_pacman.position_x + _pacman.move_X + _pacman.move_X, _pacman.position_y + _pacman.move_Y + _pacman.move_Y] != 'w')
                            {
                                inky.pacman_position_plus_two_x = _pacman.position_x + _pacman.move_X + _pacman.move_X;
                                inky.pacman_position_plus_two_y = _pacman.position_y + _pacman.move_Y + _pacman.move_Y;
                            }
                        }
                        catch
                        {
                            if (_gameMap.map[_pacman.position_x + _pacman.move_X, _pacman.position_y + _pacman.move_Y] != 'w')
                            {
                                inky.pacman_position_plus_two_x = _pacman.position_x + _pacman.move_X;
                                inky.pacman_position_plus_two_y = _pacman.position_y + _pacman.move_Y;
                            }
                            else
                            {
                                inky.pacman_position_plus_two_x = _pacman.position_x;
                                inky.pacman_position_plus_two_y = _pacman.position_y;
                            }
                        }

                        if (inky.pacman_position_plus_two_x <= blinky.position_x)
                        {
                            x = blinky.position_x - inky.pacman_position_plus_two_x;

                            if (inky.pacman_position_plus_two_y <= blinky.position_y)
                            {
                                y = blinky.position_y - inky.pacman_position_plus_two_y;

                                if (x == y)
                                {
                                    inky.finish_point_x = inky.pacman_position_plus_two_x;

                                    inky.finish_point_y = inky.pacman_position_plus_two_y;
                                }
                                else if (x > y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x - step), Convert.ToInt32(inky.pacman_position_plus_two_y - newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x - step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y - newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x - newx), inky.pacman_position_plus_two_y - step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x - newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y - step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }

                                }

                            }
                            else if (inky.pacman_position_plus_two_y > blinky.position_y)
                            {
                                y = inky.pacman_position_plus_two_y - blinky.position_y;

                                if (x >= y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x - step), Convert.ToInt32(inky.pacman_position_plus_two_y + newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x - step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y + newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x - newx), inky.pacman_position_plus_two_y + step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x - newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y + step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }
                                }
                            }
                        }
                        else if (inky.pacman_position_plus_two_x > blinky.position_x)
                        {
                            x = inky.pacman_position_plus_two_x - blinky.position_x;

                            if (inky.pacman_position_plus_two_y <= blinky.position_y)
                            {
                                y = blinky.position_y - inky.pacman_position_plus_two_y;

                                if (x >= y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x + step), Convert.ToInt32(inky.pacman_position_plus_two_y - newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x + step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y - newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x + newx), inky.pacman_position_plus_two_y - step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x + newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y - step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }

                                }
                            }
                            else if (inky.pacman_position_plus_two_y > blinky.position_y)
                            {
                                y = inky.pacman_position_plus_two_y - blinky.position_y;

                                if (x >= y)
                                {
                                    int step = 0;
                                    while (step != x + 1)
                                    {
                                        double kof = (((step) * 100) / x);
                                        double newy = kof / 100 * y;

                                        try
                                        {
                                            if (_gameMap.map[(inky.pacman_position_plus_two_x + step), Convert.ToInt32(inky.pacman_position_plus_two_y + newy)] != 'w')
                                            {
                                                inky.finish_point_x = inky.pacman_position_plus_two_x + step;

                                                inky.finish_point_y = Convert.ToInt32(inky.pacman_position_plus_two_y + newy);
                                            }
                                        }
                                        catch
                                        {
                                            step = x;
                                        }
                                        step++;
                                    }
                                }
                                else if (x < y)
                                {
                                    int step = 0;
                                    while (step != y + 1)
                                    {
                                        double kof = (((step) * 100) / y);
                                        double newx = kof / 100 * x;

                                        try
                                        {
                                            if (_gameMap.map[Convert.ToInt32(inky.pacman_position_plus_two_x + newx), inky.pacman_position_plus_two_y + step] != 'w')
                                            {
                                                inky.finish_point_x = Convert.ToInt32(inky.pacman_position_plus_two_x + newx);

                                                inky.finish_point_y = inky.pacman_position_plus_two_y + step;
                                            }
                                        }
                                        catch
                                        {
                                            step = y;
                                        }
                                        step++;
                                    }

                                }
                            }
                        }

                    }

                    if (inky.TimerType)
                    {
                        InkyTimer.Change(120, 120);
                        inky.TimerType = false;
                    }

                    // визначення напрямку через граф
                    if (_gameMap.map[inky.position_x, inky.position_y] == 'c')
                    {
                        try
                        {
                            var qwerty = new Init().Inite2(inky.finish_point_x, inky.finish_point_y, inky.position_x, inky.position_y, inky.move_X, inky.move_Y);
                            inky.move_X = qwerty.Item1;
                            inky.move_Y = qwerty.Item2;
                        }
                        catch { }
                        
                          
                    }

                }
                else
                {
                    // блінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[inky.position_x, inky.position_y] == 'c')
                    {
                        inky.RandomMove();                      
                        inky.TimerType = true;
                    }
                }


                if (_gameMap.map[inky.position_x + inky.move_X, inky.position_y + inky.move_Y] != 'w')
                {
                    inky.position_x += inky.move_X;
                    inky.position_y += inky.move_Y;
                }

                // перевірка чи гост не зловив пакмена
                CheckPacmanTouchGhost(inky);


                hub.Clients.Clients(clients).SendAsync("ChangeInkyPosition", inky.position_x, inky.position_y, inky.IsFrightened, inky.MovingToHome);
            }
        }

        public void UpdateCloudy(object state)
        {
            if (clyde.IsMoving)
            {
                //Clyde logic
                if (clyde.MovingToHome)
                {
                    clyde.IsFrightened = false;

                    ClydeTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11, 14, clyde.position_x, clyde.position_y);

                    clyde.move_X = qwerty.Item1;
                    clyde.move_Y = qwerty.Item2;

                    if ((clyde.position_x == 11) && (clyde.position_y == 14))
                    {
                        clyde.MovingToHome = false;
                        ClydeTimer.Change(120, 120);
                    }

                }
                else if (!clyde.IsFrightened)
                {
                    if (clyde.PersecutionOrRunaway)
                    {
                        //рух в кут, в точку розбігання
                        clyde.finish_point_x = clyde.run_point_x;
                        clyde.finish_point_y = clyde.run_point_y;
                    }
                    else if (!clyde.PersecutionOrRunaway)
                    {
                        // переслідування пакмена
                        if (_gameMap.map[clyde.position_x, clyde.position_y] == 'c')
                        {
                            int shot_way;

                            shot_way = new Init().Shortest_way(_pacman.position_x, _pacman.position_y, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);
                            
                            if (shot_way <= 15)
                            {
                                clyde.finish_point_x = clyde.run_point_x;
                                clyde.finish_point_y = clyde.run_point_y;
                            }
                            else
                            {
                                clyde.finish_point_x = _pacman.position_x;
                                clyde.finish_point_y = _pacman.position_y;
                            }
                        }
                    }

                    if (clyde.TimerType)
                    {
                        ClydeTimer.Change(120, 120);
                        clyde.TimerType = false;
                    }

                    if (_gameMap.map[clyde.position_x, clyde.position_y] == 'c')
                    {                       
                        var qwerty = new Init().Inite2(clyde.finish_point_x, clyde.finish_point_y, clyde.position_x, clyde.position_y, clyde.move_X, clyde.move_Y);
                        clyde.move_X = qwerty.Item1;
                        clyde.move_Y = qwerty.Item2;
                         
                    }
                }
                else
                {
                    // клуді переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[clyde.position_x, clyde.position_y] == 'c')
                    {
                        clyde.RandomMove();
                       
                        clyde.TimerType = true;
                    }
                }

                if (_gameMap.map[clyde.position_x + clyde.move_X, clyde.position_y + clyde.move_Y] != 'w')
                {
                    clyde.position_x += clyde.move_X;
                    clyde.position_y += clyde.move_Y;
                }
                

                // перевірка чи клуді не зловив пакмена
                CheckPacmanTouchGhost(clyde);


                hub.Clients.Clients(clients).SendAsync("ChangeClydePosition", clyde.position_x, clyde.position_y, clyde.IsFrightened, clyde.MovingToHome);
            }
        }

        private void UpdatePinky(object state)
        {           
            if (pinky.IsMoving)
            {
                if (pinky.MovingToHome)
                {
                    pinky.IsFrightened = false;

                    PinkyTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11, 14, pinky.position_x, pinky.position_y);

                    pinky.move_X = qwerty.Item1;
                    pinky.move_Y = qwerty.Item2;

                    if ((pinky.position_x == 11) && (pinky.position_y == 14))
                    {
                        pinky.MovingToHome = false;
                        PinkyTimer.Change(120, 120);
                    }

                }
                else if (!pinky.IsFrightened)
                {
                    //pinky_logic
                    if (pinky.PersecutionOrRunaway)
                    {
                        pinky.finish_point_x = pinky.run_point_x;
                        pinky.finish_point_y = pinky.run_point_y;

                    }
                    else if (!pinky.PersecutionOrRunaway)
                    {
                        pinky.finish_point_x = _pacman.position_x;
                        pinky.finish_point_y = _pacman.position_y;

                        for (int i = 0; i < 4; i++)
                        {
                            if ((_gameMap.map[pinky.finish_point_x + _pacman.move_X, pinky.finish_point_y + _pacman.move_Y] != 'w'))
                            {
                                pinky.finish_point_x += _pacman.move_X;
                                pinky.finish_point_y += _pacman.move_Y;
                            }
                        }
                    }

                    if (pinky.TimerType)
                    {
                        PinkyTimer.Change(120, 120);
                        pinky.TimerType = false;
                    }

                    if (_gameMap.map[pinky.position_x, pinky.position_y] == 'c')
                    {                        
                        var qwerty = new Init().Inite2(pinky.finish_point_x, pinky.finish_point_y, pinky.position_x, pinky.position_y, pinky.move_X, pinky.move_Y);

                        pinky.move_X = qwerty.Item1;
                        pinky.move_Y = qwerty.Item2;
                        
                    }

                }
                else if (pinky.IsFrightened)
                {
                    // пінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[pinky.position_x, pinky.position_y] == 'c')
                    {
                        pinky.RandomMove();                        
                        pinky.TimerType = true;
                    }
                }
               
                if (_gameMap.map[pinky.position_x + pinky.move_X, pinky.position_y + pinky.move_Y] != 'w')
                {
                    pinky.position_x += pinky.move_X;
                    pinky.position_y += pinky.move_Y;
                }

                // перевірка чи пінкі не зловив пакмена               
                CheckPacmanTouchGhost(pinky);
                             
                hub.Clients.Clients(clients).SendAsync("ChangePinkyPosition", pinky.position_x, pinky.position_y, pinky.IsFrightened, pinky.MovingToHome);
            }
        }

        private void UpdateBlinky(object state)
        {      
            //blinky_logic
            if (blinky.IsMoving)
            {
                if (blinky.MovingToHome)
                {
                    blinky.IsFrightened = false;
                    
                    BlinkyTimer.Change(50, 50);
                    var qwerty = new Init().Inite(11,14,blinky.position_x,blinky.position_y);

                    blinky.move_X = qwerty.Item1;
                    blinky.move_Y = qwerty.Item2;

                    if ((blinky.position_x == 11) && (blinky.position_y == 14))
                    {
                        blinky.MovingToHome = false;
                        BlinkyTimer.Change(120, 120);
                    }

                }
                else if(!blinky.IsFrightened)
                {
                    if (blinky.PersecutionOrRunaway)
                    {
                        blinky.finish_point_x = blinky.run_point_x;
                        blinky.finish_point_y = blinky.run_point_y;

                    }
                    else if (!blinky.PersecutionOrRunaway)
                    {
                        blinky.finish_point_x = _pacman.position_x;
                        blinky.finish_point_y = _pacman.position_y;
                    }

                    if (blinky.TimerType)
                    {
                        BlinkyTimer.Change(120, 120);
                        blinky.TimerType = false;
                    }

                    // визначення напрямку через граф
                    if (_gameMap.map[blinky.position_x, blinky.position_y] == 'c')
                    {
                        var qwerty = new Init().Inite2(blinky.finish_point_x, blinky.finish_point_y, blinky.position_x, blinky.position_y, blinky.move_X, blinky.move_Y);

                        blinky.move_X = qwerty.Item1;
                        blinky.move_Y = qwerty.Item2;
                        
                    }

                }
                else if (blinky.IsFrightened)
                {
                    // блінкі переходить у режим страху: зменшення швидкості, миттєво змінює напрямок, випадково визначає напрямок руху
                    if (_gameMap.map[blinky.position_x, blinky.position_y] == 'c')
                    {
                        blinky.RandomMove();
                        
                        blinky.TimerType = true;
                    }
                }
               


                if (_gameMap.map[blinky.position_x + blinky.move_X, blinky.position_y + blinky.move_Y] != 'w')
                {
                    blinky.position_x += blinky.move_X;
                    blinky.position_y += blinky.move_Y;
                }

                // перевірка чи пінкі не зловив пакмена     
                CheckPacmanTouchGhost(blinky);
                
                hub.Clients.Clients(clients).SendAsync("ChangeBlinkyPosition", blinky.position_x, blinky.position_y, blinky.IsFrightened, blinky.MovingToHome);
            }
        }
        
        public void Dispose()
        {
            try
            {
                BlinkyTimer.Dispose();
                PinkyTimer.Dispose();
                ClydeTimer.Dispose();
                InkyTimer.Dispose();
                PacmanTimer.Dispose();

                blinky.PersecutionOrRunawayTimer.Dispose();
                blinky.FrightenedTimer.Dispose();
                blinky.PersecutionOrRunawayWatch.Stop();
                blinky.IsFrightenedWatch.Stop();

                pinky.PersecutionOrRunawayTimer.Dispose();
                pinky.FrightenedTimer.Dispose();
                pinky.PersecutionOrRunawayWatch.Stop();
                pinky.IsFrightenedWatch.Stop();

                inky.PersecutionOrRunawayTimer.Dispose();
                inky.FrightenedTimer.Dispose();
                inky.PersecutionOrRunawayWatch.Stop();
                inky.IsFrightenedWatch.Stop();

                clyde.PersecutionOrRunawayTimer.Dispose();
                clyde.FrightenedTimer.Dispose();
                clyde.PersecutionOrRunawayWatch.Stop();
                clyde.IsFrightenedWatch.Stop();
            }
            catch
            { }
        }
    }
}
