using System;

namespace My_Games.Models;


public class GameSummary
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Genre { get; set; }

    public decimal Price { get; set; }

    public DateOnly Release_Date { get; set; }


}

