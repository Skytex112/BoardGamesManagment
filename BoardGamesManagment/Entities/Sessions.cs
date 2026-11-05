using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BoardGamesManagment.Entities;
using Microsoft.EntityFrameworkCore;
namespace BoardGamesManagment.Entities;
//using BoardGamesManagment.Migrations;

public class Sessions {
	
	public int Id { get; set; }
	public int GameId { get; set; }
    public int MemberId { get; set; }
    public DateTime Date { get; set; }
    public int DurationMinutes { get; set; }
    [ForeignKey(nameof(GameId))]
    public Games games { get; set; }
    [ForeignKey(nameof(MemberId))]
    public Members members { get; set; }

    //Navigation Param

    
    public override string ToString()
    {
        return $"Id {Id} -- Date {Date} -- Duration {DurationMinutes}";
    }
}