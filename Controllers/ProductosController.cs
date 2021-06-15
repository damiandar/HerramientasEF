using Microsoft.AspNetCore.Mvc;
using ProyMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyMVC.Models.VM;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ProyMVC.Controllers
{
    public class ProductosController:Controller
    {

        private readonly CineDbContext Db;
        private readonly IWebHostEnvironment Hosting;

        public ProductosController(CineDbContext context ,IWebHostEnvironment host ){
            Db=context;
            Hosting=host;
        }

        public IActionResult Index(){
           var productos=Db.Productos
            .Include(x=>x.Tamanio)
            .Include(a=>a.Categoria)
            .ToList();
           return View(productos);

        }


        public IActionResult Detalle(int id){
            var producto= Db.Productos
            .Include(a=>a.Tamanio)
            .Include(a=>a.Categoria)
            .Where(x=>x.Id==id)
            .FirstOrDefault();
            return View(producto);
        }


        public IActionResult Editar(int id){
            var producto= Db.Productos
            .Include(a=>a.Tamanio)
            .Include(a=>a.Categoria)
            .Where(x=>x.Id==id)
            .FirstOrDefault();
            return View(producto);
        }
        
    [HttpPost]
    public IActionResult Editar(Producto prod){
     if (ModelState.IsValid)
         {   
             Db.Productos.Update(prod);
             Db.SaveChanges();
             return RedirectToAction("Index");
         }
         return View(prod);
    }

    public IActionResult Crear(){
        return View();
    }

    [HttpPost]
    public IActionResult Crear(Producto prod){
        Db.Productos.Add(prod);
        Db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Borrar(int id){
        var producto=Db.Productos.Where(x=>x.Id==id).First();
        Db.Productos.Remove(producto);
        Db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult CrearVM(){
        var prodVM=new ProductoVM();
        prodVM.Tamanios= Db.Tamanios.ToList();
        prodVM.Categorias=Db.Categorias.ToList();
        return View(prodVM);
    }

    [HttpPost]
        public IActionResult CrearVM(ProductoVM formProd){
            
            var prod=formProd.Producto;
            
            if(prod.Foto!=null){
                string carpeta= Path.Combine(Hosting.WebRootPath,"imagenes");
                string archivonombre= prod.Foto.FileName;
                string ruta= Path.Combine(carpeta,archivonombre);
                prod.Foto.CopyTo(new FileStream(ruta,FileMode.Create));
                prod.FotoRuta=archivonombre;
            }

            Db.Productos.Add(prod);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ModificarVM(int id)
        {
            var producto = Db.Productos
            .Include(a => a.Tamanio)
            .Include(a => a.Categoria)
            .Where(x => x.Id == id)
            .FirstOrDefault();
            var prodVM = new ProductoVM();
            prodVM.Producto = producto;
            prodVM.Tamanios = Db.Tamanios.ToList();
            prodVM.Categorias = Db.Categorias.ToList();

            return View(prodVM);
        }


        [HttpPost]
        public IActionResult ModificarVM(ProductoVM formProd){
            
            var prod=formProd.Producto;
            //var prodanterior=Db.Productos.Where(x=>x.Id== prod.Id).FirstOrDefault();

            if(prod.Foto!=null){
                string carpeta= Path.Combine(Hosting.WebRootPath,"imagenes");
                string archivonombre= prod.Foto.FileName;
                string ruta= Path.Combine(carpeta,archivonombre);
                prod.Foto.CopyTo(new FileStream(ruta,FileMode.Create));
                prod.FotoRuta=archivonombre;
            }
            else{
                //prod.FotoRuta=prodanterior.FotoRuta;
            }

            Db.Productos.Update(prod);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }



}

}