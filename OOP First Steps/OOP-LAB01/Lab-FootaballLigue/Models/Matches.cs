using System;

public class Matches
{
    private Teams homeTeam;
    private Teams awayTeam;
    private Score score;
    private int id;

    public Matches(Teams homeTeam, Teams awayTeam, Score score, int id)
    {
        this.HomeTeam = homeTeam;
        this.AwayTeam = awayTeam;
        this.Score = score;
        this.Id = id;
    }

    public Teams HomeTeam
    {
        get { return this.homeTeam; }
        set { this.homeTeam = value; }
    }

    public Teams AwayTeam
    {
        get { return this.awayTeam; }
        set { this.awayTeam = value; }
    }

    public Score Score
    {
        get { return this.score; }
        set { this.score = value; }
    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
 
    public Teams GetWinner()
    {
        if (this.IsDraw())
        {
            return null;
        }

        return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals ? this.HomeTeam : this.AwayTeam; 
    }

    private bool IsDraw()
    {
        return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
    }

}

