using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasleen.Models;

    public class MvcSongContext : DbContext
    {
        public MvcSongContext (DbContextOptions<MvcSongContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Song { get; set; }
    }
