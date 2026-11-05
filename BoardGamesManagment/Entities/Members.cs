using System;
using Microsoft.EntityFrameworkCore;
namespace BoardGamesManagment.Entities;
//using BoardGamesManagment.Migrations;

public class Members
{

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public List<Sessions> sessions { get; set; } = new();
}