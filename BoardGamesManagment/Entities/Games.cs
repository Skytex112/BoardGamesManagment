using System;
using System.ComponentModel.DataAnnotations;
using BoardGamesManagment.Entities;
using Microsoft.EntityFrameworkCore;
namespace BoardGamesManagment.Entities;
//using BoardGamesManagment.Migrations;


public class Games
{

		public int Id {  get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int MinPlayers { get; set; } = 1;
        public int MaxPlayers { get; set; } = 10;

        public List<Sessions> sessions { get; set; } = new();
}
