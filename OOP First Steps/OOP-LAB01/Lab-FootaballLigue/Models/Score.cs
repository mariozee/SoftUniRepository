﻿using System;

public class Score
{
    private int homeTeamGoals;
    private int awayTeamGoals;

    public Score(int homeTeamGoals, int awayTeamGoals)
    {
        this.HomeTeamGoals = homeTeamGoals;
        this.AwayTeamGoals = awayTeamGoals;
    }

    public int HomeTeamGoals
    {
        get { return this.homeTeamGoals; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Home team golas cannot be negative number!");
            }
            this.homeTeamGoals = value;
        } 
    }

    public int AwayTeamGoals
    {
        get { return this.awayTeamGoals; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Away team golas cannot be negative number!");
            }
            this.awayTeamGoals = value;
        }
    }
}

