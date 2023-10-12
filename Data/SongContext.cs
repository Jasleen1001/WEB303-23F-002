using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasleen.Models;

    public class SongContext : DbContext
    {
        public SongContext (DbContextOptions<SongContext> options)
            : base(options)
        {
        }

        public DbSet<Jasleen.Models.Song> Song { get; set; }
    }
