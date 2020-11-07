using System;
using Microsoft.AspNetCore.Mvc;
using ProyMVC.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ProyMVC.Controllers
{
    public class PeliculasController:Controller
    {

        private readonly CineDbContext _context;

        public PeliculasController(CineDbContext context){
            _context=context;
        }

        public IActionResult Index(){
            var peliculasDb= _context.Peliculas     
            .Select(p=> new PeliculasDto(){
                Id=p.Id,
                Anio=p.Anio,
                Duracion=p.Duracion,
                Titulo=p.Titulo,
                GeneroNombre=p.Genero.Descripcion,
            })
            .ToList();
            return View(peliculasDb);
        }

        public IActionResult Detalle(int id){
            var peli= _context.Peliculas 
            .Where(p=> p.Id==id)
            .Select(p=> new PeliculasDto(){
                Id=p.Id,
                Anio=p.Anio,
                Duracion=p.Duracion,
                Titulo=p.Titulo,
                GeneroNombre=p.Genero.Descripcion,
                Actores= p.ActorPeliculas 
                            .Where(x=> x.PeliculaId==p.Id)
                            .Select(a => new Actores()
                            {
                                Nombre=a.Actor.Nombre,
                                Apellido=a.Actor.Apellido,
                            }
                            ).ToList()
            })
            .FirstOrDefault();
            return View(peli);
        }
        
    }
}