using System;
using Microsoft.AspNetCore.Mvc; 
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyMVC.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ProyMVC.Controllers
{
    public class ActoresController:Controller
    {
       private readonly CineDbContext _context;
       private readonly IWebHostEnvironment _hostingEnvironment;

        public ActoresController(CineDbContext context,
                                IWebHostEnvironment hostingEnviroment){
            _context=context;
            _hostingEnvironment=hostingEnviroment;
        }

        public IActionResult Index(){
            var Actores= _context.Actores 
                .Select(a => new ActorDto(){
                    Nombre=a.Nombre,
                    Apellido=a.Apellido,
                    Origen= a.Bios.Origen,
                    Bio=(a.Bios== null) ? new Bios(){ BioId=1, Origen="Desconocido"} : a.Bios,
                    Id=a.Id,
                    FotoRuta=(a.FotoRuta==null) ? "sinfoto.png" : a.FotoRuta
               }).ToList();
            return View(Actores);
        }

        public IActionResult Detalle(int id){
            var actores=_context.Actores
            .Include(x=> x.ActorPeliculas)
            .ThenInclude(x=> x.Pelicula)
            .ThenInclude(x=> x.Genero) 
            .Include(x=> x.Bios) 
            .Where(a=> a.Id==id)
            .FirstOrDefault();
            return View(actores);
        }
        public IActionResult Datos(int id){
            var Actores= _context.Actores  
                .Include(x=> x.ActorPeliculas)
                .ThenInclude(x=> x.Pelicula)
                .ThenInclude(x=> x.Genero)
                .Include(x=>x.Bios)
                .Where(a=> a.Id==id)
                .Select(a => new ActorDto(){
                    Nombre=a.Nombre,
                    Apellido=a.Apellido,
                    Origen= a.Bios.Origen,
                    Bio=(a.Bios== null) ? new Bios(){ BioId=1, Origen="Desconocido"} : a.Bios,
                    Pelis= a.ActorPeliculas.Where(x=> x.ActorId==a.Id)
                            .OrderByDescending(a=>a.Pelicula.Titulo)
                            .Select(a => new PeliculasDto()
                            {
                                Id=a.Pelicula.Id,
                                Titulo=a.Pelicula.Titulo,
                                GeneroNombre=a.Pelicula.Genero.Descripcion
                            }
                            )
                            .Take(3)
                            .ToList(),
                    Id=a.Id
               }).FirstOrDefault();


            return View(Actores);
        }


        public IActionResult Modificar(int id){
            var actorDB= _context.Actores.Where(s=> s.Id==id).FirstOrDefault();
            return View(actorDB);
        }

        [HttpPost]
        public IActionResult Modificar(Actores actor){
                _context.Actores.Update(actor);
                //_context.Actores.Remove(actor);
                //_context.Actores.Add(actor);
                //_context.Entry(actor).State=EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");  
        }

        public IActionResult Crear(){
             return View();
        }

        [HttpPost]
        public IActionResult Crear(Actores actor){
            if(actor.Foto!=null){
                string carpetaFotos=Path.Combine(_hostingEnvironment.WebRootPath,"imagenes");
                string nombreArchivo=actor.Foto.FileName;
                string rutaCompleta=Path.Combine(carpetaFotos,nombreArchivo);
                //subimos la imagen al servidor
                actor.Foto.CopyTo(new FileStream(rutaCompleta,FileMode.Create));
                //guardar la ruta de la imagen en la base de datos
                actor.FotoRuta=nombreArchivo;
            }
            _context.Actores.Add(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");  
        }

       public IActionResult Borrar(int id){
           var actor=_context.Actores.Where(x=> x.Id==id).First();
           //_context.Actores.FromSqlRaw("delete from actores where id={0}",id);
            _context.Actores.Remove(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");  
        }

    }
}